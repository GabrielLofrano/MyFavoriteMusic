using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MyFavoriteMusic.Infrastructure.Persistence.Contexts
{
    public class MyFavoriteMusicContextFactory : IDesignTimeDbContextFactory<MyFavoriteMusicContext>
    {
        public MyFavoriteMusicContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyFavoriteMusicContext>();
            optionsBuilder.UseSqlServer("Server=MANGA-GABRIEL;Database=MyFavoriteMusicDb;Trusted_Connection=True;TrustServerCertificate=True;");

            return new MyFavoriteMusicContext(optionsBuilder.Options);
        }
    }
}