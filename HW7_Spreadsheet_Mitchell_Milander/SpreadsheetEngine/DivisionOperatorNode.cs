// <copyright file="DivisionOperatorNode.cs" company="DivisionNodeOperation">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Node that handles division.
    /// </summary>
    internal class DivisionOperatorNode : OperatorNode
    {
        /// <summary>
        /// Overriden Evaluate Class.
        /// </summary>
        /// <param name="variables">Dictionary Object.</param>
        /// <returns>double.</returns>
        public override double Evaluate()
        {
            return this.Left.Evaluate() / this.Right.Evaluate();
        }
    }
}
