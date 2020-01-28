using CrystalWind.VegaSharp.Core;
using CrystalWind.VegaSharp.Core.Configurations;
using CrystalWind.VegaSharp.Core.Data;
using CrystalWind.VegaSharp.Core.Encodings;
using CrystalWind.VegaSharp.Core.Marks;
using CrystalWind.VegaSharp.Core.Selections;
using CrystalWind.VegaSharp.Core.Specifications;
using CrystalWind.VegaSharp.Shadow;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;

namespace CrystalWind.VegaSharp.VegaMode
{
    public static partial class Vega
    {

        static public XPositionEncodingAction X(string name, string title = null, string sort = null)
        {
            return new XPositionEncodingAction
            {
                Name = name,
                Title = title,
                Sort = sort,

            };
        }

        static public YPositionEncodingAction Y(string name, string title = null, string sort = null)
        {
            return new YPositionEncodingAction
            {
                Name = name,
                Title = title,
                Sort = sort,
            };
        }

        static public ColorEncodingAction Color(string name = null, string title = null, Condition condition = null, Color color = default(Color))
        {
            return new ColorEncodingAction
            {
                Name = name,
                Title = title,
                Condition = condition,
                Value = color
            };
        }

        static public Condition ColorCondition(string test, Color ifTrue)
        {
            return new Condition
            {
                Test = test,
                Value = ifTrue
            };
        }

        static public Condition ColorCondition(Expression<Func<DatumModel, bool>> test, Color ifTrue)
        {
            return new Condition
            {
                Test = Datum.To(test),
                Value = ifTrue
            };
        }
    }




}
