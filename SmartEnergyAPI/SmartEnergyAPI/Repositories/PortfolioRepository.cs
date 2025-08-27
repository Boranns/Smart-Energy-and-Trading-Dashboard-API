using Microsoft.EntityFrameworkCore;
using SmartEnergyAPI.Data;
using SmartEnergyAPI.Entities;

namespace SmartEnergyAPI.Repositories
{
    public class PortfolioRepository
    {
        private readonly AppDbContext _context;

        public PortfolioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Portfolio>> GetPortfoliosAsync(int userId)
        {
            return await _context.Portfolio.Where(p => p.UserId == userId).ToListAsync();

        }
        
        public async Task<Portfolio> GetPortfolioAsync(int id)
        {
            return await _context.Portfolio.FindAsync(id);
        }

        public async Task AddAsync(Portfolio portfolio)
        {
            _context.Portfolio.Add(portfolio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Portfolio portfolio)
        {
            _context.Portfolio.Update(portfolio);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Portfolio portfolio)
        {
            _context.Portfolio.Remove(portfolio);
            await _context.SaveChangesAsync();
        }
    }
}
