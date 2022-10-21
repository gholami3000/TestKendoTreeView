using Microsoft.EntityFrameworkCore;
using TestTree2;

namespace TestKendoTreeView.Models
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UsreRole> UsreRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsreRole>()
               .HasOne(x => x.Users)
               .WithMany(x => x.UserRoles)
               .HasForeignKey(x=>x.UserId);

            modelBuilder.Entity<UsreRole>()
                .HasOne(x => x.Role)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<RoleClaim>()
                .HasOne(x=>x.Roles)
                .WithMany(x=>x.RoleClaims)
                .HasForeignKey(x=>x.RoleId);

            //base.OnModelCreating(modelBuilder);
        }

    }
}
