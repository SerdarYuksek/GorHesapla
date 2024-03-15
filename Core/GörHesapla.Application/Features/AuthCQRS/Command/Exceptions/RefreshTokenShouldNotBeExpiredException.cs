using GörHesapla.Application.Bases;

namespace GörHesapla.Application.Features.AuthCQRS.Command.Exceptions
{
    public class RefreshTokenShouldNotBeExpiredException : BaseException
    {

        public RefreshTokenShouldNotBeExpiredException() : base("Oturum süresi sona ermiştir. Lütfen tekrar giriş yapın!") { }
    }
}
