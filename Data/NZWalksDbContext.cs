using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyFirstrestFulApi.Models.Domain;

namespace MyFirstrestFulApi.Data
{

    public class NZWalksDbContext : IdentityDbContext<User>
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });


            builder.Entity<IdentityRoleClaim<string>>().ToTable((string)null!);
            builder.Entity<IdentityUserClaim<string>>().ToTable((string)null!);
            builder.Entity<IdentityUserToken<string>>().ToTable((string)null!);

        }
    }


}



// public class NZWalksDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
// {
//     public DbSet<Difficulty> Difficulties { get; set; }

//     public DbSet<Region> Regions { get; set; }

//     public DbSet<Walk> Walks { get; set; }

//     public DbSet<User> Users { get; set; }

// }