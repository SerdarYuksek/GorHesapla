using GörHesapla.Application.Interfaces.UnitOfWorks;
using GörHesapla.Domain.Entities;
using MediatR;

namespace GörHesapla.Application.Features.ProductCQRS.Queries.GetProductsCount
{
    public class GetProductsCountQueryHandler : IRequestHandler<GetProductsCountQueryRequest, GetProductsCountQueryResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetProductsCountQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<GetProductsCountQueryResponse> Handle(GetProductsCountQueryRequest request, CancellationToken cancellationToken)
        {
            var productCount = await unitOfWork.GetReadRepository<Product>().CountAsync();
            var response = new GetProductsCountQueryResponse { ProductCount = productCount };
            return response;
        }
    }
}
