public class computersModel
{
    public int computer_id { get; set; }
    public int number { get; set; }
    public string status { get; set; }
    public computersModel(int computer_id, int number, computerStatus status)
    {
        this.computer_id = computer_id;
        this.number = number;
        this.status = status.ToString();
    }
}