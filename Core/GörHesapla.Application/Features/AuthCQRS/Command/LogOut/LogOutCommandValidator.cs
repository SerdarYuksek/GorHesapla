using FluentValidation;

namespace GörHesapla.Application.Features.AuthCQRS.Command.LogOut
{
    public class LogOutCommandValidator : AbstractValidator<LogOutCommandRequest>
    {
        public LogOutCommandValidator()
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
        }
    }
}
