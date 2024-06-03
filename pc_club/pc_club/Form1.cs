using System;
using System.Windows.Forms;

namespace pc_club
{
    public partial class Form1 : Form
    {
        AuthForm authForm = new AuthForm();
        RegisterForm registerForm = new RegisterForm();
        public Form1()
        {
            InitializeComponent();
            authForm.RegisterButtonClicked += AuthForm_RegisterButtonClicked;
            registerForm.RegisterButtonPressed += RegisterForm_RegisterButtonClicked;
            FormActive(authForm);
        }
        private void AuthForm_RegisterButtonClicked(object sender, EventArgs e)
        {
            FormActive(registerForm);
        }
        private void RegisterForm_RegisterButtonClicked(object sender, EventArgs e)
        {
            FormActive(authForm);
        }
        public void FormActive(Form form)
        {
            ShowFormInPanel(form);
        }
        private void ShowFormInPanel(Form form)
        {
            // Очистить панель перед отображением новой формы
            panel1.Controls.Clear();

            // Настройка формы
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Добавление формы в панель
            panel1.Controls.Add(form);
            panel1.Tag = form;

            // Показ формы
            form.Show();
        }
    }
}
