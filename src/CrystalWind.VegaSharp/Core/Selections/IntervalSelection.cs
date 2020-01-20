using CrystalWind.VegaSharp.Core.Marks;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrystalWind.VegaSharp.Core.Selections
{
    public class IntervalSelection : Selection
    {
        public IntervalSelection(string name) : base(name)
        {
        }

        public object Init { get; set; }

        public IntervalSelectionBind Bind { get; set; }
        public Mark Mark { get; set; }

        public dynamic Translate { get; set; }
        public dynamic Zoom { get; set; }

        public override SelectionType Type => SelectionType.Interval;
    }
}
