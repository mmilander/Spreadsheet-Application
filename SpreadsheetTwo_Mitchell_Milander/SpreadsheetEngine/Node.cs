// <copyright file="Node.cs" company="AbstractNodeClass">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Asbtract node class.
    /// </summary>
    /// 
    internal abstract class Node
    {
        /// <summary>
        /// Provides Evaluate framework for child classes.
        /// </summary>
        /// <param name="variables">Dictionary Object.</param>
        /// <returns>double.</returns>
        public abstract double Evaluate(Dictionary<string, double> variables);
    }
}
