using GörHesapla.Application.Interfaces.UnitOfWorks;
using GörHesapla.Domain.Entities;
using MediatR;

namespace GörHesapla.Application.Features.Users.Queries.GetUsersCount
{
    public class GetUsersCountQueryHandler : IRequestHandler<GetUsersCountQueryRequest, GetUsersCountQueryResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetUsersCountQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<GetUsersCountQueryResponse> Handle(GetUsersCountQueryRequest request, CancellationToken cancellationToken)
        {
            var userCount = await unitOfWork.GetReadRepository<User>().CountAsync(p => p.CompanyId == request.CompanyId);
            var response = new GetUsersCountQueryResponse { UserCount = userCount };
            return response;
        }
    }
}
