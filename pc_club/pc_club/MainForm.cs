using System.Windows.Forms;

namespace pc_club
{
    public partial class MainForm : Form
    {
        ClientsForm clients = new ClientsForm();
        DBController dbController = new DBController();
   
        public MainForm()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, System.EventArgs e)
        {
            Label[] labels = { clients.label2, clients.label3, clients.label4, clients.label5, clients.label6, clients.label7, clients.label8 };
            dbController.LoadClientData(labels);
            ActivatedForm.ShowFormInPanel(clients, panel1);
        }
    }
}
