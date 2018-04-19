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

            if (Math.Abs(node.LeftHeight - node.RightHeight) > 1)
            {
                return node;
            }

            return GetImbalancedNode(node?.Left) ?? GetImbalancedNode(node?.Right);
        }

        public string ImbalanceType(ADSNode node)
        {
            if(node.LeftHeight > node.RightHeight)
            {
                node = node.Left;

                if(node.LeftHeight > node.RightHeight)
                {
                    return "LL";
                }
                else
                {
                    return "LR";
                }
            }
            else
            {
                node = node.Right;

                if(node.LeftHeight > node.RightHeight)
                {
                    return "RL";
                }
                else
                {
                    return "RR";
                }
            }
        }

        public void Balance()
        {
            var imbalancedNode = GetImbalancedNode(Root);
            var imbalanceType = ImbalanceType(imbalancedNode);

            // TODO: implement all rotation cases
            if (imbalanceType == "LR")
            {
                // do a left sub-rotation
                var tempNode = imbalancedNode.Left.Right;
                imbalancedNode.Left.Right = null;

                tempNode.Left = imbalancedNode.Left;
                imbalancedNode.Left = null;

                imbalancedNode.Left = tempNode;

                // do a right rotation
                tempNode = imbalancedNode.Left;
                imbalancedNode.Left = null;

                tempNode.Right = imbalancedNode;

                // TODO: tempNode is properly balanced, but imbalanced node is not being reassigned properly
                // imbalancedNode = tempNode;
                Root = tempNode;
            }

            if(imbalanceType == "LL")
            {
                var tempNode = imbalancedNode.Left;
                imbalancedNode.Left = null;

                tempNode.Right = imbalancedNode;

                Root = tempNode;
            }

            if(imbalanceType == "RR")
            {
                var tempNode = imbalancedNode.Right;
                imbalancedNode.Right = null;

                tempNode.Left = imbalancedNode;

                Root = tempNode;
            }

            if (imbalanceType == "RL")
            {
                // right sub-rotation
                var tempNode = imbalancedNode.Right.Left;
                imbalancedNode.Right.Left = null;

                imbalancedNode.Right.Right = tempNode;

                // left rotation
                tempNode = imbalancedNode.Right;
                imbalancedNode.Right = null;

                tempNode.Left = imbalancedNode;

                Root = tempNode;
            }
        }

        // Print the tree in a particular order
        public void PrintTree(TraverseOrder order)
        {

        }

        public ADSNode GetRoot()
        {
            return Root;
        }

        public void SetRoot(ADSNode node)
        {
            Root = node;
        }
    }
}

