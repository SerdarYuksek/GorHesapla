using GörHesapla.Application.Features.AuthCQRS.Command.Rules;
using GörHesapla.Application.Interfaces.Tokens;
using GörHesapla.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace GörHesapla.Application.Features.AuthCQRS.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly AuthRules authRules;
        private readonly IConfiguration configuration;
        private readonly ITokenService tokenService;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;


        public LoginCommandHandler(AuthRules authRules, IConfiguration configuration, ITokenService tokenService, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            this.authRules = authRules;
            this.configuration = configuration;
            this.tokenService = tokenService;
            this.userManager = userManager;
            this.roleManager = roleManager;

        }
        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await userManager.FindByEmailAsync(request.Email);
            bool checkPassword = await userManager.CheckPasswordAsync(user, request.Password);

            await authRules.EmailOrPasswordShouldNotBeInvalid(user, checkPassword);

            IList<string> roles = await userManager.GetRolesAsync(user);

            JwtSecurityToken token = await tokenService.CreateToken(user, roles);
            string refreshToken = tokenService.GenerateRefreshToken();

            _ = int.TryParse(configuration["JWT:RefreshTokenValiityInDays"], out int RefreshTokenValiityInDays);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(RefreshTokenValiityInDays);

            await userManager.UpdateAsync(user);
            await userManager.UpdateSecurityStampAsync(user);

            string _token = new JwtSecurityTokenHandler().WriteToken(token);

            await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);

            return new()
            {
                Token = _token,
                RefreshToken = refreshToken,
                Expiration = token.ValidTo
            };
        }
    }
}
