using System;
using System.Windows.Forms;

namespace pc_club.EndToEndForms
{
    public partial class UserCheckDataFormTest : Form
    {
        DBController dbController = new DBController();
        public UserCheckDataFormTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var check = dbController.CheckDataUser(textBox1.Text, textBox2.Text) ? (MessageBox.Show("Тест пройден")) : (MessageBox.Show("Ошибка"));
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
