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
            public int Cardinality;  //  Increment each time duplicates are added
            public int Height;  // Height of this node
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
            /*if(Root == null)
            {
                Root = new ADSNode
                {
                    Key = value,
                    Height = 0,
                    Cardinality = 1
                };

                return;
            }*/

            ADSNode current = Root;

            while(current != null)
            {
                if(value <= Root.Key)
                {
                    current = Root.Left;
                }
                else
                {
                    current = Root.Right;
                }
            }

            current = new ADSNode
            {
                Key = value,
                Height = 0,
                Cardinality = 1
            };
        }

        // Print the tree in a particular order
        public void PrintTree(TraverseOrder order)
        {

        }
    }
}

