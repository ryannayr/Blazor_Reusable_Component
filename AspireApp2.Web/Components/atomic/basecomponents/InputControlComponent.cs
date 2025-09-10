using AspireApp2.Web.Components.atomic.interfaces;
using Microsoft.AspNetCore.Components;

namespace AspireApp2.Web.Components.atomic.basecomponents
{
    public class InputControlComponent<T> : InputBaseComponent<T>
    {
        [Parameter] public required RenderFragment<T> InputField { get; set; }
        protected override void OnParametersSet()
        {
            if (Model is IIsRequired requiredModel)
                requiredModel.IsRequired = IsRequired;
        }
    }
}
