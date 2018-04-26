using System;

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
            public int Height;

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
            public void RecalculateHeight()
            {
                Height = Math.Max(Left?.Height ?? -1, Right?.Height ?? -1) + 1;
            }
        }

        public ADSTree()
        {
            Root = null;
        }

        // Return the node where value is located
        public ADSNode Find(int value)
        {
            ADSNode current = Root;

            while (true)
            {
                if (current == null)
                {
                    return null;
                }

                if (value == current.Key)
                {
                    return current;
                }

                if (value < current.Key)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
        }

        // Inserts a node into the tree and maintains its balance
        public void Insert(int value)
        {
            var newNode = new ADSNode { Key = value };

            InsertNode(ref Root, newNode);
        }

        private ADSNode InsertNode(ref ADSNode head, ADSNode data)
        {
            if (head == null)
            {
                // do the insert
                head = data;
                return head;
            }

            if (head.Key < data.Key)
            {
                head.Right = InsertNode(ref head.Right, data);
            }
            else
            {
                head.Left = InsertNode(ref head.Left, data);
            }

            // attempt to rebalance when bubbling up
            if (Math.Abs(head.LeftHeight - head.RightHeight) > 1)
            {
                Balance(ref head);

                // recalculate heights
                head.Left?.RecalculateHeight();
                head.Right?.RecalculateHeight();
            }

            head.RecalculateHeight();

            return head;
        }

        private void Balance(ref ADSNode imbalancedNode)
        {
            var imbalanceType = ImbalanceType(imbalancedNode);

            if (imbalanceType == "LR")
            {
                // left sub-rotation
                imbalancedNode.Left = LeftRotation(imbalancedNode.Left);

                // right rotation
                imbalancedNode = RightRotation(imbalancedNode);
            }

            if (imbalanceType == "LL")
            {
                imbalancedNode = RightRotation(imbalancedNode);
            }

            if (imbalanceType == "RR")
            {
                imbalancedNode = LeftRotation(imbalancedNode);
            }

            if (imbalanceType == "RL")
            {
                // right sub-rotation
                imbalancedNode.Right = RightRotation(imbalancedNode.Right);

                // left rotation
                imbalancedNode = LeftRotation(imbalancedNode);
            }
        }

        private string ImbalanceType(ADSNode node)
        {
            if (node.LeftHeight > node.RightHeight)
            {
                node = node.Left;
                return node.LeftHeight > node.RightHeight ? "LL" : "LR";
            }
            else
            {
                node = node.Right;
                return node.LeftHeight > node.RightHeight ? "RL" : "RR";
            }
        }

        private ADSNode RightRotation(ADSNode imbalancedNode)
        {
            var tempNode = imbalancedNode.Left;
            imbalancedNode.Left = tempNode.Right;

            tempNode.Right = imbalancedNode;

            return tempNode;
        }

        private ADSNode LeftRotation(ADSNode imbalancedNode)
        {
            var tempNode = imbalancedNode.Right;
            imbalancedNode.Right = tempNode.Left;

            tempNode.Left = imbalancedNode;

            return tempNode;
        }

        // Print the tree in a particular order
        public void PrintTree(TraverseOrder order)
        {

            PrintRecursive(Root, order);
            Console.WriteLine();
        }

        private void PrintRecursive(ADSNode node, TraverseOrder order)
        {
            if (node == null)
            {
                return;
            }

            // used to output a tree to be loaded again without rebalancing
            if (order == TraverseOrder.PreOrder)
            {
                Console.Write(node.Key + " ");
            }

            PrintRecursive(node.Left, order);

            // used to print a tree for readability
            if (order == TraverseOrder.InOrder)
            {
                Console.Write(node.Key + " ");
            }

            PrintRecursive(node.Right, order);

            // used to print a tree to be deleted efficeintly
            if (order == TraverseOrder.PostOrder)
            {
                Console.Write(node.Key + " ");
            }
        }
    }
}

