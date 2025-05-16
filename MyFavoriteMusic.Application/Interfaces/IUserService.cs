using MyFavoriteMusic.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteMusic.Application.Interfaces;
public interface IUserService
{
    Task<IEnumerable<UserDto>> ListUsersAsync();
    Task<UserDto> GetUserByIdAsync(Guid id);
    Task<UserDto> GetUserByNameAsync(string name);
    Task<Guid> CreatAsync(CreateUserRequest request);
    Task UpdateUserAsync(Guid id, UpdateUserRequest request);
    Task DeleteUserAsync(Guid id);
}
