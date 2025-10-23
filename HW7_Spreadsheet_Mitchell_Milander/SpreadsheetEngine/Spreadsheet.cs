// <copyright file="Spreadsheet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    using System;
    using System.ComponentModel;
    using SpreadsheetEngine;

    /// <summary>
    /// This class serves as the container for 2D cells.
    /// </summary>
    public class Spreadsheet
    {
        private readonly ConcreteCell[,] arrayCell; // Creates multidemsnional rectangle array.

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// </summary>
        /// <param name="row">Row dimension.</param>
        /// <param name="col">Column dimension.</param>
        public Spreadsheet(int row, int col)
        {
            if (row < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(row), "Out of range");
            }

            if (col < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(col), "Out of range");
            }

            this.arrayCell = new ConcreteCell[row, col];
            for (int rowItr = 0; rowItr < row; rowItr++) // Go through each index and add cell.
            {
                for (int colItr = 0; colItr < col; colItr++)
                {
                    this.arrayCell[rowItr, colItr] = new ConcreteCell(rowItr, colItr);
                    this.arrayCell[rowItr, colItr].PropertyChanged += this.Cell_PropertyChanged;
                }
            }
        }

        /// <summary>
        /// Creates a CellPropertyChangedEvent.
        /// This will be triggered anytime a cell's contents alter state.
        /// </summary>
        public event PropertyChangedEventHandler? CellPropertyChanged;

        /// <summary>
        /// Gets Row Count.
        /// </summary>
        public int RowCount
        {
            get
            {
                return this.arrayCell.GetLength(0);
            }
        }

        /// <summary>
        /// Gets Column Count.
        /// </summary>
        public int ColumnCount
         {
            get
            {
                return this.arrayCell.GetLength(1);
            }
         }

        /// <summary>
        /// Obtains cell at input coordinates.
        /// </summary>
        /// <param name="rowIndex">location.</param>
        /// <param name="colIndex">location2.</param>
        /// <returns>Cell.</returns>
        public Cell GetCell(int rowIndex, int colIndex)
        {
            if (rowIndex < 0 || rowIndex >= this.arrayCell.GetLength(0) || colIndex < 0
                || colIndex >= this.arrayCell.GetLength(1))
            {
                return null;
            }

            return this.arrayCell[rowIndex, colIndex];
        }

        /// <summary>
        /// Updates the cell text for the UI upon being changed.
        /// </summary>
        /// <param name="rowIndex">Row position.</param>
        /// <param name="colIndex">Column position.</param>
        /// <param name="text">Input.</param>
        public void CellEndHelper(int rowIndex, int colIndex, string text)
        {
            this.arrayCell[rowIndex, colIndex].Text = text;
        }

        /// <summary>
        /// This demo's the current part of the project.
        /// </summary>
        public void Demo()
        {

            this.arrayCell[0, 0].Text = "10";
            this.arrayCell[1, 0].Text = "5";
            this.arrayCell[2, 0].Text = "6";
            this.arrayCell[0, 1].Text = "=A1";
           /* Random genRan = new Random();
            int ranRow = 0;
            int ranCol = 0;

            for (int i = 0; i < this.RowCount; i++)
            {
                ranRow = genRan.Next(this.RowCount);
                ranCol = genRan.Next(this.ColumnCount);
                this.arrayCell[ranRow, ranCol].Text = "Fearless";
            }

            for (int i = 0; i < this.RowCount; i++)
            {
                this.arrayCell[i, 1].Text = "This is Cell B" + (i + 1).ToString();
                this.arrayCell[i, 0].Text = "=B" + (i + 1).ToString();
            }*/
        }

        /// <summary>
        /// This demo's the current part of the project.
        /// </summary>
       /* public void DisplayValues()
        {
            for (int i = 0; i < this.RowCount; i++)
            {
                for (int i = 0; i < this.RowCount; i++)
            }
        }*/

        private void Cell_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (((ConcreteCell)sender).Text == string.Empty)
            {
               ((ConcreteCell)sender).SetValue(string.Empty);
            }
            else if (((ConcreteCell)sender).Text[0] != '=')
            {
                ((ConcreteCell)sender).SetValue(((ConcreteCell)sender).Text);
            }
            else
            {
                string tempText = ((ConcreteCell)sender).Text;
                char tempColChar = tempText[1]; // skip =
                int tempRow = int.Parse(tempText.Substring(2)) - 1;  // Retrieve any digits after Column Char
                int tempCol = tempColChar % 'A';
                string tempValue = this.GetCell(tempRow, tempCol).Value;
                ((ConcreteCell)sender).SetValue(tempValue);
            }

            this.CellPropertyChanged?.Invoke(sender, e);
        }
    }
}
