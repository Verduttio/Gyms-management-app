using Gyms.API.Data;
using Gyms.API.Models.Entities;
using Gyms.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gyms.API.Repositories
{
    public class CoachesRepository : ICoachesRepository
    {

        private readonly DataContext _context;

        public CoachesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Coach> AddCoachAsync(Coach coach)
        {
            _context.Coaches.Add(coach);
            await _context.SaveChangesAsync();

            return coach;
        }

        public async Task<Coach> DeleteCoachAsync(int id)
        {
            var coach = await _context.Coaches.FindAsync(id);
            _context.Coaches.Remove(coach);
            await _context.SaveChangesAsync();

            return coach;
        }

        public async Task<Coach> GetCoachAsync(int id)
        {
            return await _context.Coaches.FindAsync(id);
        }

        public async Task<IEnumerable<Coach>> GetCoachesAsync()
        {
            return await _context.Coaches.ToListAsync();
        }

        public async Task<Coach> UpdateCoachAsync(Coach coach)
        {
            _context.Entry(coach).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return coach;
        }
    }
}
