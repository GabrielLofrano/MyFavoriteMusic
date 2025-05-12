using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteMusic.Application.DTOs.Album
{
    public class AlbumDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Rate { get; set; }

    }
}
