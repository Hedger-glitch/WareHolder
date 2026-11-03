namespace WareHolder.Server.Models
{
    public class Shelf
    {
        public int Id {  get; set; }
        public string Name { get; set; } = string.Empty;
        public int WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public List<Inventory> Inventories { get; set; } = new();

    }
}
