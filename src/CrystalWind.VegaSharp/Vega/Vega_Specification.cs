using CrystalWind.VegaSharp.Core;
using CrystalWind.VegaSharp.Core.Configurations;
using CrystalWind.VegaSharp.Core.Data;
using CrystalWind.VegaSharp.Core.Encodings;
using CrystalWind.VegaSharp.Core.Marks;
using CrystalWind.VegaSharp.Core.Specifications;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CrystalWind.VegaSharp
{
    public static partial class Vega
    {

        static public LayerSpecification Layer(params TopLevelSpecification[] topLevelSpecifications)
        {
            return LayerSpecification.CreateFrom(topLevelSpecifications);
        }



    }




}
