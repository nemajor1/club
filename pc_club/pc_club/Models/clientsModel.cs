public class clientsModel
{
    public int client_id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public int balance { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public string status { get; set; }
    public string role { get; set; }
    public clientsModel(int client_id, string first_name, string last_name, int balance, string username, string password, userStatus status, userRole role)
    {
        this.client_id = client_id;
        this.first_name = first_name;
        this.last_name = last_name;
        this.balance = balance;
        this.username = username;
        this.password = password;
        this.status = status.ToString();
        this.role = role.ToString();
    }
}
