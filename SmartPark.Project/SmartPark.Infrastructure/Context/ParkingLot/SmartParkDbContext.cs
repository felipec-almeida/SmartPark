using Microsoft.EntityFrameworkCore;
using SmartPark.Domain.Entities.ParkingLot;
using SmartPark.Domain.Entities.ParkingRecord;

namespace SmartPark.Infrastructure.Context.ParkingLot
{
    public class SmartParkDbContext : DbContext
    {
        public SmartParkDbContext(DbContextOptions<SmartParkDbContext> options)
            : base(options)
        {
        }

        public DbSet<ParkingLotEntity> ParkingLots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingLotEntity>()
                .OwnsOne(p => p.Address);

            modelBuilder.Entity<ParkingRecordEntity>()
                .OwnsOne(p => p.Customer);

            modelBuilder.Entity<ParkingRecordEntity>()
                .OwnsOne(p => p.Vehicle);

            modelBuilder.Entity<ParkingRecordEntity>()
                .HasOne<ParkingLotEntity>()
                .WithMany()
                .HasForeignKey(p => p.ParkingLotId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
