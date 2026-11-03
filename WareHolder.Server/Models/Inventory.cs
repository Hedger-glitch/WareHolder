namespace WareHolder.Server.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int ShelfId { get; set; }
        public Shelf? Shelf { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
    }
}
