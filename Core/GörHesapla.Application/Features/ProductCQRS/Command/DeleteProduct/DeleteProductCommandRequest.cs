using MediatR;

namespace GörHesapla.Application.Features.ProductCQRS.Command.DeleteProduct
{
    public class DeleteProductCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
