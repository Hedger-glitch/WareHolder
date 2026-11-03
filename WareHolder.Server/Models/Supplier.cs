namespace WareHolder.Server.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ContactInfo { get; set; }
        public List<Product> Products { get; set; } = new();
    }
}
