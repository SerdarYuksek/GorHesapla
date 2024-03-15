using GörHesapla.Application.Features.Users.Command.DeleteUser;
using GörHesapla.Application.Features.Users.Command.UpdateUser;
using GörHesapla.Application.Features.Users.Queries.GetAllUsers;
using GörHesapla.Application.Features.Users.Queries.GetUser;
using GörHesapla.Application.Features.Users.Queries.GetUsersCount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GörHesapla.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await mediator.Send(new GetAllUsersQueryRequest());
            return Ok(response);
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(GetUserQueryRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(DeleteUserCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetUserCount(GetUsersCountQueryRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
