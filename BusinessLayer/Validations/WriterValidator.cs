using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Ad alanı boş geçilemez.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Soyad alanı boş geçilemez.");
            RuleFor(x => x.AboutWriter).NotEmpty().WithMessage("Hakkımda alanı boş geçilemez.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan/Başlık alanı boş geçilemez.");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
            RuleFor(x => x.WriterSurname).MaximumLength(40).WithMessage("Lütfen 40 karakterden fazla veri girişi yapmayın");
        }
    }
}
