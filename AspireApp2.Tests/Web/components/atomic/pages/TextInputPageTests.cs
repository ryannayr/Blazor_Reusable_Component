using AspireApp2.Web.Components.atomic.pages.textinput;
using AutoFixture;

[TestFixture]
public class TextInputPageTests
{
    private Bunit.TestContext _ctx;

    [SetUp]
    public void Setup() => _ctx = new Bunit.TestContext();

    [TearDown]
    public void TearDown() => _ctx.Dispose();

    [Test]
    public void TextInputPage_ModelProperties_AreInitializedAndRequiredFlagsMatch()
    {
        // Arrange
        var fixture = new Fixture();

        // Act
        var cut = _ctx.RenderComponent<TextInputPage>();
        var model = cut.Instance.GetType()
            .GetProperty("model", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .GetValue(cut.Instance) as DateInputModel;

        // Assert
        Assert.That(model, Is.Not.Null);
        Assert.That(model.BasicInputText, Is.Not.Null);
        Assert.That(model.BasicInputTextRequired, Is.Not.Null);
        Assert.That(model.RadzenInputText, Is.Not.Null);
        Assert.That(model.RadzenInputTextRequired, Is.Not.Null);

        // Check IsRequired flags
        Assert.That(model.BasicInputTextRequired.IsRequired, Is.True);
        Assert.That(model.BasicInputText.IsRequired, Is.False);
        Assert.That(model.RadzenInputTextRequired.IsRequired, Is.True);
        Assert.That(model.RadzenInputText.IsRequired, Is.False);

        // Use AutoFixture to set values and assert
        var randomValue = fixture.Create<string>();
        model.BasicInputText.Value = randomValue;
        Assert.That(model.BasicInputText.Value, Is.EqualTo(randomValue));
    }
}