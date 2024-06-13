using System;
using System.Windows.Forms;

namespace pc_club
{
    public partial class Form1 : Form
    {
        AuthForm authForm = new AuthForm();
        RegisterForm registerForm = new RegisterForm();
        MainForm mainForm = new MainForm();
        DBController dbController = new DBController();
        public Form1()
        {
            DBController.Connection();
            InitializeComponent();
            authForm.RegisterButtonPressed += AuthForm_RegisterButtonPressed;
            authForm.EnterButtonPressed += AuthForm_EnterButtonPressed;
            registerForm.RegisterButtonPressed += RegisterForm_RegisterButtonPressed;
            registerForm.ReturnButtonPressed += RegisterForm_ReturnButtonPressed;
            ActivatedForm.ShowFormInPanel(authForm, panel1);
        }
        private void AuthForm_RegisterButtonPressed(object sender, EventArgs e)
        {
            ActivatedForm.ShowFormInPanel(registerForm, panel1);
        }
        private void AuthForm_EnterButtonPressed(object sender, EventArgs e)
        {
            if (dbController.CheckDataUser(authForm.textBox1.Text, authForm.textBox2.Text))
            {
                ActivatedForm.ShowFormInPanel(mainForm, panel1);
            }
        }
        private void RegisterForm_RegisterButtonPressed(object sender, EventArgs e)
        {
            if (dbController.UserRegistration(registerForm.textBox1.Text, registerForm.textBox2.Text, registerForm.textBox3.Text, registerForm.textBox4.Text))
            {
                ActivatedForm.ShowFormInPanel(authForm, panel1);
            }
        }
        private void RegisterForm_ReturnButtonPressed(object sender, EventArgs e)
        {
            ActivatedForm.ShowFormInPanel(authForm, panel1);
        }
    }
}
