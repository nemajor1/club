using System;
using System.Windows.Forms;
using pc_club.ModuleForms;

namespace pc_club
{
    public partial class MainForm : Form
    {
        ClientsForm clients = new ClientsForm();
        DBController dbController = new DBController();
        ActivatedForm activatedForm = new ActivatedForm();
        BarForm barForm = new BarForm();
        EndToEndTestForm endToEndTestForm = new EndToEndTestForm();
        ModuleRegFormTest moduleRegFormTest = new ModuleRegFormTest();
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
            Label[] labels = { barForm.label2, barForm.label3, barForm.label4, barForm.label5 };
            dbController.LoadProductData(labels);
            activatedForm.ShowFormInPanel(barForm, panel1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            activatedForm.ShowFormInPanel(endToEndTestForm, panel1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            activatedForm.ShowFormInPanel(moduleRegFormTest, panel1);
        }
    }
}