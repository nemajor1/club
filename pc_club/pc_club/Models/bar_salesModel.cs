public class bar_salesModel
{
    public int sale_id { get; set; }
    public int client_id { get; set; }
    public int item_id { get; set; }
    public int quantity { get; set; }
    public string sale_date { get; set; }
    public bar_salesModel(int sale_id, int client_id, int item_id, int quantity, string sale_date)
    {
        this.sale_id = sale_id;
        this.client_id = client_id;
        this.item_id = item_id;
        this.quantity = quantity;
        this.sale_date = sale_date;
    }
}