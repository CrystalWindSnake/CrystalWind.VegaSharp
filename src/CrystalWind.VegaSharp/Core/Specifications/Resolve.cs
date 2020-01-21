using CrystalWind.VegaSharp.Core.Encodings;
using CrystalWind.VegaSharp.Core.Specifications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrystalWind.VegaSharp.Core.Specifications
{
    public class Resolve : IVegaObject
    {
        public dynamic Scale { get; set; }

        public dynamic Axis { get; set; }

        public ResolveLegend Legend { get; set; }
    }



}



