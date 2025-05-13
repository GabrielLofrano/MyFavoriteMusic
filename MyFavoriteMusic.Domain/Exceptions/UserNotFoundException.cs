using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteMusic.Domain.Exceptions
{
    public class UserNotFoundException : DomainException
    {
        public UserNotFoundException(Guid id)
            : base($"User with ID: {id} was not found.")
        {
            
        }
    }
}
