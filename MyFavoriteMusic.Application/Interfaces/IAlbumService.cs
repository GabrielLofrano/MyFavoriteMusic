﻿using MyFavoriteMusic.Api.DTOs.Album;
using MyFavoriteMusic.Application.DTOs.Album;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteMusic.Application.Interfaces
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumDto>> ListAlbunsAsync();
        Task<AlbumDto> GetAlbumByIdAsync(Guid id);
        Task<AlbumDto> GetAlbumByNameAsync(string name);
        Task<Guid> CreateAsync(CreateAlbumRequest request);
        Task UpdateAsync(Guid id, UpdateAlbumRequest request);
        Task DeleteAsync(Guid id);
    }
}
