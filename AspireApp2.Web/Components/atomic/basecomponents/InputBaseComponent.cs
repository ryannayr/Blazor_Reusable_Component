using Microsoft.AspNetCore.Components;

namespace AspireApp2.Web.Components.atomic.basecomponents
{
    public class InputBaseComponent<T> : ComponentBase
    {
        [Parameter] public required string Label { get; set; }
        [Parameter] public required T Model { get; set; }
        [Parameter] public required bool IsRequired { get; set; }
    }
}
