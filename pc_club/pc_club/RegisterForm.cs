using System;
using System.Windows.Forms;

namespace pc_club
{
    public partial class RegisterForm : Form
    {
        public event EventHandler RegisterButtonPressed;
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterButtonPressed?.Invoke(this, EventArgs.Empty);
        }
    }
}
