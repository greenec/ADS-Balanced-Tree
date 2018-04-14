using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedTree
{
    public enum TraverseOrder
    {
        InOrder,
        PreOrder,
        PostOrder
    }

    class ADSTree
    {
        private ADSNode Root;

        public sealed class ADSNode
        {
            public ADSNode Left;
            public ADSNode Right;
            public int Key;
            public int Cardinality; // Increment each time duplicates are added
            public int Height
            {
                get
                {
                    return Math.Max(Left?.Height ?? -1, Right?.Height ?? -1) + 1;
                }
            }
            public int LeftHeight
            {
                get
                {
                    return (Left?.Height ?? -1) + 1;
                }
            }
            public int RightHeight
            {
                get
                {
                    return (Right?.Height ?? -1) + 1;
                }
            }
        }

        public ADSTree()
        {
            Root = null;
        }

        // Return the node where value is located
        public ADSNode Find(int value)
        {
            return null;
        }

        // Inserts a node into the tree and maintains it's balance
        public void Insert(int value)
        {
            var newNode = new ADSNode { Key = value };

            if (Root == null)
            {
                Root = newNode;
                return;
            }

            ADSNode current = Root;
            ADSNode parent;

            while (true)
            {
                parent = current;

                if (value < current.Key)
                {
                    current = current.Left;

                    if (current == null)
                    {
                        parent.Left = newNode;
                        break;
                    }
                }
                else
                {
                    current = current.Right;

                    if (current == null)
                    {
                        parent.Right = newNode;
                        break;
                    }
                }
            }
        }

        public ADSNode GetImbalancedNode(ADSNode node)
        {
            if (node == null)
            {
                return null;
            }

            // TODO: this isn't a height, it should be the number of children
            if (Math.Abs(node.LeftHeight - node.RightHeight) > 1)
            {
                return node;
            }

            return GetImbalancedNode(node?.Left) ?? GetImbalancedNode(node?.Right);
        }

        // Print the tree in a particular order
        public void PrintTree(TraverseOrder order)
        {

        }

        public ADSNode GetRoot()
        {
            return Root;
        }
    }
}

