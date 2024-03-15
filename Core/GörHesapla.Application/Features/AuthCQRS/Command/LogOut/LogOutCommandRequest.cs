using MediatR;

namespace GörHesapla.Application.Features.AuthCQRS.Command.LogOut
{
    public class LogOutCommandRequest : IRequest<Unit>
    {
        public string Email { get; set; }
    }
}
