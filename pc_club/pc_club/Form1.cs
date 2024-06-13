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
        ActivatedForm activatedForm = new ActivatedForm();
        public Form1()
        {
            DBController.Connection();
            InitializeComponent();
            authForm.RegisterButtonPressed += AuthForm_RegisterButtonPressed;
            authForm.EnterButtonPressed += AuthForm_EnterButtonPressed;
            registerForm.RegisterButtonPressed += RegisterForm_RegisterButtonPressed;
            registerForm.ReturnButtonPressed += RegisterForm_ReturnButtonPressed;
            activatedForm.ShowFormInPanel(authForm, panel1);
        }
        private void AuthForm_RegisterButtonPressed(object sender, EventArgs e)
        {
            activatedForm.ShowFormInPanel(registerForm, panel1);
        }
        private void AuthForm_EnterButtonPressed(object sender, EventArgs e)
        {
            if (dbController.CheckDataUser(authForm.textBox1.Text, authForm.textBox2.Text))
            {
                activatedForm.ShowFormInPanel(mainForm, panel1);
            }
        }
        private void RegisterForm_RegisterButtonPressed(object sender, EventArgs e)
        {
            if (dbController.UserRegistration(registerForm.textBox1.Text, registerForm.textBox2.Text, registerForm.textBox3.Text, registerForm.textBox4.Text))
            {
                activatedForm.ShowFormInPanel(authForm, panel1);
            }
        }
        private void RegisterForm_ReturnButtonPressed(object sender, EventArgs e)
        {
            activatedForm.ShowFormInPanel(authForm, panel1);
        }
    }
}
