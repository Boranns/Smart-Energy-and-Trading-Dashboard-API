namespace SmartEnergyAPI.DTOs
{
    public class TradeDto
    {
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
    }
}
