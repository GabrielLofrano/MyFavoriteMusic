using FluentValidation;
using MyFavoriteMusic.Application.DTOs.Album;

namespace MyFavoriteMusic.Api.Validators
{
    public class UpdateAlbumRequestValidator : AbstractValidator<UpdateAlbumRequest>
    {

        public UpdateAlbumRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("The title cannot be empty.");
            RuleFor(x => x.Rate).InclusiveBetween(0, 10).WithMessage("The rate have to stay between 0 and 10.");
        }

    }
}
