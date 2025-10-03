namespace HW2
{
    partial class Form1
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
         
            textBox = new TextBox();
            SuspendLayout();
     
            // 
            // textBox2
            // 
            textBox.Dock = DockStyle.Fill;
            textBox.Multiline = true;
            textBox.Location = new Point(0, 0);
            textBox.Name = "textBox";
            textBox.Size = new Size(1226, 31);
            textBox.TabIndex = 1;
            textBox.Text = "Mitchell Milander - 0REDACTED";
            textBox.TextChanged += textBoxTextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1226, 751);
            Controls.Add(textBox);
      
            Name = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        //private TextBox textBox1;
        private TextBox textBox;
        public void setTextBox(string text)
        {
            textBox.Text = text;
        }
    }
}
