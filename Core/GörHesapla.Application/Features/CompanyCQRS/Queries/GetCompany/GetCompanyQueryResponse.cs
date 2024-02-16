using GörHesapla.Domain.Entities;

namespace GörHesapla.Application.Features.CompanyCQRS.Queries.GetCompany
{
    public class GetCompanyQueryResponse
    {
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
}
