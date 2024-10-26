// Originally from: https://github.com/gmamaladze/trienet
// Modified by: MJSU

using System;
using System.Collections.Generic;

namespace Oxide.Ext.Discord.Types
{
    internal class Node<T>
    {
        public Node<T> Suffix;

        public IReadOnlyList<EdgeKey<T>> Edges => _edges;
        
        private readonly List<EdgeKey<T>> _edges = new(0);
        private readonly List<WordKey<T>> _data = new(0);
        private readonly Func<T, T, bool> _equalsFunc;


        public Node(Func<T, T, bool> equalsFunc)
        {
            _equalsFunc = equalsFunc;
        }
        
        public long Size()
        {
            long sum = 1;
            for (int index = 0; index < _edges.Count; index++)
            {
                EdgeKey<T> key = _edges[index];
                sum += key.Value.Node.Size();
            }

            return sum;
        }

        /// <summary>
        /// Gets the data of the whole sub-tree rooted on this node.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WordKey<T>> GetData()
        {
            for (int index = 0; index < _data.Count; index++)
            {
                WordKey<T> key = _data[index];
                yield return key;
            }

            for (int index = 0; index < _edges.Count; index++)
            {
                EdgeKey<T> edgeKey = _edges[index];
                foreach (WordKey<T> word in edgeKey.Value.Node.GetData())
                {
                    yield return word;
                }
            }
        }

        public void AddData(WordKey<T> value)
        {
            if (_data.Contains(value))
            {
                return;
            }

            _data.Add(value);
            Suffix?.AddData(value);
        }
        
        public void Remove(StringSlice slice, T value)
        {
            for (int index = _data.Count - 1; index >= 0; index--)
            {
                WordKey<T> key = _data[index];
                if (key.Key == slice.Original && _equalsFunc(key.Value, value))
                {
                    _data.RemoveAt(index);
                }
            }
        }

        public void AddEdge(char ch, Edge<T> edge)
        {
            int index = IndexOf(ch);
            if (index < 0)
            {
                _edges.Insert(~index, new EdgeKey<T>(ch, edge));
            }
            else
            {
                _edges[index] = new EdgeKey<T>(ch, edge);
            }
        }

        public Edge<T> GetEdge(char ch)
        {
            int index = IndexOf(ch);
            return index < 0 ? null : _edges[index].Value;
        }

        // Perform binary search to find the place of this character
        private int IndexOf(char ch)
        {
            int min = 0;
            int max = _edges.Count - 1;
            while (min <= max)
            {
                int mid = min + (max - min) / 2;
                char midTerm = _edges[mid].Key;

                if (ch < midTerm)
                {
                    max = mid - 1;
                }
                else if (ch > midTerm)
                {
                    min = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return ~min;
        }
    }
}