using MediatR;

namespace GörHesapla.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryRequest : IRequest<IList<GetAllUsersQueryResponse>>
    {
    }
}
