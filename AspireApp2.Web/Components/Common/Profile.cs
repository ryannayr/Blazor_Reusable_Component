using FluentValidation;
namespace AspireApp2.Web.Components.Common
{
    public class Profile
    {
        public TextViewModel FirstName { get; set; }
        public TextViewModel LastName { get; set; }
        public TextViewModel PhoneNumber { get; set; }
        public TextViewModel EmailAddress { get; set; }
    }

    public class TextViewModel : IIsRequired, IStringValue
    {
        public string Value { get; set; }
        public bool IsRequired { get; set; }
    }
    public interface IIsRequired { bool IsRequired { get; set; } }
    public interface IStringValue { string Value { get; set; } }

    public class TextViewModelValidator : AbstractValidator<TextViewModel>
    {
        public TextViewModelValidator()
        {
            When(x => x.IsRequired, () =>
            {
                RuleFor(x => x.Value)
                  .NotEmpty()
                  .WithMessage("This field is required.");
            });
        }
    }

    public class ProfileValidator : AbstractValidator<Profile>
    {
        public ProfileValidator()
        {
            RuleFor(x => x.FirstName).SetValidator(new TextViewModelValidator()).WithName("First Name");
            RuleFor(x => x.LastName).SetValidator(new TextViewModelValidator()).WithName("Last Name");
            RuleFor(x => x.PhoneNumber).SetValidator(new TextViewModelValidator()).WithName("Mobile");
        }
    }

}
