using CrystalWind.VegaSharp.Core;
using CrystalWind.VegaSharp.Core.Configurations;
using CrystalWind.VegaSharp.Core.Data;
using CrystalWind.VegaSharp.Core.Encodings;
using CrystalWind.VegaSharp.Core.Marks;
using CrystalWind.VegaSharp.Core.Specifications;
using CrystalWind.VegaSharp.Core.ViewCompositions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CrystalWind.VegaSharp.VegaMode
{
    public static partial class Vega
    {

        static public LayerComposition Layer(params TopLevelSpecification[] topLevelSpecifications)
        {
            return new LayerComposition(topLevelSpecifications);
        }



    }




}
