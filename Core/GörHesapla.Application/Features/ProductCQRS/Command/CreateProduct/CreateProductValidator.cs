using FluentValidation;

namespace GörHesapla.Application.Features.ProductCQRS.Command.CreateProduct
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithName("Ürün Adı")
            .MaximumLength(70)
            .WithMessage("Maximum Karakter Uzunluğu 70 Olmalıdır");

            RuleFor(x => x.Price).NotEmpty().WithName("Şirket Adı");

            RuleFor(x => x.Description).NotEmpty().WithName("Ürün Açıklaması")
            .MaximumLength(100)
            .WithMessage("Maximum Karakter Uzunluğu 150 Olmalıdır.");

            RuleFor(x => x.Weight).NotEmpty().WithName("Ağırlık");

            RuleFor(x => x.Stock).NotEmpty().WithName("Ürün Stoğu");

            RuleFor(x => x.Manufacturer).NotEmpty().WithName("Üretici")
                .MaximumLength(70)
                .WithMessage("Maximum Karakter Uzunluğu 70 Olmalıdır");

            RuleFor(x => x.Category).NotEmpty().WithName("Kategori")
                .MaximumLength(20)
                .WithMessage("Maximum Karakter Uzunluğu 20 Olmalıdır");

            RuleFor(x => x.Color).NotEmpty().WithName("Renk")
                .MaximumLength(15)
                .WithMessage("Maximum Karakter Uzunluğu 15 Olmalıdır");

            RuleFor(x => x.Material).NotEmpty().WithName("Material")
                .MaximumLength(40)
                .WithMessage("Maximum Karakter Uzunluğu 40 Olmalıdır");

            RuleFor(x => x.Size).NotEmpty().WithName("Büyüklük")
                .MaximumLength(5)
                .WithMessage("Maximum Karakter Uzunluğu 5 Olmalıdır");
        }
    }
}
