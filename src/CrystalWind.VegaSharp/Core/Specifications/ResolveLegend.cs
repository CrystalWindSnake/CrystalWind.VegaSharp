using CrystalWind.VegaSharp.Core.Encodings;
using CrystalWind.VegaSharp.Core.Specifications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrystalWind.VegaSharp.Core.Specifications
{
    public class ResolveLegend : IVegaObject
    {
        public ResolveValue Color { get; set; }
        public ResolveValue Opacity { get; set; }
        public ResolveValue Shape { get; set; }
        public ResolveValue Size { get; set; }

    }



}



