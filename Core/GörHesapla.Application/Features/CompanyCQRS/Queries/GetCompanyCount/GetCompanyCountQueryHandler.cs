using GörHesapla.Application.Interfaces.UnitOfWorks;
using GörHesapla.Domain.Entities;
using MediatR;

namespace GörHesapla.Application.Features.CompanyCQRS.Queries.GetCompanyCount
{
    public class GetCompanyCountQueryHandler : IRequestHandler<GetCompanyCountQueryRequest, GetCompanyCountQueryResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetCompanyCountQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<GetCompanyCountQueryResponse> Handle(GetCompanyCountQueryRequest request, CancellationToken cancellationToken)
        {
            var companyCount = await unitOfWork.GetReadRepository<Company>().CountAsync();
            var response = new GetCompanyCountQueryResponse { CompanyCount = companyCount };
            return response;
        }
    }
}
