﻿using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Radzen.Blazor
{
    public class RadzenSSRSViewerParameter : ComponentBase
    {
        string _parameterName;

        [Parameter]
        public string ParameterName
        {
            get
            {
                return _parameterName;
            }
            set
            {
                if (_parameterName != value)
                {
                    _parameterName = value;
                    if (Viewer != null)
                    {
                        Viewer.Reload();
                    }
                }
            }
        }

        string _value;

        [Parameter]
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    if (Viewer != null)
                    {
                        Viewer.Reload();
                    }
                }
            }
        }

        RadzenSSRSViewer _viewer;

        [CascadingParameter]
        public RadzenSSRSViewer Viewer
        {
            get
            {
                return _viewer;
            }
            set
            {
                if (_viewer != value)
                {
                    _viewer = value;
                    _viewer.AddParameter(this);
                }
            }
        }
    }
}