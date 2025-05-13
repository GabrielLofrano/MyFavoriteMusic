using FluentValidation;
using MyFavoriteMusic.Application.DTOs.User;

namespace MyFavoriteMusic.Api.Validators.User
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("The name cannot be empty");
            RuleFor(x => x.PasswordHash).NotEmpty().MinimumLength(6).NotNull();
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("The email cannot be empty");
        }
    }
}
