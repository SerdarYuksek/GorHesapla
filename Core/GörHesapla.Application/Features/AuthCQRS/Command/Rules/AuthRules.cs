using GörHesapla.Application.Bases;
using GörHesapla.Application.Features.AuthCQRS.Command.Exceptions;
using GörHesapla.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace GörHesapla.Application.Features.AuthCQRS.Command.Rules
{
    public class AuthRules : BaseRules
    {
        public Task EmailOrPasswordShouldNotBeInvalid(User? user, bool checkPassword)
        {
            if (user is null || checkPassword) throw new EmailOrPasswordShouldNotBeInvalidException();
            return Task.CompletedTask;
        }
        public Task UserPasswordShouldBeMatch(SignInResult result)
        {
            if (!result.Succeeded) throw new EmailOrPasswordShouldNotBeInvalidException();
            return Task.CompletedTask;
        }
        public Task RefreshTokenShouldNotBeExpired(DateTime? expiryDate)
        {
            if (expiryDate <= DateTime.Now) throw new RefreshTokenShouldNotBeExpiredException();
            return Task.CompletedTask;
        }

        public Task UserShouldNotBeExist(User? user)
        {
            if (user is not null) throw new UserAlreadyExistException();
            return Task.CompletedTask;

        }
        public Task EmailAddressShouldBeValid(User? user)
        {
            if (user is not null) throw new EmailAddressShouldBeValidException();
            return Task.CompletedTask;

        }
    }
}
