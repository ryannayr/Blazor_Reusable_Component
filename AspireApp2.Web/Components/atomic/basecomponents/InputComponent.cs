using AspireApp2.Web.Components.atomic.interfaces;
using Microsoft.AspNetCore.Components;

namespace AspireApp2.Web.Components.atomic.basecomponents
{
    public class InputComponent<T> : ComponentBase
    {
        [Parameter] public T Value { get; set; }
        [Parameter] public EventCallback<T> ValueChanged { get; set; }
        [Parameter] public string CssClass { get; set; }

        [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object> AdditionalAttributes { get; set; }

        public T ValueProxy
        {
            get
            {
                return Value;
            }
            set
            {
                ValueChanged.InvokeAsync(value);
            }
        }

    }
}
