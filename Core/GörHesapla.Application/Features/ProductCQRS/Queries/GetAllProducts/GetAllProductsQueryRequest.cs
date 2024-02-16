using MediatR;

namespace GörHesapla.Application.Features.ProductCQRS.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<IList<GetAllProductsQueryResponse>>
    {
    }
}
