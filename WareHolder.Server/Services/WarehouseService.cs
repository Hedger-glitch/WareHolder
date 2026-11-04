using Microsoft.EntityFrameworkCore;
using WareHolder.Server.Data;
using WareHolder.Server.DTOs;
using WareHolder.Server.Models;

namespace WareHolder.Server.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly AppDbContext _db;

        public WarehouseService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<WarehouseDto>> GetAllAsync()
        {
            var warehouses = await _db.Warehouses.ToListAsync();

            return warehouses.Select(w => new WarehouseDto
            {
                Id = w.Id,
                Name = w.Name,
                Address = w.Address
            }).ToList();
        }

        public async Task<WarehouseDto?> GetByIdAsync(int id)
        {
            var warehouse = await _db.Warehouses.FindAsync(id);
            if (warehouse == null) return null;

            return new WarehouseDto
            {
                Id = warehouse.Id,
                Name = warehouse.Name,
                Address = warehouse.Address
            };
        }

        public async Task<WarehouseDto> CreateAsync(CreateWarehouseDto dto)
        {
            var warehouse = new Warehouse
            {
                Name = dto.Name,
                Address = dto.Address
            };

            _db.Warehouses.Add(warehouse);
            await _db.SaveChangesAsync();

            return new WarehouseDto
            {
                Id = warehouse.Id,
                Name = warehouse.Name,
                Address = warehouse.Address
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var warehouse = await _db.Warehouses.FindAsync(id);
            if (warehouse == null) return false;

            _db.Warehouses.Remove(warehouse);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
