namespace SmartEnergyAPI.Entities
{
    public class EnergyProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal CurrentPrice { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
