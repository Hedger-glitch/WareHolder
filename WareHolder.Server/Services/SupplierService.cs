using Microsoft.EntityFrameworkCore;
using WareHolder.Server.Data;
using WareHolder.Server.DTOs;
using WareHolder.Server.Models;

namespace WareHolder.Server.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly AppDbContext _db;

        public SupplierService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<SupplierDto>> GetAllAsync()
        {
            var suppliers = await _db.Suppliers.ToListAsync();

            return suppliers.Select(s => new SupplierDto
            {
                Id = s.Id,
                Name = s.Name,
                ContactInfo = s.ContactInfo
            }).ToList();
        }

        public async Task<SupplierDto?> GetByIdAsync(int id)
        {
            var supplier = await _db.Suppliers.FindAsync(id);
            if (supplier == null) return null;

            return new SupplierDto
            {
                Id = supplier.Id,
                Name = supplier.Name,
                ContactInfo = supplier.ContactInfo
            };
        }

        public async Task<SupplierDto> CreateAsync(CreateSupplierDto dto)
        {
            var supplier = new Supplier
            {
                Name = dto.Name,
                ContactInfo = dto.ContactInfo
            };

            _db.Suppliers.Add(supplier);
            await _db.SaveChangesAsync();

            return new SupplierDto
            {
                Id = supplier.Id,
                Name = supplier.Name,
                ContactInfo = supplier.ContactInfo
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var supplier = await _db.Suppliers.FindAsync(id);
            if (supplier == null) return false;

            _db.Suppliers.Remove(supplier);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
