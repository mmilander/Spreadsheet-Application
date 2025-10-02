namespace Spreadsheet_Mitchell_Milander
{
    public partial class Spreadsheet : Form
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
        }
    }
}
