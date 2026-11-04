using Microsoft.EntityFrameworkCore;
using WareHolder.Server.Data;
using WareHolder.Server.DTOs;
using WareHolder.Server.Models;

namespace WareHolder.Server.Services
{
    public class ShelfService : IShelfService
    {
        public readonly AppDbContext _db;

        public ShelfService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<ShelfDto>> GetAllAsync()
        {
            var shelves = await _db.Shelves.ToListAsync();

            return shelves.Select(s => new ShelfDto
            {
                Id = s.Id,
                Name = s.Name,
                WarehouseId = s.WarehouseId,
                SupplierId = s.SupplierId
            }).ToList();
        }

        public async Task<ShelfDto?> GetByIdAsync(int id)
        {
            var shelf = await _db.Shelves.FindAsync(id);

            if (shelf == null) return null;

            return new ShelfDto
            {
                Id = shelf.Id,
                Name = shelf.Name,
                WarehouseId = shelf.WarehouseId,
                SupplierId = shelf.SupplierId
            };
        }

        public async Task<ShelfDto> CreateAsync(CreateShelfDto dto)
        {
            var warehouseExists = await _db.Warehouses.AnyAsync(w => w.Id == dto.WarehouseId);
            if (!warehouseExists) throw new ArgumentException("Error: warehouse not found");

            var supplierExists = await _db.Suppliers.AnyAsync(s => s.Id == dto.SupplierId);
            if (!supplierExists) throw new ArgumentException("Error: supplier not found");

            var shelf = new Shelf
            {
                Name = dto.Name,
                WarehouseId = dto.WarehouseId,
                SupplierId = dto.SupplierId
            };

            _db.Shelves.Add(shelf);
            await _db.SaveChangesAsync();

            return new ShelfDto
            {
                Id = shelf.Id,
                Name = shelf.Name,
                WarehouseId = shelf.WarehouseId,
                SupplierId = shelf.SupplierId
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var shelf = await _db.Shelves.FindAsync(id);
            if (shelf == null) return false;

            _db.Shelves.Remove(shelf);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
