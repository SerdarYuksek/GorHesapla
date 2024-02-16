using FluentValidation;

namespace GörHesapla.Application.Features.CompanyCQRS.Command.CreateCompany
{
    public class CreateCompanyValidator : AbstractValidator<CreateCompanyCommandRequest>
    {
        public CreateCompanyValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithName("Şirket Adı")
            .MaximumLength(70)
            .WithMessage("Maximum Karakter Uzunluğu 70 Olmalıdır");

            RuleFor(x => x.CompanyMission).NotEmpty().WithName("Şirket Açıklaması")
                .MaximumLength(150)
                .WithMessage("Maximum Karakter Uzunluğu 150 Olmalıdır");

            RuleFor(x => x.CompanyPhone).NotEmpty().WithName("Şirket Telefonu")
                .Matches(@"^\+(?:[0-9] ?){6,14}[0-9]$")
                .WithMessage("Geçerli bir telefon numarası giriniz.")
                .Length(11)
                .WithMessage("11 Karakter Olmalıdır");

            RuleFor(x => x.CompanyMail).NotEmpty().WithName("Şirket Maili")
                .EmailAddress()
                .WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(x => x.CompanyAddress).NotEmpty().WithName("Şirket Adresi")
                .MaximumLength(250)
                .WithMessage("Şirket Adresi en fazla 250 karakter olmalıdır.");

            RuleFor(x => x.CompanyLogo).NotEmpty().WithName("Şirket Logosu");
        }
    }
}
