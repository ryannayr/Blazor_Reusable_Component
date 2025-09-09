using AspireApp2.Web.Components.atomic.models;
using AspireApp2.Web.Components.atomic.pages.textinput;
using FluentValidation;

namespace AspireApp2.Web.Components.atomic.validators
{
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
