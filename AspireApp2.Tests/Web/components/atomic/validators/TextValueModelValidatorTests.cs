using AspireApp2.Web.Components.atomic.models;
using AspireApp2.Web.Components.atomic.validators;
using FluentValidation.TestHelper;
using NUnit.Framework;
using AutoFixture;

namespace AspireApp2.Tests.Web.components.atomic.validators
{
    [TestFixture]
    public class TextValueModelValidatorTests
    {
        private Fixture _fixture;
        private TextValueModelValidator _validator;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _validator = new TextValueModelValidator();
        }

        [Test]
        public void Should_HaveError_WhenRequiredAndValueIsEmpty()
        {
            // Arrange
            var model = new TextValueModel
            {
                IsRequired = true,
                Value = ""
            };

            // Act & Assert
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Value)
                  .WithErrorMessage("Field is required.");
        }

        [Test]
        public void Should_NotHaveError_WhenNotRequiredAndValueIsEmpty()
        {
            // Arrange
            var model = new TextValueModel
            {
                IsRequired = false,
                Value = ""
            };

            // Act & Assert
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Value);
        }

        [Test]
        public void Should_NotHaveError_WhenRequiredAndValueIsNotEmpty()
        {
            // Arrange
            var model = _fixture.Build<TextValueModel>()
                                .With(x => x.IsRequired, true)
                                .With(x => x.Value, "Valid input")
                                .Create();

            // Act & Assert
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Value);
        }
    }
}
