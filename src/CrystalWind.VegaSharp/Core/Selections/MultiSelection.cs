using System;
using System.Collections.Generic;
using System.Text;

namespace CrystalWind.VegaSharp.Core.Selections
{
    public class MultiSelection : Selection
    {
        public MultiSelection(string name) : base(name)
        {
        }

        public object[] Init { get; set; }

        public dynamic Toggle { get; set; }
        public bool Nearest { get; set; }

        public override SelectionType Type => SelectionType.Multi;
    }
}
