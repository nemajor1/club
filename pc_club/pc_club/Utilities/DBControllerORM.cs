using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

public class DBControllerORM
{
    private readonly ComputerClubContext _context;

    public DBControllerORM()
    {
        _context = new ComputerClubContext();
    }

    public bool UserRegistration(string firstName, string lastName, string username, string password)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Заполните пустые поля");
            }

            _context.Clients.Add(new Client
            {
                FirstName = firstName,
                LastName = lastName,
                Balance = 0,
                Username = username,
                Password = password,
                Status = "white",
                Role = "user"
            });

            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
            return false;
        }
    }

    public bool CheckDataUser(string username, string password)
    {
        try
        {
            var count = _context.Clients.Count(c => c.Username == username && c.Password == password);
            return count > 0;
        }
        catch (Exception e)
        {
            MessageBox.Show("Неверное имя или пароль");
            return false;
        }
    }

    public void LoadClientData(Label[] labels)
    {
        try
        {
            foreach (var label in labels)
            {
                label.Text = "";
            }

            var clients = _context.Clients.ToList();

            foreach (var client in clients)
            {
                labels[0].Text += client.ClientId + "\n";
                labels[1].Text += client.FirstName + "\n";
                labels[2].Text += client.LastName + "\n";
                labels[3].Text += client.Balance + "\n";
                labels[4].Text += client.Username + "\n";
                labels[5].Text += client.Status + "\n";
                labels[6].Text += client.Role + "\n";
            }
        }
        catch (Exception e)
        {
            MessageBox.Show($"Ошибка при загрузке данных клиентов: {e.Message}");
        }
    }

    public void LoadProductData(Label[] labels)
    {
        try
        {
            foreach (var label in labels)
            {
                label.Text = "";
            }

            var products = _context.Bar.ToList();

            foreach (var product in products)
            {
                labels[0].Text += product.ItemId + "\n";
                labels[1].Text += product.ItemName + "\n";
                labels[2].Text += product.ItemPrice + "\n";
                labels[3].Text += product.Quantity + "\n";
            }
        }
        catch (Exception e)
        {
            MessageBox.Show($"Ошибка при загрузке данных бара: {e.Message}");
        }
    }

    public void AddBalance(int clientId, int amount)
    {
        try
        {
            var client = _context.Clients.FirstOrDefault(c => c.ClientId == clientId);
            if (client != null)
            {
                client.Balance += amount;
                _context.SaveChanges();
                MessageBox.Show("Баланс успешно пополнен.");
            }
            else
            {
                MessageBox.Show($"Клиент с ID {clientId} не найден.");
            }
        }
        catch (Exception e)
        {
            MessageBox.Show($"Ошибка при пополнении баланса: {e.Message}");
        }
    }

    public void AddQuantityProduct(int itemId, int quantity)
    {
        try
        {
            var product = _context.Bar.FirstOrDefault(p => p.ItemId == itemId);
            if (product != null)
            {
                product.Quantity += quantity;
                _context.SaveChanges();
                MessageBox.Show("Бар успешно пополнен.");
            }
            else
            {
                MessageBox.Show($"Продукт с ID {itemId} не найден.");
            }
        }
        catch (Exception e)
        {
            MessageBox.Show($"Ошибка при пополнении бара: {e.Message}");
        }
    }

    public void AddProduct(string itemName, int itemPrice)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(itemName) || itemPrice <= 0)
            {
                throw new ArgumentException("Заполните все поля и укажите корректную цену.");
            }

            _context.Bar.Add(new Bar
            {
                ItemName = itemName,
                ItemPrice = itemPrice,
                Quantity = 0
            });

            _context.SaveChanges();
            MessageBox.Show($"Добавлен товар: {itemName}");
        }
        catch (Exception e)
        {
            MessageBox.Show($"Ошибка при добавлении товара: {e.Message}");
        }
    }
}


public class ComputerClubContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Bar> Bar { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=ex27bvw821dl;Database=computer_club");
    }
}

public class Client
{
    public int ClientId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Balance { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Status { get; set; }
    public string Role { get; set; }
}

public class Bar
{
    public int ItemId { get; set; }
    public string ItemName { get; set; }
    public int ItemPrice { get; set; }
    public int Quantity { get; set; }
}

