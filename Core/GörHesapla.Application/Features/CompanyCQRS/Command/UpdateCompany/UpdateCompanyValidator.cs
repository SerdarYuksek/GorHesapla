using FluentValidation;

namespace GörHesapla.Application.Features.CompanyCQRS.Command.UpdateCompany
{
    public class UpdateCompanyValidator : AbstractValidator<UpdateCompanyCommandRequest>
    {
        public UpdateCompanyValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithName("Id");

            RuleFor(x => x.CompanyName).NotEmpty().WithName("Şirket Adı")
            .MaximumLength(70)
            .WithName("Şirket Adı");

            RuleFor(x => x.CompanyMission).NotEmpty().WithName("Şirket Açıklaması")
                .MaximumLength(70)
                .WithName("Şirket Adı");

            RuleFor(x => x.CompanyPhone).NotEmpty().WithName("Şirket Telefonu")
                .Matches(@"^\+(?:[0-9] ?){6,14}[0-9]$")
                .WithMessage("Geçerli bir telefon numarası giriniz.");

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
