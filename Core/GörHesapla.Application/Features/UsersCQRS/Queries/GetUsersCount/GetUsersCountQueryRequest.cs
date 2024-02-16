using MediatR;

namespace GörHesapla.Application.Features.Users.Queries.GetUsersCount
{
    public class GetUsersCountQueryRequest : IRequest<GetUsersCountQueryResponse>
    {
        public int CompanyId { get; set; }
    }
}
