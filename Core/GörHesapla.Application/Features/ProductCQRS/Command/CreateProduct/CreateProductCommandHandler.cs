using GörHesapla.Application.Interfaces.UnitOfWorks;
using GörHesapla.Domain.Entities;
using MediatR;

namespace GörHesapla.Application.Features.ProductCQRS.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await unitOfWork.GetWriteRepository<Product>().AddAsync(new()
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

            });
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
