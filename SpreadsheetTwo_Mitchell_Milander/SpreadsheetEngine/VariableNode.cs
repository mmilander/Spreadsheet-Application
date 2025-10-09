// <copyright file="VariableNode.cs" company="VariableNodeClass">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Variable Node Class.
    /// </summary>
    internal class VariableNode : Node
    {
        private string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.
        /// </summary>
        /// <param name="name">Name value that the node will store. </param>
        public VariableNode(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Gets or Sets name field.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        /// <summary>
        /// VariableNode Evaluate Method.
        /// </summary>
        /// <param name="variables">Dictionary Object.</param>
        /// <returns>doublevalue.</returns>
        public override double Evaluate(Dictionary<string, double> variables)
        {
            if (variables.ContainsKey(this.name))
            {
                return variables[this.name];
            }

            return 0.0;
        }
    }
}
