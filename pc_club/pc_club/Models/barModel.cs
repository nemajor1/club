public class barModel
{
    public int item_id { get; set; }
    public string item_name { get; set; }
    public int item_price { get; set; }
    public barModel(int item_id, string item_name, int item_price)
    {
        this.item_id = item_id;
        this.item_name = item_name;
        this.item_price = item_price;
    }
}