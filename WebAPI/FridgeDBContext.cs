using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;

namespace WebAPI
{
    public class FridgeDBContext : DbContext
    {
        public FridgeDBContext(DbContextOptions<FridgeDBContext> options) : base(options)
        {
        }

        public virtual DbSet<Fridge> Fridges { get; set; }
        public virtual DbSet<FridgeModel> FridgeModels { get; set; }
        public virtual DbSet<FridgeProduct> FridgeProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
