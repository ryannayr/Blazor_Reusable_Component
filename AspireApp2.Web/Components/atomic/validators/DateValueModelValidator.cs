using AspireApp2.Web.Components.atomic.models;
using FluentValidation;

namespace AspireApp2.Web.Components.atomic.validators
{
    public class DateValueModelValidator : AbstractValidator<DateValueModel>
    {
            public DateValueModelValidator()
            {
                When(x => x.IsRequired, () =>
                {
                    RuleFor(x => x.Value)
                    .NotNull().WithMessage("Field is required.");
                });
            }
    }
}
