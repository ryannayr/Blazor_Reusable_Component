using AspireApp2.Web.Components.atomic.interfaces;
using FluentValidation;

namespace AspireApp2.Web.Components.atomic.models
{
    public class TextValueModel : IIsRequired, ITextValue
    {
        public string Value { get; set; }
        public bool IsRequired { get; set; }
    }

    
}
