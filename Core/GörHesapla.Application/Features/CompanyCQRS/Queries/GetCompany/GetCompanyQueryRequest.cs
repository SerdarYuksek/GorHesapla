using MediatR;

namespace GörHesapla.Application.Features.CompanyCQRS.Queries.GetCompany
{
    public class GetCompanyQueryRequest : IRequest<GetCompanyQueryResponse>
    {
        public int Id { get; set; }
    }
}
