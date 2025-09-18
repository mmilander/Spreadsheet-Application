// See https://aka.ms/new-console-template for more information

using System.Numerics;
using System.Text;

class FibonacciTextReader : System.IO.TextReader
{
    public int maxCount;
    public int trackerCount;
    public BigInteger prev;
    public BigInteger curr;

    public FibonacciTextReader(int maxLineCount)
    {
        maxCount = maxLineCount;
        trackerCount = 0;
        prev = 1;
        curr = 0;
    }


    /// <summary>
    /// Override's the original ReadLine() method from TextReader
    /// </summary>
    /// <returns></returns>
    public override string ReadLine()
    {
        if (trackerCount == maxCount)
        {
            return null;
        }
        else if (trackerCount == 0)
        {
            trackerCount++;
            return "0";
        }
        else if (trackerCount == 1)
        {
            trackerCount++;
            return "1";
        }
        else
        {
            trackerCount++;
            BigInteger tempFibNum = curr;
            curr = prev + curr;
            prev = tempFibNum;
            string result = curr.ToString();
            return result;
        }
    }

    /// <summary>
    /// Override's the original ReadToEnd() method from TextReader
    /// </summary>
    /// <returns></returns>
    public override string ReadToEnd()
    {
        StringBuilder sb = new StringBuilder();
        string store = ReadLine();
        while (store != null)
        {
            sb.Append(store);
            store = ReadLine(); 
        }
        return sb.ToString();
    }
}

