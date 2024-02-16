using GörHesapla.Application.Interfaces.UnitOfWorks;
using GörHesapla.Domain.Entities;
using MediatR;

namespace GörHesapla.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryRequest, IList<GetAllUsersQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllUsersQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<GetAllUsersQueryResponse>> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
        {
            var users = await unitOfWork.GetReadRepository<User>().GetAllAsync();

            List<GetAllUsersQueryResponse> response = new();

            foreach (var user in users)
                response.Add(new GetAllUsersQueryResponse
                {
                    FullName = user.FullName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber
                });
            return response;
        }
    }
}
