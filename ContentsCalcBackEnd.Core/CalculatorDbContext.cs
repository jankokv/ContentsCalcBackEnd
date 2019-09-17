using System;
using System.Linq;
using ContentsCalcBackEnd.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ContentsCalcBackEnd.Core
{
    public class CalculatorDbContext : DbContext
    {
        public static string ConnectionString { get; set; }

        public CalculatorDbContext()
        {

        }

        public DbSet<ContentsCalculatorItem> ContentsCalculatorItems { get; set; }
        public DbSet<ContentsCategoryType> ContentsCategoryTypes { get; set; }

        public override int SaveChanges()
        {
            SaveAuditData();
            return base.SaveChanges();
        }

        private void SaveAuditData()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).Created = DateTime.UtcNow;
                }
                ((BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
    }
}
