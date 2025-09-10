using AspireApp2.Web.Components.atomic.interfaces;

namespace AspireApp2.Web.Components.atomic.models
{
    public class DateValueModel : IIsRequired, IValue<DateTime?>
    {
        public DateTime? Value { get; set; }
        public bool IsRequired { get; set; }
    }
}
