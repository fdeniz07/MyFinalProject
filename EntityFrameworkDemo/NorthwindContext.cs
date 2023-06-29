using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo
{
    public class NorthwindContext : DbContext
    {
  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=APACHIE;Initial Catalog=Northwind;Integrated Security=True");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Personel> Personels { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           //fluent mapping
           //modelBuilder.HasDefaultSchema("admin");
           modelBuilder.Entity<Personel>().ToTable("Employees");

           modelBuilder.Entity<Personel>().Property(p => p.Id).HasColumnName("EmployeeID");
           modelBuilder.Entity<Personel>().Property(p => p.Name).HasColumnName("FirstName");
           modelBuilder.Entity<Personel>().Property(p => p.Surname).HasColumnName("LastName");
        }

    }
}
