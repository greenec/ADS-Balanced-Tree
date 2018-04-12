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
        private ADSNode root;

        public sealed class ADSNode
        {
            public ADSNode left;
            public ADSNode right;
            public int key;
            public int cardinality;  //  Increment each time duplicates are added
            public int height;  // Height of this node
        }

        public ADSTree()
        {
            root = null;
        }

        // Return the node where value is located
        public ADSNode Find(int value)
        {
            return null;
        }

        // Inserts a node into the tree and maintains it's balance
        public void Insert(int value)
        {

        }

        // Print the tree in a particular order
        public void PrintTree(TraverseOrder order)
        {

        }
    }
}

