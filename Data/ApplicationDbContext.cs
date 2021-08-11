using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkingApp.DTO;

namespace ParkingApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        //public DbSet<ParkingLotDTO> ParkingLots { get; set; }

        public DbSet<CarDTO> Cars { get; set; }

        public DbSet<TicketDTO> Tickets { get; set; }
    }
}
