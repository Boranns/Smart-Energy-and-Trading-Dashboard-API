namespace SmartEnergyAPI.Entities
{
    public class Portfolio
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalValue { get; set; }
    }
}
