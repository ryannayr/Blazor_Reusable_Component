using AspireApp2.Web.Components.atomic.models;
using FluentValidation;

namespace AspireApp2.Web.Components.atomic.validators
{
    public class TextValueModelValidator : AbstractValidator<TextValueModel>
    {
        public TextValueModelValidator()
        {
            When(x => x.IsRequired, () =>
            {
                RuleFor(x => x.Value)
                .NotEmpty().WithMessage("Field is required.");
            });
        }
    }
}
