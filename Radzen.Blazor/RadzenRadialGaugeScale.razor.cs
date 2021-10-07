using Microsoft.AspNetCore.Components;
using Radzen.Blazor.Rendering;
using System;
using System.Threading.Tasks;

namespace Radzen.Blazor
{
    public partial class RadzenRadialGaugeScale : ComponentBase
    {
        [CascadingParameter]
        public RadzenRadialGauge Gauge { get; set; }

        [Parameter]
        public string Stroke { get; set; }

        [Parameter]
        public double StrokeWidth { get; set; } = 1;

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public double TickLength { get; set; } = 10;

        [Parameter]
        public double MinorTickLength { get; set; } = 5;

        [Parameter]
        public double TickLabelOffset { get; set; } = 25;

        [Parameter]
        public string FormatString { get; set; }

        [Parameter]
        public Func<double, string> Formatter { get; set; } = value => value.ToString();

        [Parameter]
        public double StartAngle { get; set; } = -90;

        [Parameter]
        public GaugeTickPosition TickPosition { get; set; } = GaugeTickPosition.Outside;

        [Parameter]
        public double EndAngle { get; set; } = 90;

        [Parameter]
        public double Radius { get; set; } = 1;

        [Parameter]
        public bool ShowFirstTick { get; set; } = true;

        [Parameter]
        public bool ShowLastTick { get; set; } = true;

        [Parameter]
        public bool ShowTickLabels { get; set; } = true;

        [Parameter]
        public double X { get; set; } = 0.5;

        [Parameter]
        public double Min { get; set; } = 0;

        [Parameter]
        public double Max { get; set; } = 100;

        [Parameter]
        public double Step { get; set; } = 20;

        [Parameter]
        public double MinorStep { get; set; }

        [Parameter]
        public double Y { get; set; } = 0.5;

        [Parameter]
        public double Margin { get; set; } = 16;

        public double CurrentRadius
        {
            get
            {
                var radius = Math.Min(Gauge.Width.Value, Gauge.Height.Value) / 2 - Margin * 2;

                radius *= Radius;

                if (TickPosition == GaugeTickPosition.Outside)
                {
                    radius -= TextMeasurer.TextWidth(Max.ToString(), 16);
                }

                return radius;
            }
        }

        public Point CurrentCenter
        {
            get
            {
                var x = X * Gauge.Width;
                var y = Y * Gauge.Height;

                return new Point { X = x.Value, Y = y.Value };
            }
        }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            var shouldRefresh = false;

            if (parameters.DidParameterChange(nameof(X), X) || parameters.DidParameterChange(nameof(Y), Y))
            {
                shouldRefresh = true;
            }

            await base.SetParametersAsync(parameters);

            if (shouldRefresh)
            {
                Gauge.Reload();
            }
        }
    }
}