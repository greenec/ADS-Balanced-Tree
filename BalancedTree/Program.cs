using System;
using System.Collections.Generic;

namespace BalancedTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new ADSTree();
            var values = new List<int> { 43, 18, 22, 9, 21, 6, 8, 20, 63, 50 };

            foreach (int value in values)
            {
                tree.Insert(value);
            }

            tree.PrintTree(TraverseOrder.InOrder);

            Console.ReadLine();
        }
    }
}
