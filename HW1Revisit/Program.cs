namespace HW1Revisit;

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

        Console.Write("\nTree Contents: ");
        sample.printTree();
        Console.WriteLine("\nTree Statistics");
        Console.WriteLine(" Number of nodes: " + sample.getCount());
        Console.WriteLine(" Number of levels: " + (sample.getHeight()+1));
        Console.WriteLine(" Minimum number of levels that a tree with " + 
                        sample.getCount() + " nodes could have: " + 
                        (Math.Floor(Math.Log(sample.getCount(), 2))+1));

    }
}