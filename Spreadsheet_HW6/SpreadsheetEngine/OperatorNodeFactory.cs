// <copyright file="OperatorNodeFactory.cs" company="OperatorNodeFactory">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// This implements the factory method.
    /// </summary>
    internal class OperatorNodeFactory
    {
        /// <summary>
        /// This creates a type OperatorNode type depending on input.
        /// </summary>
        /// <param name="op">Character input.</param>
        /// <returns>OperatorNode.</returns>
        /// <exception cref="ArgumentException">Invalid Operator.</exception>
        public OperatorNode CreateOperatorNode(char op)
        {
            switch (op)
            {
                case '+':
                    return new AdditionOperatorNode();
                case '-':
                    return new SubtractionOperatorNode();
                case '*':
                    return new MultiplicationOperatorNode();
                case '/':
                    return new DivisionOperatorNode();
                default:
                    throw new ArgumentException("Invalid Operator");
            }
        }
    }
}
