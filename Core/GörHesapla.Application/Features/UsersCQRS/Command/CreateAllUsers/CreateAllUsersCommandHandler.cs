using GörHesapla.Application.Interfaces.UnitOfWorks;
using GörHesapla.Domain.Entities;
using MediatR;

namespace GörHesapla.Application.Features.UsersCQRS.Command.CreateAllUsers
{
    public class CreateAllUsersCommandHandler : IRequestHandler<CreateAllUsersCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateAllUsersCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateAllUsersCommandRequest request, CancellationToken cancellationToken)
        {
            var userList = new List<User>
            {
                     new User
                     {
                         FullName = request.FullName,
                         UserName = request.UserName,
                         Email = request.Email,
                         PhoneNumber = request.PhoneNumber,
                         PasswordHash = request.Password,
                         CompanyId = request.CompanyId
                     }
            };

            await unitOfWork.GetWriteRepository<User>().AddRangeAsync(userList);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
