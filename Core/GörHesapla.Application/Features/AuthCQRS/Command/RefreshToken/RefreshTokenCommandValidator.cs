using FluentValidation;

namespace GörHesapla.Application.Features.AuthCQRS.Command.RefreshToken
{
    public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommandRequest>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty();

            RuleFor(x => x.AccessToken).NotEmpty();
        }
    }
}
