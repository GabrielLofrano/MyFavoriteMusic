using MyFavoriteMusic.Application.DTOs.User;
using MyFavoriteMusic.Application.Interfaces;
using MyFavoriteMusic.Domain.Entities;
using MyFavoriteMusic.Domain.Exceptions;
using MyFavoriteMusic.Domain.Interfaces;
using System.Runtime.InteropServices;

namespace MyFavoriteMusic.Application.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<Guid> CreatAsync(CreateUserRequest request)
    {
        var user = new User(request.UserName, request.PasswordHash, request.Email, request.RegistrationDate, request.Role);

        await _userRepository.AddAsync(user);

        return user.Id;
    }

    public async Task DeleteUserAsync(Guid id)
    {
        var userToDelete = await _userRepository.GetByIdAsync(id);

        if (userToDelete == null) 
            throw new UserNotFoundException(id);

        await _userRepository.DeleteAsync(userToDelete);
    }

    public async Task<UserDto> GetUserByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        var userDto = new UserDto
        {
            UserName = user.UserName,
            PasswordHash = user.PasswordHash,
            Email = user.Email,
            RegistrationDate = user.RegistrationDate,
            Role = user.Role
        };

        return userDto;
    }

    public async Task<UserDto> GetUserByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserDto>> ListUsersAsync()
    {
        var user = await _userRepository.GetAllAsync();

        var usersDto = user.Select(a => new UserDto
        {
            UserName = a.UserName,
            PasswordHash = a.PasswordHash,
            Email = a.Email,
            RegistrationDate = a.RegistrationDate,
            Role = a.Role
        });

        return usersDto;
    }

    public async Task UpdateUserAsync(Guid id, UpdateUserRequest request)
    {
        var userToUpdate = await _userRepository.GetByIdAsync(id);

        if (userToUpdate == null)
            throw new UserNotFoundException(id);

        userToUpdate.ChangeUserName(request.UserName);
        userToUpdate.ChangePassword(request.PasswordHash);
        userToUpdate.ChangeRole(request.Role);

        await _userRepository.UpdateAsync(userToUpdate);

    }
}
