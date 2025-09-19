using System.Diagnostics.Tracing;
using System.Reflection.Metadata;
using System.Text;
using System.Windows.Forms;

namespace WinFormsNotepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This takes a System.IO.TextReader object as a
        /// parameter and reads all the text from the TextReader object 
        /// and puts it in the text box interface
        /// </summary>
        private void LoadText(TextReader sr)
        {
            textBox1.Text = sr.ReadToEnd();
        }

        /// <summary>
        /// Loads data from file into WinForms Module
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Read the contents of the file into a stream
                var fileStream = openFileDialog1.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    LoadText(reader);
                }

            }
        }

        /// <summary>
        /// Saves data from WinForms Module into selected file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
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
                        writer.WriteLine(textBox1.Text);
                    }
                    myStream.Close();
                }
            }
        }

        /// <summary>
        /// Loads the first 50 Fibonacci Numbers to WinForms Interface
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FibonacciTextReader initFib = new FibonacciTextReader(50);
            StringReader tempStringReader = new StringReader(initFib.ReadToEnd());
            LoadText(tempStringReader);
        }

        /// <summary>
        /// Loads the first 100 Fibonacci Numbers to WinForms Interface
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadFibonacciNumbersfirst100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FibonacciTextReader initFib = new FibonacciTextReader(100);
            StringReader tempStringReader = new StringReader(initFib.ReadToEnd());
            LoadText(tempStringReader);
        }
    }
}
