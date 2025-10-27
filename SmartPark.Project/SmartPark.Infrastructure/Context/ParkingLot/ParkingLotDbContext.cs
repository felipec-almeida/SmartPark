using Microsoft.EntityFrameworkCore;
using SmartPark.Domain.Entities.ParkingLot;

namespace SmartPark.Infrastructure.Context.ParkingLot
{
    public class ParkingLotDbContext : DbContext
    {
        public ParkingLotDbContext(DbContextOptions<ParkingLotDbContext> options) 
            : base(options)
        {
        }

        public DbSet<ParkingLotEntity> ParkingLots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingLotEntity>().OwnsOne(p => p.Address);
        }
    }
}
