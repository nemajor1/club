using System;
using System.Windows.Forms;

namespace pc_club
{
    public partial class AuthForm : Form
    {
        public event EventHandler RegisterButtonClicked;
        public AuthForm()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, System.EventArgs e)
        {

        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            RegisterButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
