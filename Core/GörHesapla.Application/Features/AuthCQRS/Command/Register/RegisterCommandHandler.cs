using GörHesapla.Application.Features.AuthCQRS.Command.Rules;
using GörHesapla.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GörHesapla.Application.Features.AuthCQRS.Command.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;


        public RegisterCommandHandler(AuthRules authRules, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;

        }
        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));

            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                UserName = request.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            IdentityResult result = await userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                if (!await roleManager.RoleExistsAsync("employee"))
                    await roleManager.CreateAsync(new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = "employee",
                        NormalizedName = "EMPLOYEE",
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    });
            }
            return Unit.Value;
        }
    }
}
