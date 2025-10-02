// <copyright file="Spreadsheet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Spreadsheet_Mitchell_Milander
{
    using SpreadsheetEngine;
    /// <summary>
    /// This class serves as the container for 2D cells.
    /// </summary>
    public class Spreadsheet
    {
       private readonly ConcreteCell[,] arrayCell;

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// </summary>
        /// <param name="row">Row dimension</param>
        /// <param name="col">Column dimension</param>
       public Spreadsheet(int row, int col)
        {
            this.arrayCell = new ConcreteCell[row,col];
            for (int rowItr = 0; rowItr < row; rowItr++)
            {
                for (int colItr = 0; colItr < col; colItr++)
                {
                    this.arrayCell[rowItr, colItr] = new ConcreteCell(rowItr, colItr);
                }
            }
           // arrayCell = new Cell [row][col];
        }
    }
}
