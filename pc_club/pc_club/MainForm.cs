using System;
using System.Windows.Forms;

namespace pc_club
{
    public partial class MainForm : Form
    {
        ClientsForm clients = new ClientsForm();
        DBController dbController = new DBController();
        ActivatedForm activatedForm = new ActivatedForm();
        BarForm barForm = new BarForm();
        public MainForm()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, System.EventArgs e)
        {
            Label[] labels = { clients.label2, clients.label3, clients.label4, clients.label5, clients.label6, clients.label7, clients.label8 };
            dbController.LoadClientData(labels);
            activatedForm.ShowFormInPanel(clients, panel1);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            activatedForm.ShowFormInPanel(barForm, panel1);
        }
    }
}
