using System;
using System.Windows.Forms;

namespace pc_club
{
    public partial class ORMForm : Form
    {
        DBControllerORM dBControllerORM = new DBControllerORM();
        public ORMForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dBControllerORM.UserRegistration( textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text );
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
