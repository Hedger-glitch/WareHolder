namespace WareHolder.Server.DTOs
{
    public class ShelfDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int WarehouseId { get; set; }
        public int SupplierId { get; set; }
    }

    public class CreateShelfDto
    {
        public string Name { get; set; } = string.Empty;
        public int WarehouseId { get; set; }
        public int SupplierId { get; set; }
    }
}
