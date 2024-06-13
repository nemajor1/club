using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

public class DBController
{
    const string msgConnect = "Host=localhost;Port=5432;Username=postgres;Password=ex27bvw821dl;Database=computer_club";

    public static NpgsqlConnection con = new NpgsqlConnection(msgConnect);

    public static void Connection()
    {
        con.Open();
    }
    private void ExecuteNonQuery(string query, params NpgsqlParameter[] parameters)
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
    private DataTable ExecuteQuery(string query, params NpgsqlParameter[] parameters)
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
    public bool UserRegistration(string firstName, string lastName, string username, string password)
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
    public bool CheckDataUser(string username, string password)
    {
        string msg = "SELECT COUNT(*) FROM clients WHERE username = @username AND password = @password";

        var parametrs = new[]
        {
        new NpgsqlParameter("@username", username),
        new NpgsqlParameter("@password", password)
    };

        try
        {
            // Выполняем запрос и получаем одно целое число
            int count = Convert.ToInt32(ExecuteQuery(msg, parametrs).Rows[0][0]);

            // Если count больше 0, значит, пользователь с такими данными существует
            return count > 0;
        }
        catch (Exception e)
        {
            MessageBox.Show("Неверное имя или пароль");
            return false;
        }
    }
    public void LoadClientData(Label[] labels )
    {
        string msg = "SELECT client_id, first_name, last_name, balance, username, status, role FROM clients";

        try
        {
            foreach (var label in labels)
            {
                label.Text = "";
            }

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

                labels[0].Text += clientId + "\n";
                labels[1].Text += firstName + "\n";
                labels[2].Text += lastName + "\n";
                labels[3].Text += balance + "\n";
                labels[4].Text += username + "\n";
                labels[5].Text += status + "\n";
                labels[6].Text += role + "\n";
            }
        }
        catch (Exception e)
        {
            MessageBox.Show($"Ошибка при загрузке данных клиентов: {e.Message}");
        }
    }
    public void AddBalance(int clientId, int amount)
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
