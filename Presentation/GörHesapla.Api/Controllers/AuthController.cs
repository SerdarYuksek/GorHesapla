using GörHesapla.Application.Features.AuthCQRS.Command.Login;
using GörHesapla.Application.Features.AuthCQRS.Command.LogOut;
using GörHesapla.Application.Features.AuthCQRS.Command.RefreshToken;
using GörHesapla.Application.Features.AuthCQRS.Command.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace GörHesapla.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> LogOut(LogOutCommandRequest request)
        {
            return Ok(await mediator.Send(request));
        }
    }
}
