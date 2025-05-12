using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteMusic.Domain.Exceptions
{
    public class ArtistNotFoundException : DomainException
    {
        public ArtistNotFoundException(Guid id)
            :base($"Artist with ID {id} was not found.")
        {
            
        }
    }
}
