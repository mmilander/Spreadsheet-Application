// <copyright file="ChangeTextCommand.cs" company="Text Command">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Offers command to change background text.
    /// </summary>
    internal class ChangeTextCommand : ICommand
    {
        private Spreadsheet receiver;
        private int rowIndex;
        private int colIndex;
        private string newText;
        private string oldText;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeTextCommand"/> class.
        /// </summary>
        /// <param name="receiver">Spreadsheet object.</param>
        /// <param name="rowIndex">index of row.</param>
        /// <param name="colIndex">index of column.</param>
        /// <param name="oldText">type of old text.</param>
        /// <param name="newText">type of new text.</param>
        public ChangeTextCommand(Spreadsheet receiver, int rowIndex, int colIndex, string oldText, string newText)
        {
            this.receiver = receiver;
            this.rowIndex = rowIndex;
            this.colIndex = colIndex;
            this.oldText = oldText;
            this.newText = newText;
        }

        /// <summary>
        /// Implements Interface's Execute().
        /// </summary>
        public void Execute()
        {
            this.receiver.CellEndHelper(this.rowIndex, this.colIndex, this.newText);
        }

        /// <summary>
        /// Implements Interface's Undo().
        /// </summary>
        public void Undo()
        {
            this.receiver.CellEndHelper(this.rowIndex, this.colIndex, this.oldText);
        }

        /// <summary>
        /// Implements Interface's Redo().
        /// </summary>
        public void Redo()
        {
            this.receiver.CellEndHelper(this.rowIndex, this.colIndex, this.newText);
        }
    }
}
