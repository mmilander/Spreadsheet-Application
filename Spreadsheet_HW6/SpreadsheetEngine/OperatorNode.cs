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
        /// <summary>
        /// Left branch.
        /// </summary>
#pragma warning disable SA1401 // Fields should be private
        protected Node left; // The TA Chii said these fields should be protected.
#pragma warning disable SA1401 // Fields should be private

        /// <summary>
        /// Right branch.
        /// </summary>
#pragma warning disable SA1401 // Fields should be private
        protected Node right; // The TA Chii said these fields should be protected.
#pragma warning restore SA1401 // Fields should be private

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
