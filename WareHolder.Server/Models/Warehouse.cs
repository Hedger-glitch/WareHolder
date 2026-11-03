namespace WareHolder.Server.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }
        public List<Shelf> Shelves { get; set; } = new();
    }
}
