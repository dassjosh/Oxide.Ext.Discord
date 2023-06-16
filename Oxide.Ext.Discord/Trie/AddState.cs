// Originally from: https://github.com/gmamaladze/trienet
// Modified by: MJSU

namespace Oxide.Ext.Discord.Trie
{
    internal struct AddState<T>
    {
        public Node<T> Leaf;
        public Node<T> Node;
        public StringSlice Text;
        public int Offset;

        public AddState(Node<T> leaf, Node<T> node, StringSlice text, int offset)
        {
            Leaf = leaf;
            Node = node;
            Text = text;
            Offset = offset;
        }

        public AddState<T> SliceLastChar() => new AddState<T>(Leaf, Node, Text.SliceLastChar(), Offset);

        public AddState<T> TraverseNodeLevel() => new AddState<T>(Leaf, Node.Suffix, Text, Offset - 1);
    }
}