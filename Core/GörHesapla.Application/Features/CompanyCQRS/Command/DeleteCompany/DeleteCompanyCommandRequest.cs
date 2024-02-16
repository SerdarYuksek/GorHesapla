using MediatR;

namespace GörHesapla.Application.Features.CompanyCQRS.Command.DeleteCompany
{
    public class DeleteCompanyCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
