using FluentValidation;
using MyFavoriteMusic.Application.DTOs.Artista;

namespace MyFavoriteMusic.Api.Validators.Artist
{
    public class CreateArtistRequestValidator : AbstractValidator<CreateArtistRequest>
    {
        public CreateArtistRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("The name cannot be empty");
        }
    }
}
