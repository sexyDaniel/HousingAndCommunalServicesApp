using GKU_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.DataBaseContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Charge> Charges { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCompany> ServiceCompanies { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Charge>().HasKey(c => new { c.PropertyId, c.ServiceId });
            modelBuilder.Entity<Tariff>().HasKey(t => new { t.BuildingId, t.ServiceId });
            modelBuilder.Entity<Owner>(entity =>
            {
                entity.Property(o => o.PersonalAccount)
                    .HasDefaultValueSql("nextval('serial'::regclass)");
            });

            modelBuilder.HasSequence("serial").StartsAt(100000000);
        }

    }
}
