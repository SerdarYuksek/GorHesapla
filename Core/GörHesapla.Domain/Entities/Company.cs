using System.ComponentModel.DataAnnotations;

namespace GörHesapla.Domain.Entities
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyMission { get; set; }
        public int EmployeeCount { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyMail { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyWebsite { get; set; }
        public byte[] CompanyLogo { get; set; }
        public SocialMedia CompanySocialMedia { get; set; }
    }

    public class SocialMedia
    {
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string LinkedIn { get; set; }
    }
}
