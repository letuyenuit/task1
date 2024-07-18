using Microsoft.EntityFrameworkCore;
using netcore_devsecops.Models;

namespace netcore_devsecops.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Permission>().HasData(new List<Permission>()
            {
                new Permission()
                {
                    IdPermission = new Guid("f87ac10b-67cc-4372-a567-0e02b2c3d479"),
                    Name = Policy.admin.ToString(),
                },
                new Permission()
                {
                    IdPermission = new Guid("f49ac10b-68cc-4372-a567-0e02b2c3d479"),
                    Name = Policy.finance.ToString(),
                }
            });
            builder.Entity<Role>().HasData(new List<Role>()
            {
                new Role()
                {
                    IdRole = new Guid("f47ac10b-67cc-4372-a567-0e02b2c3d479"),
                    Name = "ADMIN",
                },
                new Role()
                {
                    IdRole = new Guid("f47ac10b-68cc-4372-a567-0e02b2c3d479"),
                    Name = "FINANCER",
                }
            });
            builder.Entity<RolePermission>().HasData(new List<RolePermission>()
            {
                new RolePermission()
                {
                    IdRole = new Guid("f47ac10b-67cc-4372-a567-0e02b2c3d479"),
                    IdPermission= new Guid("f87ac10b-67cc-4372-a567-0e02b2c3d479"),
                    IsAccessed = true
                },
                new RolePermission()
                {
                    IdRole = new Guid("f47ac10b-67cc-4372-a567-0e02b2c3d479"),
                    IdPermission= new Guid("f49ac10b-68cc-4372-a567-0e02b2c3d479"),
                    IsAccessed = true
                },

                new RolePermission()
                {
                    IdRole = new Guid("f47ac10b-68cc-4372-a567-0e02b2c3d479"),
                    IdPermission= new Guid("f87ac10b-67cc-4372-a567-0e02b2c3d479"),
                    IsAccessed = true
                },
                new RolePermission()
                {
                    IdRole = new Guid("f47ac10b-68cc-4372-a567-0e02b2c3d479"),
                    IdPermission= new Guid("f49ac10b-68cc-4372-a567-0e02b2c3d479"),
                    IsAccessed = true
                }
            });
            builder.Entity<User>().HasData(new List<User>()
            {
                new User()
                {
                   IdUser = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"),
                   Email = "letuyenkhtn212@gmail.com",
                   Password = "1234",
                   IdRole  = new Guid("f47ac10b-67cc-4372-a567-0e02b2c3d479")
                },

                new User()
                {
                   IdUser = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d487"),
                   Email = "test@gmail.com",
                   Password = "1234",
                   IdRole  = new Guid("f47ac10b-68cc-4372-a567-0e02b2c3d479")

                }
            });
        }
    }
}
