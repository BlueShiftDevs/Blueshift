using BlueShift.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueShift.Data.Contexts
{
    public class CardsContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }

        public CardsContext(DbContextOptions<CardsContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
