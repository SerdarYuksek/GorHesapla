using MediatR;

namespace GörHesapla.Application.Features.AuthCQRS.Command.Register
{
    public class RegisterCommandRequest : IRequest<Unit>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
