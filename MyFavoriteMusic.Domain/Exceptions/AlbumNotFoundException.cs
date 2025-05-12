using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteMusic.Domain.Exceptions
{
    public class AlbumNotFoundException : DomainException
    {
        public AlbumNotFoundException(Guid id)
            :base($"Album with ID {id} was not found.")
        {
            
        }
    }
}
