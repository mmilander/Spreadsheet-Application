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
        /// This's takes a System.IO.TextReader object as a
        /// parameter and reads all the text from the TextReader object 
        /// and puts it in the text box interface
        /// </summary>
        private void LoadText(TextReader sr)
        {
            textBox1.Text = sr.ReadToEnd();
        }

        /// <summary>
        /// 
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

                StreamReader reader = new StreamReader(fileStream);
                LoadText(reader);
            }
        }

    }
}
