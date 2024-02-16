namespace GörHesapla.Application.Features.ProductCQRS.Queries.GetAllProducts
{
    public class GetAllProductsQueryResponse
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public byte[] Photo { get; set; }
    }
}
