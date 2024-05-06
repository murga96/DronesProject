using drones_core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drones_data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Drone> Drones { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Drone>(drone =>
            {
                drone.HasKey(x => x.Id);
                drone.HasIndex(x => x.SerialNumber).IsUnique();
                drone.HasMany(x => x.Medicines)
                .WithOne(m => m.Drone)
                .HasForeignKey(x => x.DroneId)
                .IsRequired(false);
            });
            modelBuilder.Entity<Medicine>(medicine =>
            {
                medicine.HasKey(x => x.Id);
                medicine.HasIndex(x => x.Code).IsUnique();
            });
        }

    }
}
