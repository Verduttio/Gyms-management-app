using Gyms.API.Data;
using Gyms.API.Models.Entities;
using Gyms.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gyms.API.Repositories
{
    public class ClubsRepository : IClubsRepository
    {
        private readonly DataContext _context;

        public ClubsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Club>> GetClubsAsync()
        {
            return await _context.Clubs.ToListAsync();
        }

        public async Task<Club> GetClubAsync(int id)
        {
            return await _context.Clubs.FindAsync(id);
        }

        public async Task<Club> AddClubAsync(Club club)
        {
            _context.Clubs.Add(club);
            await _context.SaveChangesAsync();

            return club;
        }
        public async Task<Club> UpdateClubAsync(Club club)
        {
            _context.Entry(club).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return club;
        }

        public async Task<Club> DeleteClubAsync(int id)
        {
            var club = await _context.Clubs.FindAsync(id);
            _context.Clubs.Remove(club);
            await _context.SaveChangesAsync();

            return club;
        }

        private bool ClubExists(int id)
        {
            return (_context.Clubs?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
