
using HW1Revisit;

class HWOne
{
    //Step 1: Get a list of integer numbers from the user on A SINGLE LINE
    static void Main(string[] args)
    {
        BST sample = new BST();
        Console.WriteLine("Enter sequence of spaced numbers [0-100]");
        string numList = Console.ReadLine();
        string[] substrings = numList.Split(' ');
        foreach (var sub in substrings)
        {
            sample.Insert(Convert.ToInt32(sub));
        }

        sample.printTree();
    }
}