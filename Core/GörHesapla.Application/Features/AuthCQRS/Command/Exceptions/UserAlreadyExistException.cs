using GörHesapla.Application.Bases;

namespace GörHesapla.Application.Features.AuthCQRS.Command.Exceptions
{
    public class UserAlreadyExistException : BaseException
    {
        public UserAlreadyExistException() : base("Kullanıcı zaten mevcut!") { }
    }
}
