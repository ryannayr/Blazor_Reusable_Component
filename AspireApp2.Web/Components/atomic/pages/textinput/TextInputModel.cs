using AspireApp2.Web.Components.atomic.models;
using FluentValidation;

namespace AspireApp2.Web.Components.atomic.pages.textinput
{
    public class TextInputModel
    {
        public TextValueModel BasicInputText { get; set; }
        public TextValueModel BasicInputTextRequired { get; set; }
        public TextValueModel RadzenInputText { get; set; }
        public TextValueModel RadzenInputTextRequired { get; set; }
    }

    public class TextInputModelValidator : AbstractValidator<TextInputModel>
    {
        public TextInputModelValidator()
        {
            RuleFor(x => x.BasicInputText).SetValidator(new TextValueModelValidator());
            RuleFor(x => x.BasicInputTextRequired).SetValidator(new TextValueModelValidator());
            RuleFor(x => x.RadzenInputText).SetValidator(new TextValueModelValidator());
            RuleFor(x => x.RadzenInputTextRequired).SetValidator(new TextValueModelValidator());
        }
    }
}
