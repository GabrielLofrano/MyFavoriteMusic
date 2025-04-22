using Microsoft.AspNetCore.Mvc;
using MyFavoriteMusic.Api.Common;
using MyFavoriteMusic.Api.DTOs.Album;
using MyFavoriteMusic.Application.DTOs.Album;
using MyFavoriteMusic.Application.Interfaces;
using MyFavoriteMusic.Domain.Entities;
using MyFavoriteMusic.Domain.Exceptions;

namespace MyFavoriteMusic.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var albuns = await _albumService.ListAlbunsAsync();

            if (albuns == null) 
            {
                return NotFound(ApiResponse<string>.FailureResponse("No album were found"));
            }
            return Ok(ApiResponse<IEnumerable<AlbumDto>>.SuccessResponse(albuns, "Albuns found successfully"));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var album = await _albumService.GetAlbumByIdAsync(id);

                return Ok(ApiResponse<AlbumDto>.SuccessResponse(album, "Album found successfully"));
            }
            catch (AlbumNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.FailureResponse("Album not found"));
            }


        }

        [HttpPost]
        public async Task<ActionResult> AddAlbum([FromBody] CreateAlbumRequest request)
        {
            var albumId = await _albumService.CreateAsync(request);

            if (albumId == 0)
            {
                return BadRequest(ApiResponse<string>.FailureResponse("Failed to create album"));
            }

            return CreatedAtAction(nameof(GetById), new {id = albumId}, 
                ApiResponse<int>.SuccessResponse(albumId, "Album created successfully"));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAlbum([FromBody] UpdateAlbumRequest request, int id)
        {
            try
            {
                await _albumService.UpdateAsync(id, request);

                if (id != request.Id)
                    return NotFound(ApiResponse<string>.FailureResponse("The Id in the URL doesn't match the Id in the body."));

                return NoContent();
            }
            catch (AlbumNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.FailureResponse("Album not found."));
            }

            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAlbum(int id)
        {
            try
            {
                await _albumService.DeleteAsync(id);
                return NoContent();


            }
            catch (AlbumNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.FailureResponse("Album not found."));
            }


        }

        [HttpGet("force-error")]
        public IActionResult ForceError()
        {
            throw new Exception("This is a test exception!");
        }
    }
}
