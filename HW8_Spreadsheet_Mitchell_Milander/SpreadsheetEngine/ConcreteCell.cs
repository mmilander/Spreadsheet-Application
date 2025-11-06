// <copyright file="ConcreteCell.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Create a concrete cell.
    /// </summary>
    internal class ConcreteCell : Cell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConcreteCell"/> class.
        /// </summary>
        /// <param name="row">Row index.</param>
        /// <param name="col">Column index.</param>
        public ConcreteCell(int row, int col)
            : base(row, col)
        {
            // style cop doesn't want blank line.
        }
    }
}
