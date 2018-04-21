﻿using System;

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

            this.Balance();
        }

        private ref ADSNode GetImbalancedNode(ref ADSNode node)
        {
            // base case 1: we hit the end of a branch
            if (node == null)
            {
                return ref node;
            }

            // base case 2: we found the imbalanced node
            if (Math.Abs(node.LeftHeight - node.RightHeight) > 1)
            {
                return ref node;
            }

            // recursively traverse the left and the right branches
            ref var leftImbal = ref GetImbalancedNode(ref node.Left);
            ref var rightImbal = ref GetImbalancedNode(ref node.Right);

            if (leftImbal != null)
            {
                return ref leftImbal;
            }
            else
            {
                return ref rightImbal;
            }
        }

        private string ImbalanceType(ADSNode node)
        {
            if (node.LeftHeight > node.RightHeight)
            {
                node = node.Left;

                if (node.LeftHeight > node.RightHeight)
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

                if (node.LeftHeight > node.RightHeight)
                {
                    return "RL";
                }
                else
                {
                    return "RR";
                }
            }
        }

        private void Balance()
        {
            ref var imbalancedNode = ref GetImbalancedNode(ref Root);

            if (imbalancedNode == null)
            {
                return;
            }

            var imbalanceType = ImbalanceType(imbalancedNode);

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

                imbalancedNode = tempNode;
            }

            if (imbalanceType == "LL")
            {
                var tempNode = imbalancedNode.Left;
                imbalancedNode.Left = null;

                tempNode.Right = imbalancedNode;

                imbalancedNode = tempNode;
            }

            if (imbalanceType == "RR")
            {
                var tempNode = imbalancedNode.Right;
                imbalancedNode.Right = null;

                tempNode.Left = imbalancedNode;

                imbalancedNode = tempNode;
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

                imbalancedNode = tempNode;
            }
        }

        // Print the tree in a particular order
        public void PrintTree(TraverseOrder order)
        {

        }
    }
}

