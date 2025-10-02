// <copyright file="FibonacciTextReader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Numerics;
using System.Text;

/// <summary>
/// This class determines the Fibonacci sequence based
/// on max number and overrides TextReader functions to allow
/// file integration.
/// </summary>
public class FibonacciTextReader : System.IO.TextReader
{
    private readonly int maxCount;
    private int trackerCount;
    private BigInteger prev;
    private BigInteger curr;

    /// <summary>
    /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
    /// </summary>
    /// <param name="maxLineCount">
    /// The paramter is the max number of fib elements.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// This exception is thrown if the input is out of range.
    /// </exception>
    public FibonacciTextReader(int maxLineCount)
    {
        if (maxLineCount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxLineCount), "Out of range");
        }
        else
        {
            this.maxCount = maxLineCount;
            this.trackerCount = 0;
            this.prev = 0;
            this.curr = 1;
        }
    }

    /// <summary>
    /// Override's the original ReadLine() method from TextReader.
    /// </summary>
    /// <returns>
    /// string.
    /// </returns>
    public override string ReadLine()
    { // non-recursive Fibonacci Algorithm
        if (this.trackerCount == this.maxCount)
        {
            return null;
        }
        else if (this.trackerCount == 0)
        {
            this.trackerCount++;
            return "0";
        }
        else if (this.trackerCount == 1)
        {
            this.trackerCount++;
            return "1";
        }
        else
        {
            this.trackerCount++;
            BigInteger tempFibNum = this.curr;
            this.curr = this.prev + this.curr;
            this.prev = tempFibNum;
            string result = this.curr.ToString();
            return result;
        }
    }

    /// <summary>
    /// Override's the original ReadToEnd() method from TextReader.
    /// </summary>
    /// <returns>
    /// string
    /// </returns>
    public override string ReadToEnd()
    {
        int lineNum = 1;
        StringBuilder sb = new StringBuilder();
        string store = this.ReadLine();
        while (store != null)
        {
            sb.Append(lineNum.ToString());
            sb.Append(": ");
            sb.Append(store);
            store = this.ReadLine();
            sb.AppendLine();
            lineNum++;
        }

        return sb.ToString();
    }
}