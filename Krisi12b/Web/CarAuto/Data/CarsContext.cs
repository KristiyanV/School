using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CarsContext : DbContext
    {
        public CarsContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.; Integrated Security=true; Database=ShopDbStores");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Cars> Cars { get; set; }

        public DbSet<CarOwner> CarOwners { get; set; }

    }
}
