using System.Windows.Forms;

namespace pc_club
{
    public partial class MainForm : Form
    {
        static ClientsForm clients = new ClientsForm();

        Label[] labels = { clients.label2, clients.label3, clients.label4, clients.label5, clients.label6, clients.label7, clients.label8 };
        public MainForm()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, System.EventArgs e)
        {
            DBController.LoadClientData(labels);
            ActivatedForm.ShowFormInPanel(clients, panel1);
        }
    }
}
