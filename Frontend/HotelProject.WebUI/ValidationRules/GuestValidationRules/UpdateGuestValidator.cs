using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class UpdateGuestValidator : AbstractValidator<UpdateGuestDto>
    {
        public UpdateGuestValidator()
        {
            RuleFor(x => x.GuestName).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(x => x.GuestSurname).NotEmpty().WithMessage("Soyisim alanı boş geçilemez");
            RuleFor(x => x.GuestCity).NotEmpty().WithMessage("Şehir alanı boş geçilemez");
            RuleFor(x => x.GuestName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız");
            RuleFor(x => x.GuestSurname).MinimumLength(2).WithMessage("Lütfen en az 2 karakter veri girişi yapınız");
            RuleFor(x => x.GuestCity).MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız");
            RuleFor(x => x.GuestName).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter veri girişi yapınız");
            RuleFor(x => x.GuestSurname).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter veri girişi yapınız");
            RuleFor(x => x.GuestCity).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter veri girişi yapınız");
        }
    }
}
