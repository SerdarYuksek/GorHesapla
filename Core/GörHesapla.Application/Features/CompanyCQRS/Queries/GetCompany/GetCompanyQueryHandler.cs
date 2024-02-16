using GörHesapla.Application.Interfaces.UnitOfWorks;
using GörHesapla.Domain.Entities;
using MediatR;

namespace GörHesapla.Application.Features.CompanyCQRS.Queries.GetCompany
{
    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQueryRequest, GetCompanyQueryResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetCompanyQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<GetCompanyQueryResponse> Handle(GetCompanyQueryRequest request, CancellationToken cancellationToken)
        {
            var company = await unitOfWork.GetReadRepository<Company>().GetAsync(c => c.Id == request.Id);
            return new GetCompanyQueryResponse
            {
                CompanyName = company.CompanyName,
                CompanyMission = company.CompanyMission,
                EmployeeCount = company.EmployeeCount,
                CompanyPhone = company.CompanyPhone,
                CompanyMail = company.CompanyMail,
                CompanyAddress = company.CompanyAddress,
                CompanyWebsite = company.CompanyWebsite,
                CompanyLogo = company.CompanyLogo,
                CompanySocialMedia = company.CompanySocialMedia
            };

        }
    }
}
