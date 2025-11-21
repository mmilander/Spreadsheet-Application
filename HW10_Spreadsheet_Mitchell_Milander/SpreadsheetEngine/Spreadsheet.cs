// <copyright file="Spreadsheet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using SpreadsheetEngine;

    /// <summary>
    /// This class serves as the container for 2D cells.
    /// </summary>
    public class Spreadsheet
    {
        private readonly ConcreteCell[,] arrayCell; // Creates multidemsnional rectangle array.
        private List<Tuple<int, int>> dependencyTable = new List<Tuple<int, int>>();
        private bool reevaluate;
        private Stack<UndoRedoCollection> undoList;
        private Stack<UndoRedoCollection> redoList;
        private int row;
        private int col;

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// </summary>
        /// <param name="row">Row dimension.</param>
        /// <param name="col">Column dimension.</param>
        public Spreadsheet(int row, int col)
        {
            this.row = row;
            this.col = col;
            this.reevaluate = false;
            this.undoList = new Stack<UndoRedoCollection>();
            this.redoList = new Stack<UndoRedoCollection>();

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
        /// Saves Spreadsheet data to an XML File.
        /// </summary>
        /// <param name="writeStream">Save destination.</param>
        public void Save(Stream writeStream)
        {
            XDocument srcTree = new XDocument(new XElement("spreadsheet"));
            for (int rowItr = 0; rowItr < this.row; rowItr++) // Go through each index and add cell.
                {
                    for (int colItr = 0; colItr < this.col; colItr++)
                    {
                         if (this.CellIsChanged(rowItr, colItr))
                         {
                            Cell tempCell = this.arrayCell[rowItr, colItr];

                            XElement element = new XElement(
                               "cell",
                               new XAttribute("name", this.GetCellName(rowItr, colItr)),
                               new XElement("bgcolor", tempCell.BGColor),
                               new XElement("text", tempCell.Text));
                            srcTree.Root.Add(element);
                         }
                    }
                }

            srcTree.Save(writeStream);
        }

        /// <summary>
        /// Reads XML data into Spreadsheet.
        /// </summary>
        /// <param name="readStream"> Retrieve destination.</param>
        public void Load(Stream readStream)
        {
            if (readStream == null)
            {
                throw new ArgumentNullException();
            }

            this.ClearSpreadsheet();
            XDocument srcTree = XDocument.Load(readStream);

            IEnumerable<XElement> elements =
            from el in srcTree.Root.Elements("cell") // Retreive only Cell elements
            select el;

            foreach (XElement el in elements)
            {
                string name = (string)el.Attribute("name");
                string bgcolor = (string)el.Element("bgcolor");
                string text = (string)el.Element("text");
                int tempRow = int.Parse(name.Substring(1)) - 1;  // Retrieve any digits after Column Char
                int tempCol = name[0] % 'A';
                this.arrayCell[tempRow, tempCol].BGColor = uint.Parse(bgcolor);
                this.arrayCell[tempRow, tempCol].Text = text;
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
        /// Executes and Adds a new command to the undoList.
        /// </summary>
        /// <param name="cmd">Command collection.</param>
        public void AddUndo(UndoRedoCollection cmd)
        {
            if (cmd.Count == 0)
            {
                throw new InvalidOperationException();
            }

            cmd.Execute();
            this.undoList.Push(cmd);
            this.redoList.Clear();
        }

        /// <summary>
        /// Undoes current command.
        /// </summary>
        public void Undo()
        {
            UndoRedoCollection undoTemp = this.undoList.Pop();
            undoTemp.Undo();
            this.redoList.Push(undoTemp);
        }

        /// <summary>
        /// Redoes previous command.
        /// </summary>
        public void Redo()
        {
            UndoRedoCollection redoTemp = this.redoList.Pop();
            redoTemp.Redo();
            this.undoList.Push(redoTemp);
        }

        /// <summary>
        /// Returns applicable info.
        /// </summary>
        /// <returns>String.</returns>
        public string GetUndoInfo()
        {
            if (this.undoList.Count == 0)
            {
                return string.Empty;
            }
            else
            {
                return "Undo " + this.undoList.Peek().Information;
            }
        }

        /// <summary>
        /// Returns applicable info.
        /// </summary>
        /// <returns>String.</returns>
        public string GetRedoInfo()
        {
            if (this.redoList.Count == 0)
            {
                return string.Empty;
            }
            else
            {
                return "Redo " + this.redoList.Peek().Information;
            }
        }

        private void Cell_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(Cell.Text))
            {
                this.CellPropertyChanged?.Invoke(sender, e);
                return;
            }

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
                bool badRef = false;
                string tempText = ((ConcreteCell)sender).Text;
                string expression = tempText.Substring(1);
                ExpressionTree tree;
                try
                {
                    tree = new ExpressionTree(expression, this.row, this.col);
                    List<string> list = tree.GetVariableList();

                    int senderRow = ((ConcreteCell)sender).RowIndex;
                    int senderCol = ((ConcreteCell)sender).ColumnIndex;

                    if (!this.dependencyTable.Contains(new Tuple<int, int>(senderRow, senderCol)))
                    {
                        this.dependencyTable.Add(new Tuple<int, int>(senderRow, senderCol)); // add Cell cordinates of listener.
                    }

                    foreach (string variable in list)
                    {
                        // Set value of variable.
                        char tempColChar = variable[0];
                        int tempRow = int.Parse(variable.Substring(1)) - 1;  // Retrieve any digits after Column Char
                        int tempCol = tempColChar % 'A';
                        Cell tempCell = this.GetCell(tempRow, tempCol);
                        tempCell.PropertyChanged -= this.Cell_PropertyChangedAgain;
                        tempCell.PropertyChanged += this.Cell_PropertyChangedAgain;
                        string tempValue = tempCell.Value;
                        double number;
                        if (double.TryParse(tempValue, out number))
                        {
                            if (variable.Equals(this.GetCellName(senderRow, senderCol)))
                            {
                                badRef = true;
                                ((ConcreteCell)sender).SetValue("!(self reference)");
                                break;
                            }
                            else
                            {
                                tree.SetVariable(variable, number);
                            }
                        }
                        else if (tempValue == string.Empty)
                        {
                            tree.SetVariable(variable, 0);
                        }
                        else
                        {
                            badRef = true;
                            ((ConcreteCell)sender).SetValue("!(bad reference)");
                            break;
                        }
                    }

                    if (!badRef)
                    {
                        badRef = false;
                        ((ConcreteCell)sender).SetValue(tree.Evaluate().ToString());
                    }
                }
                catch (ArgumentException)
                {
                    ((ConcreteCell)sender).SetValue("!(bad reference)");
                    this.CellPropertyChanged?.Invoke(sender, e);
                }
            }
        }

        private void Cell_PropertyChangedAgain(object sender, PropertyChangedEventArgs e)
        {
            int senderRow = ((ConcreteCell)sender).RowIndex;
            int senderCol = ((ConcreteCell)sender).ColumnIndex;
            bool badRef = false;
            if (this.reevaluate == true) // prevents circular handler trigggering
            {
                return;
            }

            this.reevaluate = true;
            foreach (Tuple<int, int> tuple in this.dependencyTable)
            {
                badRef = false;
                Cell listener = this.GetCell(tuple.Item1, tuple.Item2);
                if (listener.Text == string.Empty || listener.Text[0] != '=')
                {
                    continue;
                }

                ExpressionTree listenerExpression = new ExpressionTree(listener.Text.Substring(1), this.row, this.col);
                List<string> list = listenerExpression.GetVariableList();
                foreach (string variable in list)
                {
                    char tempColChar = variable[0];
                    int tempRow = int.Parse(variable.Substring(1)) - 1;  // Retrieve any digits after Column Char
                    int tempCol = tempColChar % 'A';
                    Cell tempCell = this.GetCell(tempRow, tempCol);
                    tempCell.PropertyChanged -= this.Cell_PropertyChangedAgain;
                    tempCell.PropertyChanged += this.Cell_PropertyChangedAgain;
                    string tempValue = tempCell.Value;
                    double number;
                    if (double.TryParse(tempValue, out number))
                    {
                        if (variable.Equals(this.GetCellName(listener.RowIndex, listener.ColumnIndex)))
                        {
                            badRef = true;
                            listener.SetValue("!(self reference)");
                            break;
                        }
                        else
                        {
                            listenerExpression.SetVariable(variable, number);
                        }
                    }
                    else if (tempValue == string.Empty)
                    {
                        listenerExpression.SetVariable(variable, 0);
                    }
                    else if (tempValue[0] == '!') // Already evaluated as an error
                    {
                        listener.SetValue("!(bad reference)");
                        badRef = true;
                        break;
                    }
                    else
                    {
                        listener.SetValue("!(bad reference)");
                        badRef = true;
                        this.reevaluate = false;
                        break;
                    }
                }

                if (!badRef)
                {
                    listener.SetValue(listenerExpression.Evaluate().ToString());
                }
            }

            this.reevaluate = false;
        }

        private bool CellIsChanged(int cellRow, int cellCol)
        {
            Cell tempCell = this.arrayCell[cellRow, cellCol];

            if (tempCell.Text != string.Empty)
            {
                return true;
            }

            if (tempCell.BGColor != 0xFFFFFFFF)
            {
                return true;
            }

            return false;
        }

        private string GetCellName(int cellRow, int cellCol)
        {
            string tempString = string.Empty;
            char tempChar = (char)(cellCol + 65);
            tempString += tempChar;
            tempString += (cellRow + 1).ToString();
            return tempString;
        }

        private void ClearSpreadsheet()
        {
            this.reevaluate = false; // Reset original settings, like Constructor does.
            this.undoList.Clear();
            this.redoList.Clear();
            this.dependencyTable.Clear();
            for (int rowItr = 0; rowItr < this.row; rowItr++)
            {
                for (int colItr = 0; colItr < this.col; colItr++)
                {
                    this.arrayCell[rowItr, colItr].PropertyChanged -= this.Cell_PropertyChangedAgain;
                    this.arrayCell[rowItr, colItr].Text = string.Empty;
                    this.arrayCell[rowItr, colItr].BGColor = 0xFFFFFFFF;
                }
            }
        }
    }
}
