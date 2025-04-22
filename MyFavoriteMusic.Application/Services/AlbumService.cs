using MyFavoriteMusic.Api.DTOs.Album;
using MyFavoriteMusic.Application.DTOs.Album;
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
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<int> CreateAsync(CreateAlbumRequest request)
        {
            var album = new Album(request.Title, request.Rate);

            await _albumRepository.AddAsync(album);

            return album.Id;
        }

        public async Task<AlbumDto> GetAlbumByIdAsync(int id)
        {
            var album = await _albumRepository.GetByIdAsync(id);

            if (album == null)
                throw new AlbumNotFoundException(id);

            var albunsDto = new AlbumDto
            {
                Id = album.Id,
                Title = album.Title,
                Rate = album.Rate
            };

            return albunsDto;
        }

        public Task<AlbumDto> GetAlbumByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AlbumDto>> ListAlbunsAsync()
        {
            var albuns = await _albumRepository.GetAllAsync();

            var albunsDto = albuns.Select(a => new AlbumDto
            {
                Id = a.Id,
                Title = a.Title,
                Rate = a.Rate
            });

            return albunsDto;
        }
        public async Task UpdateAsync(int id, UpdateAlbumRequest request)
        {
            var albumToEdit = await _albumRepository.GetByIdAsync(id);

            if (albumToEdit == null)
                throw new AlbumNotFoundException(id);

            albumToEdit.ChangeTitle(request.Title);
            albumToEdit.ChangeRate(request.Rate);

            await _albumRepository.UpdateAsync(albumToEdit);
        }

        public async Task DeleteAsync(int id)
        {
            var albumToDelete = await _albumRepository.GetByIdAsync(id);

            if (albumToDelete == null)
                throw new AlbumNotFoundException(id);

            await _albumRepository.DeleteAsync(albumToDelete);
        }
    }
}
