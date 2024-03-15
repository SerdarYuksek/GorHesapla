using GörHesapla.Application.Features.AuthCQRS.Command.Rules;
using GörHesapla.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GörHesapla.Application.Features.AuthCQRS.Command.LogOut
{
    public class LogOutCommandHandler : IRequestHandler<LogOutCommandRequest, Unit>
    {
        private readonly UserManager<User> userManager;
        private readonly AuthRules authRules;

        public LogOutCommandHandler(UserManager<User> userManager, AuthRules authRules)
        {
            this.userManager = userManager;
            this.authRules = authRules;
        }
        public async Task<Unit> Handle(LogOutCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await userManager.FindByEmailAsync(request.Email);
            await authRules.EmailAddressShouldBeValid(user);

            user.RefreshToken = null;
            await userManager.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
