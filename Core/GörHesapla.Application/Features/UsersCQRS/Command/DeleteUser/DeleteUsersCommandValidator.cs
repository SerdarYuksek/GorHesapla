using FluentValidation;
using GörHesapla.Application.Features.Users.Command.DeleteUser;

namespace GörHesapla.Application.Features.UsersCQRS.Command.DeleteUser
{
    public class DeleteUsersCommandValidator : AbstractValidator<DeleteUserCommandRequest>
    {
        public DeleteUsersCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithName("Id");
        }
    }
}
