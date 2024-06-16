using System;
using System.Windows.Forms;
using pc_club.EndToEndForms;

namespace pc_club
{
    public partial class EndToEndTestForm : Form
    {
        ActivatedForm activatedForm = new ActivatedForm();
        UserRegFormTest userRegFormTest = new UserRegFormTest();
        UserCheckDataFormTest checkDataForm = new UserCheckDataFormTest();
        LoadClientDataFormTest loadClientDataFormTest = new LoadClientDataFormTest();
        LoadBarDataFormTest loadBarDataFormTest = new LoadBarDataFormTest();
        
        public EndToEndTestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            activatedForm.ShowFormInPanel(userRegFormTest, panel1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            activatedForm.ShowFormInPanel(checkDataForm, panel1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            activatedForm.ShowFormInPanel(loadClientDataFormTest, panel1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            activatedForm.ShowFormInPanel(loadBarDataFormTest, panel1);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
