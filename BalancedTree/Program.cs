using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BalancedTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new ADSTree<int>();
            var values = new List<int> { 43, 18, 22, 9, 21, 6, 8, 20, 63, 50 };

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 1000000; i++)
            {
                tree.Insert(i);
            }

            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            
            var searchNode = tree.Find(737373);

            tree.PrintTree(TraverseOrder.InOrder);

            Console.ReadLine();
        }
    }
}
