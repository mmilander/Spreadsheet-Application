// <copyright file="Cell.cs" company="SpreadsheetEngine">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    using System.ComponentModel;

    /// <summary>
    /// This is the Abstract framework for the Cell Class.
    /// </summary>
    ///
    public abstract class Cell : INotifyPropertyChanged
    {
        /// <summary>
        /// Fields for Cell Class.
        /// </summary>
        private readonly int rowIndex;
        private readonly int columnIndex;
        private string text; // Directions say protected

        /// <summary>
        /// Fields for Cell Class.
        /// </summary>
        protected string value; // Directions say protected

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// The Constructor for Cell Class.
        /// </summary>
        /// <param name="rowIndex">Index of row.</param>
        /// <param name="columnIndex">Index of Column.</param>
        public Cell(int rowIndex, int columnIndex)
        {
            this.rowIndex = rowIndex;
            this.columnIndex = columnIndex;
            this.text = string.Empty;
            this.value = string.Empty;
        }

        /// <summary>
        /// Property for event.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Gets RowIndex field.
        /// </summary>
        public int RowIndex
        {
            get { return this.rowIndex; }
        }

        /// <summary>
        /// Gets ColumnIndex.
        /// </summary>
        public int ColumnIndex
        {
            get { return this.columnIndex; }
        }

        /// <summary>
        /// Gets or Sets text. Triggers event.
        /// </summary>
        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if (value != this.text)
                {
                    this.text = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Text)));
                }
            }
        }

        /// <summary>
        /// Gets value.
        /// </summary>
        public string Value
        {
            get
            {
                return this.value;
            }
        }
    }
}
