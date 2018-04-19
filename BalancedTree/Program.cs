using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new ADSTree();
            // LR
            //var values = new List<int> { 43, 18, 22, 9, 21, 6, 8, 20, 63, 50 };

            // LL
            var values = new List<int> { 42, 22, 11 };

            // RR
            //var values = new List<int> { 11, 22, 44 };

            // RL
            //var values = new List<int> { 11, 22, 15 };

            foreach (int value in values)
            {
                tree.Insert(value);

                var imbalancedNode = tree.GetImbalancedNode(tree.GetRoot());

                if (imbalancedNode != null) // tree is not balanced
                {
                    Console.WriteLine(imbalancedNode.Key);

                    tree.Balance();

                    // TODO: remove this later, all values will be inserted
                    break;
                }
            }

            tree.PrintTree(TraverseOrder.InOrder);

            Console.WriteLine(tree.GetRoot().Height);
            Console.ReadLine();
        }
    }
}
