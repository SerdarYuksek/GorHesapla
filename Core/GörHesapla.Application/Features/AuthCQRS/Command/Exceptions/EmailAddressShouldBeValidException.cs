using GörHesapla.Application.Bases;

namespace GörHesapla.Application.Features.AuthCQRS.Command.Exceptions
{
    public class EmailAddressShouldBeValidException : BaseException
    {

        public EmailAddressShouldBeValidException() : base("Böyle bir Email adresi bulunamamıştır!") { }
    }
}
