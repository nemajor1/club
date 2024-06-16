using System.Windows.Forms;

namespace pc_club.EndToEndForms
{
    public partial class LoadClientDataFormTest : Form
    {
        DBController dbController = new DBController();
        public LoadClientDataFormTest()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            Label[] labels = new[] { label1, label2, label3, label4, label5, label6, label7 };
            dbController.LoadClientData(labels);
        }
    }
}
