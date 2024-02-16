namespace GörHesapla.Application.Features.ProductCQRS.Queries.GetProduct
{
    public class GetProductsQueryResponse
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public byte[] Photo { get; set; }
    }
}
