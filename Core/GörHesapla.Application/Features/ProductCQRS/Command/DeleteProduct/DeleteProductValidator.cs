using FluentValidation;

namespace GörHesapla.Application.Features.ProductCQRS.Command.DeleteProduct
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductCommandRequest>
    {
        public DeleteProductValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithName("Id");
        }
    }
}
