using System;
using System.Windows.Forms;

namespace pc_club
{
    public partial class AuthForm : Form
    {
        public event EventHandler RegisterButtonPressed;
        public event EventHandler EnterButtonPressed;
        public AuthForm()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, System.EventArgs e)
        {
            EnterButtonPressed?.Invoke(this, EventArgs.Empty);
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            RegisterButtonPressed?.Invoke(this, EventArgs.Empty);
        }
    }
}
