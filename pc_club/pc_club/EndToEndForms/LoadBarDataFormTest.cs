using System.Windows.Forms;

namespace pc_club.EndToEndForms
{
    public partial class LoadBarDataFormTest : Form
    {
        DBController dbController = new DBController();
        public LoadBarDataFormTest()
        {
            InitializeComponent();
            LoadBarData();
        }
        private void LoadBarData()
        {
            Label[] labels = new[] { label1, label2, label3, label4, };
            dbController.LoadProductData(labels);
        }
    }
}
