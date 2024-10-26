// Originally from: https://github.com/gmamaladze/trienet
// Modified by: MJSU

namespace Oxide.Ext.Discord.Types
{
    internal class Edge<T>
    {
        public StringSlice Label;
        public readonly Node<T> Node;
        
        public Edge(StringSlice label, Node<T> node) 
        {
            Label = label;
            Node = node;
        }
    }
}