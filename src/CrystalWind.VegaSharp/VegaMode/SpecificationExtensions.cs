using CrystalWind.VegaSharp.Core.Data;
using CrystalWind.VegaSharp.Core.Encodings;
using CrystalWind.VegaSharp.Core.Marks;
using CrystalWind.VegaSharp.Core.Selections;
using CrystalWind.VegaSharp.Core.Specifications;
using CrystalWind.VegaSharp.Core.Transforms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;

namespace CrystalWind.VegaSharp.VegaMode
{
    public static class SpecificationExtensions
    {

        public static SingleViewSpecification SetData(this SingleViewSpecification engine, IData data)
        {
            engine = engine.Copy();
            engine.Data = data;
            return engine;
        }

        public static SingleViewSpecification SetData<TData>(this SingleViewSpecification engine, IEnumerable<TData> data)
        {
            engine = engine.Copy();
            var array = new RecordArrayData<TData>(data.ToArray());
            engine.Data = array;
            return engine;
        }

        public static SingleViewSpecification SetMark(this SingleViewSpecification engine, IMark mark)
        {
            engine = engine.Copy();
            engine.Mark = mark;
            return engine;
        }

        public static SingleViewSpecification SetEncoding(this SingleViewSpecification engine, Action<Encoding> action)
        {
            engine = engine.Copy();
            if (engine.Encoding == null)
            {
                engine.Encoding = new Encoding();
            }
            action(engine.Encoding);
            return engine;
        }

        //public static SingleViewSpecification SetEncoding(this SingleViewSpecification engine, Action<EncodingWrapper> action)
        //{
        //    engine = engine.Copy();
        //    if (engine.Encoding == null)
        //    {
        //        engine.Encoding = new Encoding();
        //    }
        //    EncodingWrapper wp = engine.Encoding;
        //    action(wp);
        //    engine.Encoding = wp;
        //    return engine;
        //}

        public static SingleViewSpecification SetEncoding(this SingleViewSpecification engine, string x, string y)
        {
            return engine.SetEncoding(en =>
            {
                en.X = Vega.PcField(x);
                en.Y = Vega.PcField(y);
            });
        }

        public static SingleViewSpecification SetEncoding(this SingleViewSpecification engine,
            string x, string y, string color)
        {
            return engine.SetEncoding(en =>
            {
                en.X = Vega.PcField(x);
                en.Y = Vega.PcField(y);
                en.Color = Vega.McField(color);
            });
        }


        public static SingleViewSpecification SetFilter(this SingleViewSpecification engine, Expression<Func<DatumModel, bool>> filter)
        {
            var exp = Datum.To(filter);
            return SetFilter(engine, exp);
        }

        public static SingleViewSpecification SetFilter(this SingleViewSpecification engine, string filter)
        {
            engine = engine.Copy();

            if (engine.Transforms == null)
            {
                engine.Transforms = new List<ITransform>();
            }
            engine.Transforms.Add(new FilterTransform
            {
                Filter = filter
            });
            return engine;
        }


        public static SingleViewSpecification SetSelection(this SingleViewSpecification engine, Selection selection)
        {
            engine = engine.Copy();

            if (engine.Selections == null)
            {
                engine.Selections = new Dictionary<string, Selection>();
            }
            engine.Selections.Add(selection.Name, selection);
            return engine;
        }
    }




}
