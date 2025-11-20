// <copyright file="SubtractionOperatorNode.cs" company="SubtractionNodeOperation">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Node that handles subtraction.
    /// </summary>
    internal class SubtractionOperatorNode : OperatorNode
    {
        /// <summary>
        /// Gets Operator;
        /// </summary>
        public override char Operator
        {
            get
            {
                return '-';
            }
        }

        /// <summary>
        /// Gets Precedence.
        /// </summary>
        public override int Precedence
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// Gets Associativity.
        /// </summary>
        public override string Associativity
        {
            get
            {
                return "left";
            }
        }

        /// <summary>
        /// Overriden Evaluate Class.
        /// </summary>
        /// <param name="variables">Dictionary Object.</param>
        /// <returns>double.</returns>
        public override double Evaluate()
        {
            return this.Left.Evaluate() - this.Right.Evaluate();
        }
    }
}
