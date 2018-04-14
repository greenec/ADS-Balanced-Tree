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
            var values = new List<int> { 43, 18, 22, 9, 21, 6, 8, 20, 63, 50 };

            foreach(int value in values)
            {
                tree.Insert(value);

                var imbalancedNode = tree.GetImbalancedNode(tree.GetRoot());

                if (imbalancedNode != null)
                {
                    Console.WriteLine(imbalancedNode.Key);
                    break;
                }
            }

            tree.PrintTree(TraverseOrder.InOrder);

            Console.WriteLine(tree.GetRoot().Height);
            Console.ReadLine();
        }
    }
}
