using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using XYZCorp.ParkingLot.Domain;

namespace XYZCorp.ParkingLot.DataStore
{
    public class SqlDbContext : DbContext
    {
        private readonly string ConnectionString;
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }

        public SqlDbContext(string connectionString)
               : base()
        {
            ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(ConnectionString))
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BaseRate>()
                   .Property(p => p.ExcessRate)
                   .HasColumnType("decimal(18,4)");
            modelBuilder.Entity<BaseRate>()
                   .Property(p => p.FlatRate)
                   .HasColumnType("decimal(18,4)");
            modelBuilder.Entity<SlotRate>()
                   .Property(p => p.RatePerHour)
                   .HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Parking>()
                   .Property(p => p.AmountPaid)
                   .HasColumnType("decimal(18,4)");
        }

        public DbSet<EntryPoint> EntryPoints { get; set; }
        public DbSet<BaseRate> BaseRates { get; set; }
        public DbSet<SlotRate> SlotRates { get; set; }
        public DbSet<SlotType> SlotTypes { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<VehicleSlotAssignment> VehicleSlotAssignments { get; set; }
        public DbSet<Parking> Parkings { get; set; }
    }
}
