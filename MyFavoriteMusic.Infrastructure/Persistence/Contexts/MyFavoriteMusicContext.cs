using Microsoft.EntityFrameworkCore;
using MyFavoriteMusic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteMusic.Infrastructure.Persistence.Contexts
{
    public class MyFavoriteMusicContext : DbContext
    {
        public MyFavoriteMusicContext(DbContextOptions<MyFavoriteMusicContext> options)
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyFavoriteMusicContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
