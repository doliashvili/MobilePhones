using Microsoft.EntityFrameworkCore;
using WandioMobilePhones.Domain.DomainObjects;
using WandioMobilePhones.Infrastructure.Configuration;

namespace WandioMobilePhones.Infrastructure
{
    public class PhoneDbContext : DbContext
    {
        public DbSet<PhoneMobileAggregate> Phones { get; set; }
        public DbSet<Image> Images { get; set; }

        public PhoneDbContext(DbContextOptions<PhoneDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneMobileAggregate>()
                .HasMany(x => x.Images).WithOne().OnDelete(DeleteBehavior.Cascade);

            DbInitialaizer.DataSeed(modelBuilder);
        }

    }
}
