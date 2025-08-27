namespace SmartEnergyAPI.Entities
{
    public class Trade
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public DateTime TradeDate { get; set; }
    }
}
