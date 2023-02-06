namespace QuintessenceStocks.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string stock { get; set; }
        public string industry { get; set; }
        public string sector { get; set; }
        public string currency_code { get; set; }
    }

    public class StockValues
    {
        public int stock_id { get; set; }
        public DateTime date { get; set; }
        public decimal value { get; set; }
    }
}
