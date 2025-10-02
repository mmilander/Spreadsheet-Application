namespace Spreadsheet_Mitchell_Milander
{

// Suppress so Dispose function still works
#pragma warning disable SA1601 // Partial elements should be documented
    public partial class Spreadsheet : Form
#pragma warning restore SA1601 // Partial elements should be documented
    {
        public Spreadsheet()
        {
            InitializeComponent();
            InitializeDataGrid();
        }

        private void Spreadsheet_Load(object sender, EventArgs e)
        {

        }

        private void InitializeDataGrid() {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Clear();
            // Create Columns A-Z
            for (char i = 'A'; i <= 'Z'; i++)
            {
                dataGridView1.Columns.Add(i + string.Empty, i + string.Empty);
            }

            // Create Rows 1-50
            for (int i = 0; i < 50; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }
    }
}
