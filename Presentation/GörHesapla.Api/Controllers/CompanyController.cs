using GörHesapla.Application.Features.CompanyCQRS.Command.CreateCompany;
using GörHesapla.Application.Features.CompanyCQRS.Command.DeleteCompany;
using GörHesapla.Application.Features.CompanyCQRS.Command.UpdateCompany;
using GörHesapla.Application.Features.CompanyCQRS.Queries.GetAllCompany;
using GörHesapla.Application.Features.CompanyCQRS.Queries.GetCompany;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GörHesapla.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator mediator;

        public CompanyController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetAllCompanies")]
        public async Task<IActionResult> GetAllCompanies()
        {
            var response = await mediator.Send(new GetAllCompanyQueryRequest());
            return Ok(response);
        }

        [HttpGet("GetCompany")]
        public async Task<IActionResult> GetCompany(GetCompanyQueryRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompany(UpdateCompanyCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCompany(DeleteCompanyCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanyCount()
        {
            var response = await mediator.Send(new GetAllCompanyQueryRequest());
            return Ok(response);
        }
    }
}
