using Microsoft.EntityFrameworkCore;
using UserRegistration.Model;




namespace UserRegistration.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Registration> registrations { get; set; }
        public DbSet<LoginModels> loginModel { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginModels>()
              .HasIndex(u => u.UserEmail)
              .IsUnique();
            // Add any additional configurations if needed
        }

    }
}
