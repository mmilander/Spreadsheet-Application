// <copyright file="MultiplicationOperatorNode.cs" company="MultiplicationNodeOperation">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Node that handles multiplication.
    /// </summary>
    internal class MultiplicationOperatorNode : OperatorNode
    {
        /// <summary>
        /// Overriden Evaluate Class.
        /// </summary>
        /// <param name="variables">Dictionary Object.</param>
        /// <returns>double.</returns>
        public override double Evaluate(Dictionary<string, double> variables)
        {
            return this.Left.Evaluate(variables) * this.Right.Evaluate(variables);
        }
    }
}
