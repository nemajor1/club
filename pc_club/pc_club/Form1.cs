using Npgsql;
using System;
using System.Windows.Forms;

namespace pc_club
{
    public partial class Form1 : Form
    {
        const string connect = "Host=localhost;Port=5432;Username=postgres;Password=ex27bvw821dl;Database=computer_club";
        public static NpgsqlConnection con;
        private string msg;

        AuthForm authForm = new AuthForm();
        RegisterForm registerForm = new RegisterForm();
        MainForm mainForm = new MainForm();
        public Form1()
        {
            InitializeComponent();
            con = new NpgsqlConnection(connect);
            con.Open();

            authForm.RegisterButtonPressed += AuthForm_RegisterButtonPressed;
            authForm.EnterButtonPressed += AuthForm_EnterButtonPressed;
            registerForm.RegisterButtonPressed += RegisterForm_RegisterButtonPressed;
            registerForm.ReturnButtonPressed += RegisterForm_ReturnButtonPressed;
            FormActive(authForm);
        }
        private void AuthForm_RegisterButtonPressed(object sender, EventArgs e)
        {
            FormActive(registerForm);
        }
        private void AuthForm_EnterButtonPressed(object sender, EventArgs e)
        {
            if (CheckLogin())
            {
                FormActive(mainForm);
            }
        }
        private void RegisterForm_RegisterButtonPressed(object sender, EventArgs e)
        {
            
            if (!String.IsNullOrWhiteSpace(registerForm.textBox1.Text) && !String.IsNullOrWhiteSpace(registerForm.textBox2.Text) && !String.IsNullOrWhiteSpace(registerForm.textBox3.Text) && !String.IsNullOrWhiteSpace(registerForm.textBox4.Text))
            {
                Registration();
                FormActive(authForm);
            }  
        }
        private void RegisterForm_ReturnButtonPressed(object sender, EventArgs e)
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

        private bool CheckLogin()
        {
            msg = "SELECT COUNT(*) FROM clients WHERE username = @username AND password = @password";

            try
            {
                using (var cmd = new NpgsqlCommand(msg, con))
                {
                    cmd.Parameters.AddWithValue("username", authForm.textBox1.Text);
                    cmd.Parameters.AddWithValue("password", authForm.textBox2.Text);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during login check: {ex.Message}");
                return false;
            }
        }
        private void Registration()
        {
            string query = "INSERT INTO clients (first_name, last_name, balance, username, password, status, role) VALUES (@firstName, @lastName, 0, @username, @password, 'white', 'user')";

            using (var cmd = new NpgsqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("firstName", registerForm.textBox1.Text);
                cmd.Parameters.AddWithValue("lastName", registerForm.textBox2.Text);
                cmd.Parameters.AddWithValue("username", registerForm.textBox3.Text);
                cmd.Parameters.AddWithValue("password", registerForm.textBox4.Text);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Обработка ошибок
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }
    }
}
