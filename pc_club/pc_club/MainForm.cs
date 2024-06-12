using Npgsql;
using System.Windows.Forms;

namespace pc_club
{
    public partial class MainForm : Form
    {
        string msg;
        ClientsForm clients = new ClientsForm();
        public MainForm()
        {
            InitializeComponent();
        }
        public void FormActive(Form form)
        {
            ShowFormInPanel(form);
        }
        private void LoadClientData()
        {
            msg = "SELECT client_id, first_name, balance, status, role FROM clients;";
            using (var cmd = new NpgsqlCommand(msg, Form1.con))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    // Строки для отображения в Label
                    string label2Content = "";
                    string label3Content = "";
                    string label4Content = "";
                    string label5Content = "";
                    string label6Content = "";

                    while (reader.Read())
                    {
                        int clientId = reader.GetInt32(0);
                        string firstName = reader.GetString(1);
                        int balance = reader.GetInt32(2);
                        string status = reader.GetString(3);
                        string role = reader.GetString(4);

                        label2Content += $"{clientId}\n";
                        label3Content += $"{firstName}\n";
                        label4Content += $"{balance}\n";
                        label5Content += $"{status}\n";
                        label6Content += $"{role}\n";
                    }

                    // Устанавливаем текст Label
                    clients.label2.Text = label2Content;
                    clients.label3.Text = label3Content;
                    clients.label4.Text = label4Content;
                    clients.label5.Text = label5Content;
                    clients.label6.Text = label6Content;
                }
            }
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
        private void button2_Click(object sender, System.EventArgs e)
        {
            LoadClientData();
            FormActive(clients);
        }
    }
}
