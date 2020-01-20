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


        public static XYField X()
        {
            return new XYField();
        }

        public static XYField Y()
        {
            return new XYField();
        }

        public static XYField SetName(this XYField x, string name)
        {
            x.Name = name;
            return x;
        }

        public static XYField SetType(this XYField x, FieldType type)
        {
            x.Type = type;
            return x;
        }

        public static XYField SetBin(this XYField x, bool bin)
        {
            x.Bin = bin;
            return x;
        }

        public static XYField SetAggregate(this XYField x, string method)
        {
            x.Aggregate = method;
            return x;
        }

        public static XYField SetSort(this XYField x, string sort)
        {
            x.Sort = sort;
            return x;
        }

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
