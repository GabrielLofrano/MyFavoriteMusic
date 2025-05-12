using Microsoft.AspNetCore.Mvc;
using MyFavoriteMusic.Api.Common;
using MyFavoriteMusic.Application.DTOs.Artista;
using MyFavoriteMusic.Application.Interfaces;
using MyFavoriteMusic.Domain.Exceptions;

namespace MyFavoriteMusic.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var artist = await _artistService.ListArtistAsync();

            if (artist == null)
            {
                return NotFound(ApiResponse<string>.FailureResponse("No artist were found"));
            }

            return Ok(ApiResponse<IEnumerable<ArtistDto>>.SuccessResponse(artist, "Artist found successfully"));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            try
            {
                var artist = await _artistService.GetArtistByIdAsync(id);

                return Ok(ApiResponse<ArtistDto>.SuccessResponse(artist, "Artist found successfully"));
            }
            catch (ArtistNotFoundException)
            {
                return NotFound(ApiResponse<string>.FailureResponse($"ArtistNotFound {id}"));
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddArtist([FromBody] CreateArtistRequest request)
        {
            var artistId = await _artistService.CreateAsync(request);

            if (artistId == Guid.Empty)
                return NotFound(ApiResponse<string>.FailureResponse("The Id in the URL doesn't match the Id in the body."));

            return CreatedAtAction(nameof(GetById), new { id = artistId },
                ApiResponse<Guid>.SuccessResponse(artistId, "Artist created successfully"));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateArtist([FromBody] UpdateArtistRequest request, Guid id)
        {
            try
            {
                await _artistService.UpdateAsync(id, request);

                if (id == Guid.Empty)
                    return NotFound(ApiResponse<string>.FailureResponse("The Id in the URL doesn`t match the Id in the body"));

                return NoContent();
            }
            catch (ArtistNotFoundException)
            {
                return NotFound(ApiResponse<string>.FailureResponse("Artist not found."));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAlbum(Guid id)
        {
            try
            {
                await _artistService.DeleteAsync(id);
                return NoContent();
            }
            catch (ArtistNotFoundException)
            {

                return NotFound(ApiResponse<string>.FailureResponse("Artist not found."));
            }
        }

    }

    
}
