using GörHesapla.Application.Interfaces.UnitOfWorks;
using GörHesapla.Domain.Entities;
using MediatR;

namespace GörHesapla.Application.Features.Users.Command.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.GetReadRepository<User>().GetAsync(c => c.Id == request.Id);
            await unitOfWork.GetWriteRepository<User>().DeleteAsync(user);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
