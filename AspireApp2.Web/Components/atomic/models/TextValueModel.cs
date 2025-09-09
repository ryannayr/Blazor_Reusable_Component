using AspireApp2.Web.Components.atomic.interfaces;
using FluentValidation;

namespace AspireApp2.Web.Components.atomic.models
{
    public class TextValueModel : IIsRequired, ITextValue
    {
        public string Value { get; set; }
        public bool IsRequired { get; set; }
    }

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
