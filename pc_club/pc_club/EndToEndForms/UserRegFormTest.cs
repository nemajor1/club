using System;
using System.Windows.Forms;

namespace pc_club.EndToEndForms
{
    public partial class UserRegFormTest : Form
    {
        DBController dbController = new DBController();
        public UserRegFormTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dbController.UserRegistration(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text))
            {
                MessageBox.Show("Тест регистрации пройден");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }
    }
}
