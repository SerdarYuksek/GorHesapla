using MediatR;

namespace GörHesapla.Application.Features.Users.Command.DeleteUser
{
    public class DeleteUserCommandRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
