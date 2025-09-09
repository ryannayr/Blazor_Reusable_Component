using AspireApp2.Web.Components.atomic.models;
using AspireApp2.Web.Components.atomic.pages.textinput;
using AspireApp2.Web.Components.atomic.validators;
using FluentValidation.TestHelper;
using NUnit.Framework;
using AutoFixture;

namespace AspireApp2.Tests.Web.components.atomic.validators
{

    [TestFixture]
    public class TextInputModelValidatorTests
    {
        private Fixture _fixture;
        private TextInputModelValidator _validator;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _validator = new TextInputModelValidator();
        }

        [Test]
        public void Should_HaveError_WhenRequiredFieldsAreEmpty()
        {
            // Arrange
            var model = new TextInputModel
            {
                BasicInputText = new TextValueModel { IsRequired = false, Value = "" },
                BasicInputTextRequired = new TextValueModel { IsRequired = true, Value = "" },
                RadzenInputText = new TextValueModel { IsRequired = false, Value = "" },
                RadzenInputTextRequired = new TextValueModel { IsRequired = true, Value = "" }
            };

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor("BasicInputTextRequired.Value")
                  .WithErrorMessage("Field is required.");
            result.ShouldHaveValidationErrorFor("RadzenInputTextRequired.Value")
                  .WithErrorMessage("Field is required.");

            result.ShouldNotHaveValidationErrorFor("BasicInputText.Value");
            result.ShouldNotHaveValidationErrorFor("RadzenInputText.Value");
        }

        [Test]
        public void Should_NotHaveError_WhenAllValuesAreValid()
        {
            // Arrange
            var model = _fixture.Build<TextInputModel>()
                .With(x => x.BasicInputText, new TextValueModel { IsRequired = false, Value = "Optional" })
                .With(x => x.BasicInputTextRequired, new TextValueModel { IsRequired = true, Value = "Required" })
                .With(x => x.RadzenInputText, new TextValueModel { IsRequired = false, Value = "Optional" })
                .With(x => x.RadzenInputTextRequired, new TextValueModel { IsRequired = true, Value = "Required" })
                .Create();

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
