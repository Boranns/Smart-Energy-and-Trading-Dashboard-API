using SmartEnergyAPI.Data;
using SmartEnergyAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace SmartEnergyAPI.Repositories
{
    public class EnergyProductRepository
    {
        private readonly AppDbContext _context;

        public EnergyProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<EnergyProduct>> GetAllAsync()
        {
            return await _context.EnergyProduct.ToListAsync();
        }

        public async Task<EnergyProduct> GetByIdAsync(int Id)
        {
            return await _context.EnergyProduct.FindAsync(Id);
        }

        public async Task AddAsync(EnergyProduct product)
        {
            _context.EnergyProduct.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EnergyProduct product)
        {
            _context.EnergyProduct.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(EnergyProduct product)
        {
            _context.EnergyProduct.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
