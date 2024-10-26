// Originally from: https://github.com/gmamaladze/trienet
// Modified by: MJSU

namespace Oxide.Ext.Discord.Types
{
    internal struct SplitResult<T>
    {
        public readonly Node<T> Node;
        public readonly bool Endpoint;

        public SplitResult(Node<T> node, bool endpoint)
        {
            Node = node;
            Endpoint = endpoint;
        }
    }
}