namespace WareHolder.Server.DTOs
{
    public class InventoryDto
    {
        public int Id { get; set; }
        public int ShelfId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class CreateInventoryDto
    {
        public int ShelfId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
