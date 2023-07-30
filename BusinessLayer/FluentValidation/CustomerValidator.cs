using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Boş Geçilemez!");
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).WithMessage("İsim en az 2 karakterli olmalıdır!");
            RuleFor(x => x.City).NotEmpty().MinimumLength(3).WithMessage("Şehir Bilgisi Boş Geçilemez ve En az 3 karaktere sahip olmalıdır!");
        }
    }
}
