using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2.Models.CarOwnerDB;

namespace Task2.Models
{
    public class CarOwnerContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<CarOwner> CarOwners { get; set; }

        public CarOwnerContext(DbContextOptions<CarOwnerContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CarOwner>()
                .HasKey(x => new { x.CarId, x.OwnerId });
        }
    }
}
