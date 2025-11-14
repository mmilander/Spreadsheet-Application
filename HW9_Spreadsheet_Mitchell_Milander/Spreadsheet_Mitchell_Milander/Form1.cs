// <copyright file="Form1.cs" company="Spreadsheet">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Spreadsheet_Mitchell_Milander
{

    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using SpreadsheetEngine;

    // Suppress so Dispose function still works
#pragma warning disable SA1601 // Partial elements should be documented
    public partial class SpreadsheetForm : Form
#pragma warning restore SA1601 // Partial elements should be documented
    {
        /// <summary>
        /// Spreadsheet Object.
        /// </summary>
        private Spreadsheet member;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadsheetForm"/> class.
        /// </summary>
        public SpreadsheetForm()
        {
            this.InitializeComponent();
            this.InitializeDataGrid();
            this.member = new Spreadsheet(50, 26);
            this.member.CellPropertyChanged += this.Cell_PropertyChanged;
            this.UpdateText();
        }

        private void Cell_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Cell tempCell = (Cell)sender;
            if (e.PropertyName == nameof(Cell.Value))
            {
                this.dataGridView1.Rows[tempCell.RowIndex].Cells[tempCell.ColumnIndex].Value = tempCell.Value;
            }

            if (e.PropertyName == nameof(Cell.BGColor))
            {
                Color tempColor = Color.FromArgb((int)tempCell.BGColor);
                this.dataGridView1.Rows[tempCell.RowIndex].Cells[tempCell.ColumnIndex].Style.BackColor = tempColor;
            }
        }

        private void Spreadsheet_Load(object sender, EventArgs e)
        {
            // Fill in Details through Semester
        }

        private void InitializeDataGrid()
        {
            this.dataGridView1.Columns.Clear();

            // Create Columns A-Z
            for (char i = 'A'; i <= 'Z'; i++) // iterativly create columns
            {
                this.dataGridView1.Columns.Add(i + string.Empty, i + string.Empty);
            }

            // Create Rows 1-50
            for (int i = 0; i < 50; i++)
            {
                this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            Cell tempCell = this.member.GetCell(e.RowIndex, e.ColumnIndex);
            this.dataGridView1.Rows[tempCell.RowIndex].Cells[tempCell.ColumnIndex].Value = tempCell.Text;
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Cell tempCell = this.member.GetCell(e.RowIndex, e.ColumnIndex);
            string tempValue = this.dataGridView1.Rows[tempCell.RowIndex].Cells[tempCell.ColumnIndex].Value.ToString();
            UndoRedoCollection newCollection = new UndoRedoCollection("text change");
            ChangeTextCommand changeText = new ChangeTextCommand(this.member, tempCell.RowIndex, tempCell.ColumnIndex, tempCell.Text, tempValue);
            newCollection.AddCmd(changeText);
            this.member.AddUndo(newCollection);
            this.UpdateText();
        }

        private void ChangeBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog myColor = new ColorDialog();
            myColor.AllowFullOpen = true;
            UndoRedoCollection newCollection = new UndoRedoCollection("background color change");
            if (myColor.ShowDialog() == DialogResult.OK)
            {
                foreach (DataGridViewCell cell in this.dataGridView1.SelectedCells)
                {
                    Cell tempCell = this.member.GetCell(cell.RowIndex, cell.ColumnIndex);
                    ChangeBackgroundCommand changeColor = new ChangeBackgroundCommand(this.member, cell.RowIndex, cell.ColumnIndex, tempCell.BGColor, (uint)myColor.Color.ToArgb());
                    newCollection.AddCmd(changeColor);
                }

                this.member.AddUndo(newCollection);
                this.UpdateText();
            }
        }

        private void UpdateText()
        {
            string tempUndoText = this.member.GetUndoInfo();
            if (tempUndoText == string.Empty)
            {
                this.undoToolStripMenuItem.Enabled = false;
            }
            else
            {
                this.undoToolStripMenuItem.Text = tempUndoText;
                this.undoToolStripMenuItem.Enabled = true;
            }

            string tempRedoText = this.member.GetRedoInfo();
            if (tempRedoText == string.Empty)
            {
                this.redoToolStripMenuItem.Enabled = false;
            }
            else
            {
                this.redoToolStripMenuItem.Text = tempRedoText;
                this.redoToolStripMenuItem.Enabled = true;
            }
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.member.Undo();
            this.UpdateText();
        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.member.Redo();
            this.UpdateText();
        }

        private void loadSpreadsheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.InitialDirectory = "c:\\";
            this.openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            this.openFileDialog1.FilterIndex = 2;
            this.openFileDialog1.RestoreDirectory = true;

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Read the contents of the file into a stream.
                using (var fileStream = this.openFileDialog1.OpenFile())
                {
                    this.member.Load(fileStream);
                }
            }
        }

        private void saveSpreadsheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (var fileStream = saveFileDialog1.OpenFile())
                {
                    this.member.Save(fileStream);
                }
            }
        }
    }
}
