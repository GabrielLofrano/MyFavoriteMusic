using MyFavoriteMusic.Application.DTOs.Album;
using MyFavoriteMusic.Application.DTOs.Artista;
using MyFavoriteMusic.Application.Interfaces;
using MyFavoriteMusic.Domain.Entities;
using MyFavoriteMusic.Domain.Exceptions;
using MyFavoriteMusic.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteMusic.Application.Services
{
    public class ArtistService : Interfaces.IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<Guid> CreateAsync(CreateArtistRequest request)
        {
            var artista = new Artist
            {
                Name = request.Name,
                Description = request.Description,
                Imagem = request.Imagem,
                BirthDate = request.BirthDate,
                RegistrationDate = request.RegistrationDate,
                OriginCountry = request.OriginCountry,
                YearTraining = request.YearTraining,    
                Slug = request.Slug,
                ArtisticName = request.ArtisticName,
                Albums = request.Albums,
            };

            await _artistRepository.AddAsync(artista);

            return artista.Id;

        }

        public async Task DeleteAsync(Guid id)
        {
            var artist = await _artistRepository.GetByIdAsync(id);

            if (artist == null)
                throw new ArtistNotFoundException(id);

            await _artistRepository.DeleteAsync(artist);
        }

        public async Task<ArtistDto> GetArtistByIdAsync(Guid id)
        {
            var artist = await _artistRepository.GetByIdAsync(id);

            if (artist == null)
                throw new Exception();

            var artistDto = new ArtistDto
            {
                Name = artist.Name,
                Description = artist.Description,
                Imagem = artist.Imagem,
                BirthDate = artist.BirthDate,
                RegistrationDate = artist.RegistrationDate,
                OriginCountry = artist.OriginCountry,
                YearTraining = artist.YearTraining,
                Slug = artist.Slug,
                ArtisticName = artist.ArtisticName,
                Albums = artist.Albums?.Select(album => new AlbumDto
                {
                    Id = album.Id,
                    Title = album.Title,
                    Rate = album.Rate,
                }).ToList()
            };

            return artistDto;
        }

        public Task<ArtistDto> GetArtistByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ArtistDto>> ListArtistAsync()
        {
            var artists = await _artistRepository.GetAllAsync();

            var artistsDto = artists.Select(a => new ArtistDto
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                Imagem = a.Imagem,
                BirthDate = a.BirthDate,
                RegistrationDate = a.RegistrationDate,
                OriginCountry = a.OriginCountry,
                YearTraining = a.YearTraining,
                Slug = a.Slug,
                ArtisticName = a.ArtisticName,
                Albums = a.Albums?.Select(b => new AlbumDto
                {
                    Id = b.Id,
                    Rate = b.Rate,
                    Title = b.Title
                }).ToList() 
            }).ToList(); 

            return artistsDto;
        }

        public async Task UpdateAsync(Guid id, UpdateArtistRequest request)
        {
            var existingArtist = await _artistRepository.GetByIdAsync(id);

            if (existingArtist == null) 
                throw new ArtistNotFoundException(id);

            var artistToUpdate = existingArtist.With(
                name: request.Name,
                description: request.Description,
                imagem: request.Imagem,
                birthDate: request.BirthDate,
                registrationDate: request.RegistrationDate,
                originCountry: request.OriginCountry,
                yearTraining: request.YearTraining,
                slug: request.Slug,
                artisticName: request.ArtisticName,
                albums: request.Albums
                );

            await _artistRepository.UpdateAsync(artistToUpdate);
        }
    }
}
