using CrystalWind.VegaSharp.Core;
using CrystalWind.VegaSharp.Core.Configurations;
using CrystalWind.VegaSharp.Core.Data;
using CrystalWind.VegaSharp.Core.Encodings;
using CrystalWind.VegaSharp.Core.Marks;
using CrystalWind.VegaSharp.Core.Selections;
using CrystalWind.VegaSharp.Core.Specifications;
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


        static public Condition Condition()
        {
            return new Condition();
        }

        static public Condition AddSelection(this Condition condition, string selectionName)
        {
            condition.Selection = selectionName;
            return condition;
        }

        static public Condition AddSelection(this Condition condition, Selection selection)
        {
            return condition.AddSelection(selection.Name);
        }

        static public Condition AddTest(this Condition condition, string test)
        {
            condition.Test = test;
            return condition;
        }

        static public Condition AddTest(this Condition condition, Expression<Func<DatumModel, bool>> test)
        {
            return condition.AddTest(Datum.To(test));
        }

        static public Condition AddFiled(this Condition condition, XYField field)
        {
            condition.Field = field.Name;
            condition.Type = field.Type;
            condition.Aggregate = field.Aggregate;
            return condition;
        }


        static public Condition AddValue(this Condition condition, string value)
        {
            condition.Value = value;
            return condition;
        }

        static public Condition AddValue(this Condition condition, double value)
        {
            condition.Value = value;
            return condition;
        }

        static public Condition AddValue(this Condition condition, Color value)
        {
            condition.Value = value;
            return condition;
        }

        static public ColorCondition ToColor(this Condition condition, Color defaultColor)
        {
            return new ColorCondition
            {
                Condition = condition,
                Value = defaultColor
            };
        }
    }



}
