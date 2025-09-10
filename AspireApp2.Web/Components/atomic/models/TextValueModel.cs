using AspireApp2.Web.Components.atomic.interfaces;

namespace AspireApp2.Web.Components.atomic.models
{
    public class TextValueModel : IIsRequired, IValue<string>
    {
        public string Value { get; set; }
        public bool IsRequired { get; set; }
    }
}
