using AspireApp2.Web.Components.atomic.pages.textinput;
using FluentValidation;

namespace AspireApp2.Web.Components.atomic.validators
{
    public class DateInputModelValidator : AbstractValidator<DateInputModel>
    {
        public DateInputModelValidator()
        {
            RuleFor(x => x.BasicInputDate).SetValidator(new DateValueModelValidator());
            RuleFor(x => x.BasicInputDateRequired).SetValidator(new DateValueModelValidator());
        }
    }
}
