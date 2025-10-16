// <copyright file="OperatorNode.cs" company="OperatorClassNode">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Operator Class Node.
    /// </summary>
    internal abstract class OperatorNode : Node
    {
        private Node left;
        private Node right;

        /// <summary>
        /// Gets or Sets Left node.
        /// </summary>
        public Node Left
        {
            get
            {
                return this.left;
            }

            set
            {
                this.left = value;
            }
        }

        /// <summary>
        /// Gets or Sets right node.
        /// </summary>
        public Node Right
        {
            get
            {
                return this.right;
            }

            set
            {
                this.right = value;
            }
        }
    }
}
