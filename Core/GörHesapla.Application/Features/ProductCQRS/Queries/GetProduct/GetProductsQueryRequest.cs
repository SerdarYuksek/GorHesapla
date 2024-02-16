using MediatR;

namespace GörHesapla.Application.Features.ProductCQRS.Queries.GetProduct
{
    public class GetProductsQueryRequest : IRequest<GetProductsQueryResponse>
    {
        public int Id { get; set; }
    }
}
