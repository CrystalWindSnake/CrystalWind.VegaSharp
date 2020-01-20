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


        public static Field X_Y_Aggregate(string method)
        {
            return X_Y_Aggregate(method, FieldType.Quantitative);
        }

        public static Field X_Y_Aggregate(string method, FieldType fieldType)
        {
            return new Field
            {
                Aggregate = method,
                Type = fieldType
            };
        }

        public static Field X_Y(string name)
        {
            return X_Y(name, FieldType.Nominal);
        }

        public static Field X_Y(string name, FieldType fieldType)
        {
            return X_Y(name, fieldType, false);
        }

        public static Field X_Y(string name, FieldType fieldType, bool bin)
        {
            return new Field
            {
                Name = name,
                Type = fieldType,
                Bin = bin
            };
        }


    }




}
