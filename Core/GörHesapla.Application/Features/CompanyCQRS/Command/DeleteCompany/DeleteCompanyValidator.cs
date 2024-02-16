using FluentValidation;

namespace GörHesapla.Application.Features.CompanyCQRS.Command.DeleteCompany
{
    public class DeleteCompanyValidator : AbstractValidator<DeleteCompanyCommandRequest>
    {
        public DeleteCompanyValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithName("Id");
        }
    }
}
