using MediatR;

namespace GörHesapla.Application.Features.AuthCQRS.Command.Login
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
