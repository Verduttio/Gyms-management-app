using Gyms.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gyms.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Club> Clubs { get; set; } = null!;

        public DbSet<Coach> Coaches { get; set; } = null!;

        public DbSet<Event> Events { get; set; } = null!;

        public DbSet<OpeningHours> OpeningHours { get; set; } = null!;

        public DbSet<Reservation> Reservations { get; set; } = null!;
    }
}
