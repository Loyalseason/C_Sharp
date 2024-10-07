using Microsoft.EntityFrameworkCore;
using MyFirstrestFulApi.Models.Domain;

namespace MyFirstrestFulApi.Data
{
    public class NZWalksDbContext(DbContextOptions dbContextOptions): DbContext(dbContextOptions)
    {
        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region>   Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }
    }
     
}


// public class NZWalksDbContext : DbContext
// {
//     public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
//     {
//     }

//     public DbSet<Difficulty> Difficulties { get; set; }
//     public DbSet<Region> Regions { get; set; }
//     public DbSet<Walk> Walks { get; set; }
// }
