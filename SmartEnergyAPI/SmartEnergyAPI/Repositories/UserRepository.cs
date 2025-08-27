using Microsoft.EntityFrameworkCore;
using SmartEnergyAPI.Data;
using SmartEnergyAPI.Entities;

namespace SmartEnergyAPI.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) => _context = context;

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}

