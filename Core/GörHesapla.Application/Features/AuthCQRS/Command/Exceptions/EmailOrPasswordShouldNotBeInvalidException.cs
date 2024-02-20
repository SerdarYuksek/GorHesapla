using GörHesapla.Application.Bases;

namespace GörHesapla.Application.Features.AuthCQRS.Command.Exceptions
{
    public class EmailOrPasswordShouldNotBeInvalidException : BaseException
    {
        public EmailOrPasswordShouldNotBeInvalidException() : base("Kullanıcı adı veya şifre yanlıştır!") { }

    }
}
