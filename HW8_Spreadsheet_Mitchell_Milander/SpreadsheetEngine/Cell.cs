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
#pragma warning disable SA1649 // File name should match first type name
    public abstract class Cell : INotifyPropertyChanged // Supress because I am unsure how to handle.
#pragma warning restore SA1649 // File name should match first type name
    {
        private readonly int rowIndex;
        private readonly int columnIndex;
        private string text;
        private string value;
        private uint bgColor;

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
            this.bgColor = 0xFFFFFFFF;
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
        /// Gets or Sets BGColor. Triggers event.
        /// </summary>
        public uint BGColor
        {
            get
            {
                return this.bgColor;
            }

            set
            {
                if (value != this.bgColor)
                {
                    this.bgColor = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.BGColor)));
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

        /// <summary>
        /// This allows only the spreadsheet class to change the value.
        /// </summary>
        /// <param name="value">if = then corresponds to formula.</param>
        internal void SetValue(string value)
        {
            if (this.value != value)
            {
                this.value = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Value)));
            }
        }
    }
}
