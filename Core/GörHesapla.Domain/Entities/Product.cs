using System.ComponentModel.DataAnnotations.Schema;

namespace GörHesapla.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public float Weight { get; set; }
        public int Stock { get; set; }
        public string Manufacturer { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public string Size { get; set; }
        public bool IsAvailable { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public int CompanyId { get; set; }
    }
}
