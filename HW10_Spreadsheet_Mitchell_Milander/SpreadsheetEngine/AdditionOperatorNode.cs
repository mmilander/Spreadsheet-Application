// <copyright file="AdditionOperatorNode.cs" company="AdditionNodeOperation">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Node that handles Addition.
    /// </summary>
    internal class AdditionOperatorNode : OperatorNode
    {
        /// <summary>
        /// Overriden Evaluate Class.
        /// </summary>
        /// <param name="variables">Dictionary Object.</param>
        /// <returns>double.</returns>
        public override double Evaluate()
        {
            return this.Left.Evaluate() + this.Right.Evaluate();
        }

        public override char Operator
        {
            get
            {
                return '+';
            }
        }

        public override int Precedence
        {
            get
            {
                return 1;
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
