using GameBackEnd.Domain.Inventory.Models;
using IdentityAutenticator.Data;
using Microsoft.EntityFrameworkCore;

namespace IdentityAutenticator
{
    public class ChampionRepository : IChampionRepository
    {
        private readonly ApplicationDbContext _context;

        public ChampionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Champion>> GetChampionsByUserId(string userId)
        {
            return await _context.Champions
                .Include(c => c.Attributes)
                .Include(c => c.Stats)
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }
    }
}