using Microsoft.AspNetCore.Components;

namespace Radzen.Blazor
{
    public class RadzenTicks : ComponentBase
    {
        [Parameter]
        public string Stroke { get; set; }

        [Parameter]
        public double StrokeWidth { get; set; } = 1;

        [Parameter]
        public LineType LineType { get; set; }

        [CascadingParameter]
        public AxisBase ChartAxis
        {
            set
            {
                value.Ticks = this;
            }
        }

        [Parameter]
        public RenderFragment<TickTemplateContext> Template { get; set; }
    }
}