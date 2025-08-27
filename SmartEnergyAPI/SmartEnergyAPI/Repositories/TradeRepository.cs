using Microsoft.EntityFrameworkCore;
using SmartEnergyAPI.Data;
using SmartEnergyAPI.Entities;

namespace SmartEnergyAPI.Repositories
{
    public class TradeRepository
    {
        private readonly AppDbContext _context;

        public TradeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Trade trade)
        {
            _context.Trade.Add(trade);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Trade>> GetAllAsync()
        {
            return await _context.Trade.ToListAsync();
        }

        public async Task<Trade> GetByIdAsync(int id)
        {
            return await _context.Trade.FindAsync(id);
        }

        public async Task<List<Trade>> GetUserTradesAsync(int userId)
        {
            return await _context.Trade.Where(t => t.BuyerId == userId || t.SellerId == userId).ToListAsync();
        }
    }
}
