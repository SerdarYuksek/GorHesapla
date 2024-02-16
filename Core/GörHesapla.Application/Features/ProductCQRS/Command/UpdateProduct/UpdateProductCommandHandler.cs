using GörHesapla.Application.Interfaces.UnitOfWorks;
using GörHesapla.Domain.Entities;
using MediatR;

namespace GörHesapla.Application.Features.ProductCQRS.Command.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var company = await unitOfWork.GetReadRepository<Product>().GetAsync(c => c.Id == request.Id);

            company.Name = request.Name;
            company.Price = request.Price;
            company.Description = request.Description;
            company.Photo = request.Photo;
            company.Weight = request.Weight;
            company.Stock = request.Stock;
            company.Manufacturer = request.Manufacturer;
            company.Category = request.Category;
            company.Color = request.Color;
            company.Material = request.Material;
            company.Size = request.Size;
            company.IsAvailable = request.IsAvailable;
            company.CompanyId = request.CompanyId;

            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
