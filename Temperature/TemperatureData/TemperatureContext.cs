using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TemperatureDomain;

namespace TemperatureData
{
    public class TemperatureContext : DbContext
    {
        public DbSet<TemperatureRecord> TemperatureRecords { get; set; }
        public DbSet<SensorLimit> SensorLimits { get; set; }
        public TemperatureContext(DbContextOptions<TemperatureContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<SensorLimit>().HasData(
                new SensorLimit
                {
                    Id = 1,
                    Cold = 22,
                    Hot = 35
                });
        }

    }
}