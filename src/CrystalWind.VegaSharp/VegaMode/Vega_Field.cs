using CrystalWind.VegaSharp.Common.Helper;
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

namespace CrystalWind.VegaSharp.VegaMode
{
    public static partial class Vega
    {


        public static PositionField PcField()
        {
            return new PositionField();
        }

        public static PositionField PcField(string name)
        {
            var f = new PositionField();
            return f.SetName(name);
        }

        public static MarkPropertyField McField()
        {
            return new MarkPropertyField();
        }

        public static MarkPropertyField McField(string name)
        {
            var f = new MarkPropertyField();
            return f.SetName(name);
        }

        public static PositionField SetSort(this PositionField x, string sort)
        {
            x.Sort = sort;
            return x;
        }


        public static T SetName<T>(this T x, string name)
            where T : Field
        {
            var res = NameTypeHelpler.Convert(name);
            x.Name = res.Name;
            if (res.Type != FieldType.None)
            {
                x.Type = res.Type;
            }
            return x;
        }

        public static T SetType<T>(this T x, FieldType type)
            where T : Field
        {
            x.Type = type;
            return x;
        }

        public static T SetBin<T>(this T x, bool bin)
            where T : Field
        {
            x.Bin = bin;
            return x;
        }

        public static T SetAggregate<T>(this T x, string method)
            where T : Field
        {
            x.Aggregate = method;
            return x;
        }






    }




}
