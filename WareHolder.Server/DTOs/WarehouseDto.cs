namespace WareHolder.Server.DTOs
{
    public class WarehouseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }
    }

    public class CreateWarehouseDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }
    }
}
