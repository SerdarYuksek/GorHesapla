using GörHesapla.Application.Interfaces.UnitOfWorks;
using GörHesapla.Domain.Entities;
using MediatR;

namespace GörHesapla.Application.Features.CompanyCQRS.Queries.GetAllCompany
{
    public class GetAllCompanyQueryHandler : IRequestHandler<GetAllCompanyQueryRequest, IList<GetAllCompanyQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllCompanyQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        async Task<IList<GetAllCompanyQueryResponse>> IRequestHandler<GetAllCompanyQueryRequest, IList<GetAllCompanyQueryResponse>>.Handle(GetAllCompanyQueryRequest request, CancellationToken cancellationToken)
        {
            var companies = await unitOfWork.GetReadRepository<Company>().GetAllAsync();

            List<GetAllCompanyQueryResponse> response = new();

            foreach (var company in companies)
                response.Add(new GetAllCompanyQueryResponse
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
                });
            return response;
        }
    }
}
