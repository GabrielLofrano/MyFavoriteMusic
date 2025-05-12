using FluentValidation;
using MyFavoriteMusic.Application.DTOs.Artista;

namespace MyFavoriteMusic.Api.Validators.Artist
{
    public class UpdateArtistRequestValidator : AbstractValidator<UpdateArtistRequest>
    {
        public UpdateArtistRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("The name cannot be empty");
        }
    }
}
