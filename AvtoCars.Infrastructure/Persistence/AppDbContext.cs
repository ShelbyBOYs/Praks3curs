using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AvtoCars.domain;

namespace AvtoCars.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(builder =>
            {
                builder.HasKey(c => c.Id);

                builder.OwnsOne<Vin>(c => c.Vin, vinBuilder =>
                {
                    vinBuilder.Property(v => v.Vin_).HasColumnName("Vin");
                });

                builder.OwnsOne<Money>(c => c.Price, moneyBuilder =>
                {
                    moneyBuilder.Property(m => m.Price).HasColumnName("Price");
                    moneyBuilder.Property(m => m.Currency).HasColumnName("Currency");
                });
            });

            base.OnModelCreating(modelBuilder);

        }
    }
}
