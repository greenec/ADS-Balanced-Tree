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

            tree.Insert(43);
            tree.Insert(18);
            tree.Insert(22);
            tree.Insert(9);
            tree.Insert(21);
            tree.Insert(6);
            tree.Insert(8);
            tree.Insert(20);
            tree.Insert(63);
            tree.Insert(50);

            tree.PrintTree(TraverseOrder.InOrder);

            Console.WriteLine(tree.RootHeight());

            Console.ReadLine();
        }
    }
}
