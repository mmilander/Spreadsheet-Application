// <copyright file="Form1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WinFormsNotepad
{
    using System.Diagnostics.Tracing;
    using System.Reflection.Metadata;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Default code from Windows Form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// This takes a System.IO.TextReader object as a
        /// parameter and reads all the text from the TextReader object.
        /// and puts it in the text box interface.
        /// </summary>
        private void LoadText(TextReader sr)
        {
            this.textBox1.Text = sr.ReadToEnd();
        }

        /// <summary>
        /// Loads data from file into WinForms Module.
        /// </summary>
        /// <param name="sender">
        /// Default code from Microsoft Docs.
        /// </param>
        /// <param name="e">
        /// Default code from the Microsoft Docs.
        /// </param>
        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.InitialDirectory = "c:\\";
            this.openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            this.openFileDialog1.FilterIndex = 2;
            this.openFileDialog1.RestoreDirectory = true;

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Read the contents of the file into a stream.
                var fileStream = this.openFileDialog1.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    this.LoadText(reader);
                }
            }
        }

        /// <summary>
        /// Saves data from WinForms Module into selected file.
        /// </summary>
        /// <param name="sender">
        /// Default Windows Code params from docs.
        /// </param>
        /// <param name="e">
        /// Default Windows Code params from the docs.
        /// </param>
        private void SaveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    using (StreamWriter writer = new StreamWriter(myStream))
                    {
                        writer.WriteLine(this.textBox1.Text);
                    }

                    myStream.Close();
                }
            }
        }

        /// <summary>
        /// Loads the first 50 Fibonacci Numbers to WinForms Interface.
        /// </summary>
        /// <param name="sender">
        /// Default Windows Code params from docs.
        /// </param>
        /// <param name="e">
        /// Default Windows Code params from the docs.
        /// </param>
        private void LoadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FibonacciTextReader initFib = new FibonacciTextReader(50);
            StringReader tempStringReader = new StringReader(initFib.ReadToEnd());
            this.LoadText(tempStringReader);
        }

        /// <summary>
        /// Loads the first 100 Fibonacci Numbers to WinForms Interface.
        /// </summary>
        /// <param name="sender">
        /// Default Windows Code params from docs.
        /// </param>
        /// <param name="e">
        /// Default Windows Code params from the docs.
        /// </param>
        private void LoadFibonacciNumbersfirst100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FibonacciTextReader initFib = new FibonacciTextReader(100);
            StringReader tempStringReader = new StringReader(initFib.ReadToEnd());
            this.LoadText(tempStringReader);
        }
    }
}
