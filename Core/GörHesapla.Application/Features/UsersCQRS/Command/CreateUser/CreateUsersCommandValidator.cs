using FluentValidation;

namespace GörHesapla.Application.Features.UsersCQRS.Command.CreateUser
{
    public class CreateUsersCommandValidator : AbstractValidator<CreateUserCommandRequest>
    {
        public CreateUsersCommandValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithName("İsim Soyİsim")
                 .MaximumLength(40)
                 .WithMessage("Maximum Karakter Uzunluğu 40 Olmalıdır");

            RuleFor(x => x.UserName).NotEmpty().WithName("Kullanıcı Adı")
                .MaximumLength(20)
                .WithMessage("Maximum Karakter Uzunluğu 20 Olmalıdır"); ;

            RuleFor(x => x.Email).NotEmpty().WithName("Şirket Maili")
                .EmailAddress()
                .WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithName("Şirket Telefonu")
                .Matches(@"^\+(?:[0-9] ?){6,14}[0-9]$")
                .WithMessage("Geçerli bir telefon numarası giriniz.")
                .Length(11)
                .WithMessage("11 Karakter Olmalıdır");

            RuleFor(x => x.Password).NotEmpty().WithName("Şifre")
                .MinimumLength(8).WithMessage("Minimum Karakter Uzunluğu 8 Olmalıdır")
                .MaximumLength(20)
                .WithMessage("Maximum Karakter Uzunluğu 20 Olmalıdır")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")
                .WithMessage("Şifre en az bir küçük harf, bir büyük harf, bir sayı ve bir özel karakter içermelidir.");

            RuleFor(x => x.RePassword).NotEmpty().WithName("Şifre Tekrar")
                .Equal(x => x.Password).WithMessage("Şifreler eşleşmiyor!");
        }
    }
}
