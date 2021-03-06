using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BookValidator :AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.BookName).NotEmpty().WithMessage("Kitap ismi boş olamaz.");
            RuleFor(b => b.UnitPrice).NotNull();
            RuleFor(b => b.BookName).MinimumLength(2);
        }
    }
}
