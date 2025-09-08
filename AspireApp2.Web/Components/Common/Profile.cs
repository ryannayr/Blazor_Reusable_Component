using FluentValidation;
using System.ComponentModel;
using System.Globalization;
using System.Security.AccessControl;
namespace AspireApp2.Web.Components.Common
{
    public class Profile
    {
        public TextViewModel FirstName { get; set; }
        public TextViewModel LastName { get; set; }
        public TextViewModel PhoneNumber { get; set; }
        public TextViewModel EmailAddress { get; set; }
    }

    [TypeConverter(typeof(TextViewModelConverter))]
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


    public class TextViewModelConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) =>
            sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string str)
                return new TextViewModel { Value = str };
            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) =>
           destinationType == typeof(string) || base.CanConvertTo(context, destinationType);

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is TextViewModel model)
                return model.Value;
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
