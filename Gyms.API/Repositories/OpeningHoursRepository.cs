using Gyms.API.Data;
using Gyms.API.Models.Entities;
using Gyms.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gyms.API.Repositories
{
    public class OpeningHoursRepository : IOpeningHoursRepository
    {

        private readonly DataContext _context;

        public OpeningHoursRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<OpeningHours> GetOpeningHoursAsync(int id)
        {
            return await _context.OpeningHours.FindAsync(id);
        }

        public async Task<OpeningHours> UpdateOpeningHoursAsync(OpeningHours openingHours)
        {
            _context.Entry(openingHours).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return openingHours;
        }
    }
}
