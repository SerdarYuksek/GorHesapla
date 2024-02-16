using FluentValidation;
using GörHesapla.Application.Features.Users.Command.UpdateUser;

namespace GörHesapla.Application.Features.UsersCQRS.Command.UpdateUser
{
    public class UpdateUsersCommandValidator : AbstractValidator<UpdateUserCommandRequest>
    {
        public UpdateUsersCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithName("Id");

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

        }
    }
}
