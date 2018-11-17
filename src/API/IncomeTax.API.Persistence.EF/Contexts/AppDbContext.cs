using IncomeTax.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace IncomeTax.API.Persistence.EF.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<BasicWage> BasicWage { get; set; }
        public DbSet<Taxpayer> Taxpayer { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BasicWage>().HasKey(bw => bw.Id);
            builder.Entity<BasicWage>().Property(bw => bw.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<BasicWage>().Property(bw => bw.Value).IsRequired().HasColumnType("decimal(10, 2)");

            builder.Entity<Taxpayer>().HasKey(t => t.Id);
            builder.Entity<Taxpayer>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Taxpayer>().Property(t => t.Name).IsRequired().HasMaxLength(100);
            builder.Entity<Taxpayer>().Property(t => t.CPF).IsRequired().HasMaxLength(11);
            builder.Entity<Taxpayer>().Property(t => t.NumberOfDependents).IsRequired();
            builder.Entity<Taxpayer>().Property(t => t.MonthlyGrossIncome).IsRequired().HasColumnType("decimal(10, 2)");;
            builder.Entity<Taxpayer>().HasIndex(t => t.CPF).IsUnique();
        }
    }
}