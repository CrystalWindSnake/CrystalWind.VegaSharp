using System;
using System.Collections.Generic;
using System.Text;

namespace CrystalWind.VegaSharp.Core.Selections
{
    public class SingleSelection : Selection
    {
        public SingleSelection(string name) : base(name)
        {
        }

        public object Init { get; set; }

        public dynamic Bind { get; set; }
        public bool Nearest { get; set; }

        public override SelectionType Type => SelectionType.Single;
    }
}
