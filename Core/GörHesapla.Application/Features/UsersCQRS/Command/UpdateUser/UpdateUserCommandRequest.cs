using MediatR;

namespace GörHesapla.Application.Features.Users.Command.UpdateUser
{
    public class UpdateUserCommandRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CompanyId { get; set; }
    }
}
