using MyFavoriteMusic.Application.Interfaces;
using MyFavoriteMusic.Application.Services;
using MyFavoriteMusic.Domain.Interfaces;
using MyFavoriteMusic.Infrastructure.Persistence.Repositories;

namespace MyFavoriteMusic.Api.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiConfiguration (this IServiceCollection services)
        {

            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
