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

        /// <summary>
        /// This determines the precedence of a particular operator.
        /// </summary>
        /// <param name="lhs">Character input.</param>
        /// <param name="rhs">Character input for rhs.</param>
        /// <returns>OperatorNode.</returns>
        /// <exception cref="ArgumentException">Invalid Operator.</exception>
        public int Precedence(char lhs, char rhs)
        {
            int lhsValue = 0;
            int rhsValue = 0;
            switch (lhs)
            {
                case '/':
                    lhsValue = 3;
                    break;
                case '*':
                    lhsValue = 3;
                    break;
                case '+':
                    lhsValue = 1;
                    break;
                case '-':
                    lhsValue = 1;
                    break;
                default:
                    lhsValue = 0;
                    break;
            }

            switch (rhs)
            {
                case '/':
                    rhsValue = 3;
                    break;
                case '*':
                    rhsValue = 3;
                    break;
                case '+':
                    rhsValue = 1;
                    break;
                case '-':
                    rhsValue = 1;
                    break;
                default:
                    rhsValue = 0;
                    break;
            }

            if (lhsValue < rhsValue)
            {
                return 0; // lhs has lower precedence.
            }
            else if (lhsValue == rhsValue)
            {
                return 1; // lhs & rhs have same precedence.
            }
            else
            {
                return 2; // lhs has greater precedence.
            }
        }
    }
}
