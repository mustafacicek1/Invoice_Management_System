using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.Concrete
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
