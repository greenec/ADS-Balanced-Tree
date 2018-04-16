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

                if (imbalancedNode != null) // tree is not balanced
                {
                    Console.WriteLine(imbalancedNode.Key);
                    var imbalanceType = tree.ImbalanceType(imbalancedNode);

                    // TODO: properly implement all rotation cases
                    if(imbalanceType == "LR")
                    {
                        // do a left sub-rotation
                        imbalancedNode.Left.Right.Left = imbalancedNode.Left;
                        imbalancedNode.Left = imbalancedNode.Left.Right;

                        //imbalancedNode.Left.Left = null;

                        // do a right rotation
                        if (tree.GetRoot() == imbalancedNode) // if the root is imbalanced
                        {
                            //tree.SetRoot(imbalancedNode.Left);
                        }

                        //tree.GetRoot().Right = tempNode;
                    }

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
