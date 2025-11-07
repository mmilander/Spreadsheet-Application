// <copyright file="ChangeBackgroundCommand.cs" company="Background Command">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Offers command to change background color.
    /// </summary>
    internal class ChangeBackgroundCommand : ICommand
    {
        private Spreadsheet receiver;
        private Cell cell;
        private int rowIndex;
        private int colIndex;
        private uint oldColor;
        private uint newColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeBackgroundCommand"/> class.
        /// </summary>
        /// <param name="receiver">Spreadsheet object.</param>
        /// <param name="rowIndex">index of row.</param>
        /// <param name="colIndex">index of col.</param>
        /// <param name="oldColor">type of previous color.</param>
        /// <param name="newColor">type of new color.</param>
        public ChangeBackgroundCommand(Spreadsheet receiver, int rowIndex, int colIndex, uint oldColor, uint newColor)
        {
            this.receiver = receiver;
            this.rowIndex = rowIndex;
            this.colIndex = colIndex;
            this.cell = this.receiver.GetCell(this.rowIndex, this.colIndex);
            this.oldColor = oldColor;
            this.newColor = newColor;
        }

        /// <summary>
        /// Implements Interface's Execute().
        /// </summary>
        public void Execute()
        {
            this.cell.BGColor = this.newColor;
        }

        /// <summary>
        /// Implements Interface's Undo().
        /// </summary>
        public void Undo()
        {
            this.cell.BGColor = this.oldColor;
        }

        /// <summary>
        /// Implements Interface's Redo().
        /// </summary>
        public void Redo()
        {
            this.cell.BGColor = this.newColor;
        }
    }
}
