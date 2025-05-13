using Microsoft.AspNetCore.Mvc;
using MyFavoriteMusic.Api.Common;
using MyFavoriteMusic.Application.DTOs.User;
using MyFavoriteMusic.Application.Interfaces;
using MyFavoriteMusic.Application.Services;
using MyFavoriteMusic.Domain.Entities;
using MyFavoriteMusic.Domain.Exceptions;

namespace MyFavoriteMusic.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var users = await _userService.ListUsersAsync();

        if (users == null)
            return NotFound(ApiResponse<string>.FailureResponse("No user were found"));

        return Ok(ApiResponse<IEnumerable<UserDto>>.SuccessResponse(users, "User found successfully"));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        if (user == null)
            return NotFound(ApiResponse<string>.FailureResponse("No user were found"));

        return Ok(ApiResponse<UserDto>.SuccessResponse(user, "User found successfully"));
    }

    [HttpPost]
    public async Task<ActionResult> AddUser([FromBody] CreateUserRequest request)
    {
        var userId = await _userService.CreatAsync(request);

        if (userId == Guid.Empty)
            return NotFound(ApiResponse<string>.FailureResponse("The Id in the URL doesn`t match the Id in the body"));

        return CreatedAtAction(nameof(GetById), new { id = userId },
                ApiResponse<Guid>.SuccessResponse(userId, "User created successfully"));
    }

    [HttpPut]
    public async Task<ActionResult> UpdateUser([FromBody] UpdateUserRequest request, Guid id)
    {
        try
        {
            await _userService.UpdateUserAsync(id, request);

            if (id == Guid.Empty)
                return NotFound(ApiResponse<string>.FailureResponse("The Id in the URL doesn`t match the Id in the body"));

            return NoContent();
        }
        catch (UserNotFoundException)
        {
            return NotFound(ApiResponse<string>.FailureResponse("User not found."));
        }
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteUser(Guid id)
    {
        try
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
        catch (Exception)
        {

            return NotFound(ApiResponse<string>.FailureResponse("User not found."));
        }
    }
}
