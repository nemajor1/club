using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

public static class DBController
{
    const string msgConnect = "Host=localhost;Port=5432;Username=postgres;Password=ex27bvw821dl;Database=computer_club";

    public static NpgsqlConnection con = new NpgsqlConnection(msgConnect);

    public static void Connection()
    {
        con.Open();
    }
    private static void ExecuteNonQuery(string query, params NpgsqlParameter[] parameters)
    {
        using (var command = new NpgsqlCommand(query, (NpgsqlConnection)con))
        {
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            command.ExecuteNonQuery();
        }
    }
    private static DataTable ExecuteQuery(string query, params NpgsqlParameter[] parameters)
    {
        using (var command = new NpgsqlCommand(query, con))
        {
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            using (var adapter = new NpgsqlDataAdapter(command))
            {
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
    public static bool UserRegistration(string firstName, string lastName, string username, string password)
    {
        string msg = @"INSERT INTO clients (first_name, last_name, balance, username, password, status, role)
                         VALUES (@first_name, @last_name, '0', @username, @password, 'white', 'user')";

        var parametrs = new[]
        {
            new NpgsqlParameter("@first_name", firstName),
            new NpgsqlParameter("@last_name", lastName),
            new NpgsqlParameter("@username", username),
            new NpgsqlParameter("@password", password)
        };
        if (!String.IsNullOrWhiteSpace(firstName) && !String.IsNullOrWhiteSpace(lastName) && !String.IsNullOrWhiteSpace(username) && !String.IsNullOrWhiteSpace(password))
        {
            ExecuteNonQuery(msg, parametrs);
            return true;
        }
        else
        {
            MessageBox.Show("Заполните пустые поля");
            return false;
        }
    }
    public static bool CheckDataUser(string username, string password)
    {
        string msg = "SELECT COUNT(*) FROM clients WHERE username = @username AND password = @password";

        var parametrs = new[]
        {
            new NpgsqlParameter("@username", username),
            new NpgsqlParameter("@password", password)
        };
        try
        {
            DataTable result = ExecuteQuery(msg, parametrs);
            return result.Rows.Count > 0;
        }
        catch (Exception e)
        {
            MessageBox.Show($"Error during login check: {e.Message}");
            return false;
        }
    }
    public static void LoadClientData(Label _id, Label _firstname, Label _lastname, Label _balance, Label _username, Label _status, Label _role)
    {
        string msg = "SELECT client_id, first_name, last_name, balance, username, status, role FROM clients";

        try
        {
            _id.Text = "";
            _firstname.Text = "";
            _lastname.Text = "";
            _balance.Text = "";
            _username.Text = "";
            _status.Text = "";
            _role.Text = "";

            DataTable result = ExecuteQuery(msg);

            foreach (DataRow row in result.Rows)
            {
                int clientId = Convert.ToInt32(row["client_id"]);
                string firstName = row["first_name"].ToString();
                string lastName = row["last_name"].ToString();
                int balance = Convert.ToInt32(row["balance"]);
                string username = row["username"].ToString();
                string status = row["status"].ToString();
                string role = row["role"].ToString();

                _id.Text += clientId + "\n";
                _firstname.Text += firstName + "\n";
                _lastname.Text += lastName + "\n";
                _balance.Text += balance + "\n";
                _username.Text += username + "\n";
                _status.Text += status + "\n";
                _role.Text += role + "\n";
            }
        }
        catch (Exception e)
        {
            MessageBox.Show($"Ошибка при загрузке данных клиентов: {e.Message}");
        }
    }
    public static void AddBalance(int clientId, int amount)
    {
        string query = "UPDATE clients SET balance = balance + @amount WHERE client_id = @clientId";

        var parameters = new[]
        {
        new NpgsqlParameter("@amount", amount),
        new NpgsqlParameter("@clientId", clientId)
        };

        try
        {
            ExecuteNonQuery(query, parameters);
            MessageBox.Show("Баланс успешно пополнен.");
        }
        catch (Exception e)
        {
            MessageBox.Show($"Ошибка при пополнении баланса: {e.Message}");
        }
    }
}
