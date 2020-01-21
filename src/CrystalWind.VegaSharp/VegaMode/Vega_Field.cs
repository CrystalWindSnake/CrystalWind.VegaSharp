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
using System.Drawing;
using System.Linq;

namespace CrystalWind.VegaSharp.VegaMode
{
    public static partial class Vega
    {


        #region PositionChannel
        public static PositionField PcField()
        {
            return new PositionField();
        }

        public static PositionField PcField(string name)
        {
            var f = new PositionField();
            return f.SetName(name);
        }

        public static PositionField SetSort(this PositionField x, string sort)
        {
            x.Sort = sort;
            return x;
        }
        #endregion

        #region MarkPropertyChannel
        public static MarkPropertyField McField()
        {
            return new MarkPropertyField();
        }

        public static MarkPropertyField McField(string name)
        {
            var f = new MarkPropertyField();
            return f.SetName(name);
        }

        public static MarkPropertyField SetColor(this MarkPropertyField x, string color)
        {
            x.Value = color;
            return x;
        }

        public static MarkPropertyField SetColor(this MarkPropertyField x, Color color)
        {
            x.Value = color;
            return x;
        }

        public static MarkPropertyField SetScale(this MarkPropertyField x, string scale)
        {
            var s = new Scale
            {
                Scheme = scale
            };
            x.Scale = s;
            return x;
        }

        public static MarkPropertyField SetScale(this MarkPropertyField x, CategoricalSchemes categorical)
        {
            x.Scale = categorical;

            return x;
        }

        public static MarkPropertyField SetLegend(this MarkPropertyField x, string title)
        {
            if (x.Legend == null)
            {
                x.Legend = new Legend();
            }
            x.Legend.Title = title;

            return x;
        }
        #endregion




        #region Field 方法
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
            x.SetType(FieldType.Quantitative);
            x.Aggregate = method;
            return x;
        }
        #endregion






    }




}
