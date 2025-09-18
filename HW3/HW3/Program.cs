// See https://aka.ms/new-console-template for more information

class FibonacciTextReader : System.IO.TextReader
{
    public int max;
    public FibonacciTextReader(int maxLineCount)
    {
        max = maxLineCount;
    }


    /// <summary>
    /// Override's the original ReadLine() method from TextReader
    /// </summary>
    /// <returns></returns>
    public override string ReadLine()
    {

        return "r";
    }

    /// <summary>
    /// Override's the original ReadToEnd() method from TextReader
    /// </summary>
    /// <returns></returns>
    public override string ReadToEnd()
    {
        return "r";
    }
}

