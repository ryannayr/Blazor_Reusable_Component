using AspireApp2.Web.Components.atomic.atoms;
using AspireApp2.Web.Components.atomic.models;
using AspireApp2.Web.Components.atomic.organisms;
using AspireApp2.Web.Components.atomic.pages.textinput;
using AspireApp2.Web.Components.atomic.templates;
using AspireApp2.Web.Components.atomic.validators;
using AutoFixture;
using Bunit;
using FluentValidation;
using Microsoft.AspNetCore.Components.Forms;

[TestFixture]
public class GenericFormComponentTests
{
    private Bunit.TestContext _ctx;

    [SetUp]
    public void Setup()
    {
        _ctx = new Bunit.TestContext();
        _ctx.Services.AddSingleton<IValidator<DateInputModel>>(new TextInputModelValidator());
    }

    [TearDown]
    public void TearDown() => _ctx.Dispose();

    [Test]
    public void Should_ValidateModel_OnSubmit()
    {
        // Arrange
        var fixture = new Fixture();
        var model = new DateInputModel
        {
            BasicInputTextRequired = new TextValueModel { IsRequired = true, Value = "" },
            RadzenInputTextRequired = new TextValueModel { IsRequired = true, Value = "" },
            BasicInputText = new TextValueModel { IsRequired = false, Value = "" },
            RadzenInputText = new TextValueModel { IsRequired = false, Value = "" }
        };

        var cut = _ctx.RenderComponent<FormTemplate<DateInputModel>>(parameters => parameters
            .Add(p => p.Model, model)
            .Add(p => p.FormInputs, m => builder =>
            {
                builder.OpenComponent<BasicInputTextbox>(0);
                builder.AddAttribute(1, "Label", "Basic Input Text");
                builder.AddAttribute(2, "IsRequired", m.BasicInputTextRequired.IsRequired);
                builder.AddAttribute(3, "Model", m.BasicInputTextRequired);
                builder.CloseComponent();
            })

        );

        // Act
        cut.Find("button").Click();
        cut.Render();
        // Assert
        Assert.That(cut.Markup, Does.Contain("Field is required"));
    }
}