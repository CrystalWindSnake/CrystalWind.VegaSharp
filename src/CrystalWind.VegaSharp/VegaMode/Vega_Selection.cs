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


        static public SingleSelection SingleSelection(string name)
        {
            return new SingleSelection(name);
        }

        static public SingleSelection SetNearest(this SingleSelection selection, bool nearest)
        {
            selection.Nearest = nearest;
            return selection;
        }


        static public MultiSelection MultiSelection(string name)
        {
            return new MultiSelection(name);
        }

        static public MultiSelection SetNearest(this MultiSelection selection, bool nearest)
        {
            selection.Nearest = nearest;
            return selection;
        }

        static public IntervalSelection IntervalSelection(string name)
        {
            return new IntervalSelection(name);
        }

        static public IntervalSelection SetBind(this IntervalSelection selection, IntervalSelectionBind bind)
        {
            selection.Bind = bind;
            return selection;
        }


        static public T SetEmpty<T>(this T selection, SelectionEmpty empty)
            where T : Selection
        {
            selection.Empty = empty;
            return selection;
        }

        static public T SetOn<T>(this T selection, string on)
            where T : Selection
        {
            selection.On = on;
            return selection;
        }

        static public T SetEncodings<T>(this T selection, params string[] encodings)
          where T : Selection
        {
            selection.Encodings = encodings;
            return selection;
        }
    }



}
