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
        private Dictionary<string, double> variables;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.
        /// </summary>
        /// <param name="name">Name value that the node will store. </param>
        /// <param name ="variables">Reference to dictionary.</param>
        public VariableNode(string name, ref Dictionary<string, double> variables)
        {
            this.name = name;
            this.variables = variables;
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
        public override double Evaluate()
        {
            if (this.variables.ContainsKey(this.name))
            {
                return this.variables[this.name];
            }

            return 0.0;
        }
    }
}
