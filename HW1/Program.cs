// See https://aka.ms/new-console-template for more information


class HWOne
{
    //Step 1: Get a list of integer numbers from the user on A SINGLE LINE
    static void Main(string[] args)
    {
        string numList = Console.ReadLine();
        string[] substrings = numList.Split(' ');
        foreach (var sub in substrings)
        {
            Console.WriteLine(sub);
        }
    }
}