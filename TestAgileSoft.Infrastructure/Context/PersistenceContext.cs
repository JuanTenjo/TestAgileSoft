using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestAgileSoft.Domain.Entities;

namespace TestAgileSoft.Infrastructure.Context
{
    public class PersistenceContext : IdentityDbContext<User>
    {
        public PersistenceContext(
            DbContextOptions<PersistenceContext> options
        ) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tasks>()
                .HasOne(t => t.User)
                .WithMany(a => a.Tasks)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade);
               
        }

        public DbSet<Tasks> Tasks { get; set; }
    }
}
