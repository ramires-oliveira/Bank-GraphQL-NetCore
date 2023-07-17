using BankGraphQL.Domain;
using Microsoft.EntityFrameworkCore;

namespace BankGraphQL.Repositories
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Account> Account { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Value)
                .HasColumnType("decimal(10, 2)");

            modelBuilder.Entity<User>().HasData(
                new User { Id = new Guid("11111111-1111-1111-1111-111111111111"), Name = "User", Email = "user@user.com" }
            );

            modelBuilder.Entity<Account>().HasData(
                new Account { Id = new Guid("11111111-1111-1111-0000-000000000001"), UserId = new Guid("11111111-1111-1111-1111-111111111111"), Number= "54321", Value = 1000.00M, Active = true}
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
