using System.Windows.Forms;

namespace pc_club
{
    public partial class MainForm : Form
    {
        ClientsForm clients = new ClientsForm();
        public MainForm()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, System.EventArgs e)
        {
            DBController.LoadClientData(clients.label2, clients.label3,
                clients.label4, clients.label5, clients.label6, clients.label7, clients.label8);
            ActivatedForm.ShowFormInPanel(clients, panel1);
        }
    }
}
