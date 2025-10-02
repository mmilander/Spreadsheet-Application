namespace Spreadsheet_Mitchell_Milander
{
    partial class Spreadsheet
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            A = new DataGridViewTextBoxColumn();
            B = new DataGridViewTextBoxColumn();
            C = new DataGridViewTextBoxColumn();
            D = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { A, B, C, D });
            dataGridView1.Location = new Point(260, 107);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(360, 225);
            dataGridView1.TabIndex = 0;
            // 
            // A
            // 
            A.HeaderText = "A";
            A.MinimumWidth = 8;
            A.Name = "A";
            A.Width = 150;
            // 
            // B
            // 
            B.HeaderText = "B";
            B.MinimumWidth = 8;
            B.Name = "B";
            B.Width = 150;
            // 
            // C
            // 
            C.HeaderText = "C";
            C.MinimumWidth = 8;
            C.Name = "C";
            C.Width = 150;
            // 
            // D
            // 
            D.HeaderText = "D";
            D.MinimumWidth = 8;
            D.Name = "D";
            D.Width = 150;
            // 
            // Spreadsheet
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Name = "Spreadsheet";
            Text = "Form1";
            Load += Spreadsheet_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn A;
        private DataGridViewTextBoxColumn B;
        private DataGridViewTextBoxColumn C;
        private DataGridViewTextBoxColumn D;
    }
}
