﻿using Microsoft.AspNetCore.Components;

namespace Radzen.Blazor
{
    public partial class RadzenSidebar : RadzenComponentWithChildren
    {
        [Parameter]
        public override string Style { get; set; } = "top:51px;bottom:57px;width:250px;";

        protected override string GetComponentCssClass()
        {
            return "rz-sidebar";
        }

        public void Toggle()
        {
            Expanded = !Expanded;

            StateHasChanged();
        }

        protected string GetStyle()
        {
            return $"{Style}{(Expanded ? ";transform:translateX(0px);" : ";width:0px;transform:translateX(-100%);")}";
        }

        [Parameter]
        public bool Expanded { get; set; } = true;

        [Parameter]
        public EventCallback<bool> ExpandedChanged { get; set; }
    }
}