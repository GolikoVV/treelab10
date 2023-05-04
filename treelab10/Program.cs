using System;
using treelab10;

class Program
{
    static void Main(string[] args)
    {
        Tree<int> tree = new Tree<int>();
        tree.Add(4);
        tree.Add(2);
        tree.Add(1);
        tree.Add(3);
        tree.Add(6);
        tree.Add(5);
        tree.Add(7);

        foreach (int value in tree)
        {
            Console.WriteLine(value);
        }
    }
}