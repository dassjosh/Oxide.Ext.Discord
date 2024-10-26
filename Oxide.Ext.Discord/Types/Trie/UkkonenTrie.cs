// Originally from: https://github.com/gmamaladze/trienet
// Modified by: MJSU

using System;
using System.Collections.Generic;
using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Types
{
    /// <summary>
    /// A Ukkonen Suffix Trie
    /// </summary>
    /// <typeparam name="T">Type to store in the Trie</typeparam>
    public class UkkonenTrie<T>
    {
        //The root of the suffix tree
        private readonly Node<T> _root;
        private readonly Func<T, T, bool> _equalsFunc;

        /// <summary>
        /// Constructor
        /// </summary>
        public UkkonenTrie() : this((left, right) => left.Equals(right)) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="equalsFunc">Function to match values when removing</param>
        public UkkonenTrie(Func<T, T, bool> equalsFunc)
        {
            _equalsFunc = equalsFunc;
            _root = new Node<T>(_equalsFunc);
        }

        /// <summary>
        /// Size of the Trie
        /// </summary>
        public long Size => _root.Size();

        /// <summary>
        /// Search the trie for search value
        /// </summary>
        /// <param name="search">Text to search for</param>
        /// <returns><see cref="IEnumerable{T}"/> of matches</returns>
        public IEnumerable<T> Search(string search)
        {
            HashSet<T> matches = DiscordPool.Internal.GetHashSet<T>();
            foreach (WordKey<T> word in RetrieveSubstrings(search))
            {
                T value = word.Value;
                if (matches.Add(value))
                {
                    yield return value;
                }
            }
            
            DiscordPool.Internal.FreeHashSet(matches);
        }

        private IEnumerable<WordKey<T>> RetrieveSubstrings(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return _root.GetData();
            }

            StringSlice slice = new(word);
            Node<T> node = SearchNode(slice);
            if (node == null)
            {
                return Array.Empty<WordKey<T>>();
            }

            return node.GetData();
        }

        /// <summary>
        /// Add a new record into the trie
        /// </summary>
        /// <param name="key">Key for the record</param>
        /// <param name="value">Value to be added</param>
        public void Add(string key, T value)
        {
            StringSlice keySlice = new(key);
            AddState<T> inputState = new(_root, _root, keySlice.Slice(0, 0), 0);
            int size = key.Length;
            // iterate over the string, one char at a time
            for (int i = 0; i < size; i++)
            {
                inputState.Text.EndIndex += 1;

                //update the tree with the new transitions due to this new char
                inputState = Update(inputState, keySlice.Slice(i), value);
                //make sure the active state is canonical
                inputState = GetFurthestNode(inputState);
            }

            // add leaf suffix link, is necessary
            if (inputState.Leaf.Suffix == null && inputState.Leaf != _root && inputState.Leaf != inputState.Node)
            {
                inputState.Leaf.Suffix = inputState.Node;
            }
        }

        /// <summary>
        /// Removes a record from the trie
        /// </summary>
        /// <param name="key">Key for the record</param>
        /// <param name="value">Value of the record</param>
        public void Remove(string key, T value)
        {
            StringSlice keySlice = new(key);
            StringSlice slice = keySlice.Slice(0, 0);
            int size = key.Length;

            for (int i = 0; i < size; i++)
            {
                slice.EndIndex += 1;
                Node<T> node = SearchNode(slice);
                node?.Remove(slice, value);
            }
        }

        private static bool RegionMatches(StringSlice first, int firstOffset, StringSlice second, int secondOffset, int length)
        {
            for (int i = 0; i < length; i++)
            {
                if (first[firstOffset + i] != second[secondOffset + i])
                {
                    return false;
                }
            }

            return true;
        }
        
        private Node<T> SearchNode(StringSlice word)
        {
            Node<T> currentNode = _root;

            for (int i = 0; i < word.Length; i++)
            {
                char character = word[i];
                // follow the EdgeA<T> corresponding to this char
                Edge<T> currentEdge = currentNode.GetEdge(character);
                if (currentEdge == null)
                {
                    // there is no Edge<T> starting with this char
                    return null;
                }
                
                StringSlice label = currentEdge.Label;
                int lenToMatch = Math.Min(word.Length - i, label.Length);

                if (!RegionMatches(word, i, label, 0, lenToMatch))
                {
                    // the label on the Edge<T> does not correspond to the one in the string to search
                    return null;
                }

                if (label.Length >= word.Length - i)
                {
                    return currentEdge.Node;
                }
                
                // advance to next Node
                currentNode = currentEdge.Node;
                i += lenToMatch - 1;
            }

            return null;
        }
        
        private SplitResult<T> TestAndSplit(AddState<T> input, char character, StringSlice remainder, T value)
        {
            // descend the tree as far as possible
            input = GetFurthestNode(input);

            if (input.Text.Length > 0)
            {
                Edge<T> nodeEdge = input.Node.GetEdge(input.Text[0]);

                StringSlice label = nodeEdge.Label;
                // must see whether string is substring of the label of an Edge<T>
                if (label.Length > input.Text.Length && label[input.Text.Length].Equals(character))
                {
                    return new SplitResult<T>(input.Node, true);
                }

                // need to split the Edge<T>
                StringSlice remainingSlice = label.Slice(input.Text.Length);

                // build a new EdgeA<T>
                nodeEdge.Label = remainingSlice;

                // build a new Node
                Node<T> n = new(_equalsFunc);
                n.AddEdge(remainingSlice[0], nodeEdge);
                input.Node.AddEdge(input.Text[0], new Edge<T>(input.Text, n));

                return new SplitResult<T>(n, false);
            }

            Edge<T> edge = input.Node.GetEdge(character);
            if (edge == null)
            {
                // if there is no t-transtion from s
                return new SplitResult<T>(input.Node, false);
            }

            StringSlice edgeLabel = edge.Label;
            if (remainder == edgeLabel)
            {
                // update payload of destination Node
                edge.Node.AddData(new WordKey<T>(input.Text.Original, value));
                return new SplitResult<T>(input.Node, true);
            }

            if (remainder.StartsWith(edgeLabel) || !edgeLabel.StartsWith(remainder))
            {
                return new SplitResult<T>(input.Node, true);
            }

            // need to split as above
            Node<T> newNode = new(_equalsFunc);
            newNode.AddData(new WordKey<T>(input.Text.Original, value));

            edge.Label = edge.Label.Slice(remainder.Length);
            newNode.AddEdge(edge.Label[0], edge);
            input.Node.AddEdge(character, new Edge<T>(remainder, newNode));
            return new SplitResult<T>(input.Node, false);
            // they are different words. No prefix. but they may still share some common substr
        }


        private static AddState<T> GetFurthestNode(AddState<T> input)
        {
            if (input.Text.Length == 0)
            {
                return input;
            }
            
            Edge<T> edge = input.Node.GetEdge(input.Text[0]);
            // descend the tree as long as a proper label is found
            while (edge != null && input.Text.Length >= edge.Label.Length && input.Text.StartsWith(edge.Label))
            {
                input.Text.StartIndex += edge.Label.Length;
                input.Offset += edge.Label.Length;
                input.Node = edge.Node;
                if (input.Text.Length > 0)
                {
                    edge = input.Node.GetEdge(input.Text[0]);
                }
            }

            return input;
        }
        
        private AddState<T> Update(AddState<T> input, StringSlice rest, T value)
        {
            char newChar = input.Text[input.Text.Length - 1];

            // line 1
            Node<T> oldRoot = _root;

            // line 1b
            SplitResult<T> result = TestAndSplit(input.SliceLastChar(), newChar, rest, value);

            // line 2
            while (!result.Endpoint)
            {
                // line 3
                Edge<T> edge = result.Node.GetEdge(newChar);
                Node<T> leaf;
                if (edge != null)
                {
                    // such a Node is already present. This is one of the main differences from Ukkonen's case:
                    // the tree can contain deeper nodes at this stage because different strings were added by previous iterations.
                    leaf = edge.Node;
                }
                else
                {
                    // must build a new leaf
                    leaf = new Node<T>(_equalsFunc);
                    leaf.AddData(new WordKey<T>(input.Text.Original, value));
                    result.Node.AddEdge(newChar, new Edge<T>(rest, leaf));
                }

                // update suffix link for newly created leaf
                if (input.Leaf != _root)
                {
                    input.Leaf.Suffix = leaf;
                }

                input.Leaf = leaf;
                
                if (oldRoot != _root)
                {
                    oldRoot.Suffix = result.Node;
                }
                
                oldRoot = result.Node;
                
                if (input.Node.Suffix == null)
                {
                    // root Node
                    // this is a special case to handle what is referred to as Node _|_ on the paper
                    input.Text = input.Text.Slice(1);
                }
                else
                {
                    input.Text.EndIndex -= 1;
                    input = GetFurthestNode(input.TraverseNodeLevel());
                    input.Text.EndIndex += 1;
                }
                
                result = TestAndSplit(input.SliceLastChar(), newChar, rest, value);
            }
            
            if (oldRoot != _root)
            {
                oldRoot.Suffix = result.Node;
            }

            return input;
        }
    }
}