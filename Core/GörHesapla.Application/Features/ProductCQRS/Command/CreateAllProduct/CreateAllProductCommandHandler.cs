using GörHesapla.Application.Interfaces.UnitOfWorks;
using GörHesapla.Domain.Entities;
using MediatR;

namespace GörHesapla.Application.Features.ProductCQRS.Command.CreateAllProduct
{
    public class CreateAllProductCommandHandler : IRequestHandler<CreateAllProductCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateAllProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateAllProductCommandRequest request, CancellationToken cancellationToken)
        {
            var productList = new List<Product>
            {
                     new Product
                     {
                          Name = request.Name,
                          Price = request.Price,
                          Description = request.Description,
                          Photo = request.Photo,
                          Weight = request.Weight,
                          Stock = request.Stock,
                          Manufacturer = request.Manufacturer,
                          Category = request.Category,
                          Color = request.Color,
                          Material = request.Material,
                          Size = request.Size,
                          IsAvailable = request.IsAvailable,
                          CompanyId = request.CompanyId
                     }
            };

            await unitOfWork.GetWriteRepository<Product>().AddRangeAsync(productList);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
