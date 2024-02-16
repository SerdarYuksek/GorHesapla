using GörHesapla.Application.Interfaces.UnitOfWorks;
using GörHesapla.Domain.Entities;
using MediatR;

namespace GörHesapla.Application.Features.CompanyCQRS.Command.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateCompanyCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            var company = await unitOfWork.GetReadRepository<Company>().GetAsync(c => c.Id == request.Id);

            company.CompanyName = request.CompanyName;
            company.CompanyMission = request.CompanyMission;
            company.EmployeeCount = request.EmployeeCount;
            company.CompanyPhone = request.CompanyPhone;
            company.CompanyMail = request.CompanyMail;
            company.CompanyAddress = request.CompanyAddress;
            company.CompanyWebsite = request.CompanyWebsite;
            company.CompanyLogo = request.CompanyLogo;
            company.CompanySocialMedia = request.CompanySocialMedia;

            await unitOfWork.GetWriteRepository<Company>().UpdateAsync(company);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
