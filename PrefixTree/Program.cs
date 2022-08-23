using PrefixTree.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefixTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var prefixTree = new Tree<int>();

            prefixTree.Add("привет", 50);
            prefixTree.Add("прикол", 150);
            prefixTree.Add("мир", 100);
            prefixTree.Add("мирный", 200);

            prefixTree.Remove("мир");

            Console.WriteLine(prefixTree.TrySearch("приветик"));
            Console.WriteLine(prefixTree.TrySearch("привет"));
            Console.WriteLine(prefixTree.TrySearch("мир"));
            Console.WriteLine(prefixTree.TrySearch("мирный"));
            Console.WriteLine(prefixTree.TrySearch("прикол"));

            Console.ReadLine();
        }
    }
}
