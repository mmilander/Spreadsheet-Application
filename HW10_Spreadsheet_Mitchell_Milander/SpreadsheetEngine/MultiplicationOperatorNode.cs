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
        public override double Evaluate()
        {
            return this.Left.Evaluate() * this.Right.Evaluate();
        }

        public override char Operator
        {
            get
            {
                return '*';
            }
        }

        public override int Precedence
        {
            get
            {
                return 3;
            }
        }

        public override string Associativity
        {
            get
            {
                return "left";
            }
        }
    }
}
