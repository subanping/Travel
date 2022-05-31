using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DataCURD.A02._01.Domain.Models.Application.UsersAndRoles;

namespace DataCURD.A02._02.Domain.ORM
{
    public class DomainDataDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public DomainDataDbContext(DbContextOptions<DomainDataDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationRole>? ApplicationRoles { get; set; }
        public DbSet<ApplicationUser>? ApplicationUsers { get; set; }

        public DbSet<Student>? Students { get; set; }
        public DbSet<TeachClass>? TeachClasses { get; set; }
        public DbSet<TeachClassRoom>? TeachClassRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
