using GörHesapla.Application.Interfaces.UnitOfWorks;
using GörHesapla.Domain.Entities;
using MediatR;

namespace GörHesapla.Application.Features.CompanyCQRS.Command.DeleteCompany
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteCompanyCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            var company = await unitOfWork.GetReadRepository<Company>().GetAsync(c => c.Id == request.Id);
            await unitOfWork.GetWriteRepository<Company>().DeleteAsync(company);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
