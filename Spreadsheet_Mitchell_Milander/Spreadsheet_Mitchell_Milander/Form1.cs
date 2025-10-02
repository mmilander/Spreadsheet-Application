// <copyright file="Form1.cs" company="Spreadsheet">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Spreadsheet_Mitchell_Milander
{
// Suppress so Dispose function still works
#pragma warning disable SA1601 // Partial elements should be documented
    public partial class SpreadsheetForm : Form
#pragma warning restore SA1601 // Partial elements should be documented
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadsheetForm"/> class.
        /// </summary>
        public SpreadsheetForm()
        {
            this.InitializeComponent();
            this.InitializeDataGrid();
        }

        private void Spreadsheet_Load(object sender, EventArgs e)
        {
            // Fill in Details through Semester
        }

        private void InitializeDataGrid()
        {
            this.dataGridView1.Columns.Clear();
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
    }
}
