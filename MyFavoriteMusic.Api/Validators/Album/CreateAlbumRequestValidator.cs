using FluentValidation;
using MyFavoriteMusic.Api.DTOs.Album;

namespace MyFavoriteMusic.Api.Validators.Album
{
    public class CreateAlbumRequestValidator : AbstractValidator<CreateAlbumRequest>
    {
        public CreateAlbumRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("The title cannot be empty.");
            RuleFor(x => x.Rate).InclusiveBetween(0, 10).WithMessage("The rate have to stay between 0 and 10.");
        }
    }
}
