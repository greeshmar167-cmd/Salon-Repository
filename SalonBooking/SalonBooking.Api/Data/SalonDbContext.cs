using Microsoft.EntityFrameworkCore;
using SalonBooking.Api.Models;

namespace SalonBooking.Api.Data
{
    public class SalonDbContext : DbContext
    {
        public SalonDbContext(DbContextOptions<SalonDbContext> options)
            : base(options) { }

        public DbSet<Service> Services { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
