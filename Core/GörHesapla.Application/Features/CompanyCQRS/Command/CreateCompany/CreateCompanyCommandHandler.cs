using GörHesapla.Application.Interfaces.UnitOfWorks;
using GörHesapla.Domain.Entities;
using MediatR;

namespace GörHesapla.Application.Features.CompanyCQRS.Command.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateCompanyCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            await unitOfWork.GetWriteRepository<Company>().AddAsync(new()
            {
                CompanyName = request.CompanyName,
                CompanyMission = request.CompanyMission,
                EmployeeCount = request.EmployeeCount,
                CompanyPhone = request.CompanyPhone,
                CompanyMail = request.CompanyMail,
                CompanyAddress = request.CompanyAddress,
                CompanyWebsite = request.CompanyWebsite,
                CompanyLogo = request.CompanyLogo,
                CompanySocialMedia = request.CompanySocialMedia
            });
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
