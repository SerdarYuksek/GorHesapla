using MediatR;

namespace GörHesapla.Application.Features.Users.Queries.GetUser
{
    public class GetUserQueryRequest : IRequest<GetUserQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
