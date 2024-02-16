using MediatR;

namespace GörHesapla.Application.Features.CompanyCQRS.Queries.GetAllCompany
{
    public class GetAllCompanyQueryRequest : IRequest<IList<GetAllCompanyQueryResponse>>
    {
    }
}
