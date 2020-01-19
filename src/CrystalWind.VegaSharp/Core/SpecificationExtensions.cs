using CrystalWind.VegaSharp.Core.Data;
using CrystalWind.VegaSharp.Core.Encodings;
using CrystalWind.VegaSharp.Core.Marks;
using CrystalWind.VegaSharp.Core.Specifications;
using CrystalWind.VegaSharp.Core.Transforms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CrystalWind.VegaSharp.Core
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

        public static SingleViewSpecification SetEncoding(this SingleViewSpecification engine, Field x, Field y, Field color)
        {
            engine = engine.Copy();
            engine.Encoding = new Encoding
            {
                X = x,
                Y = y,
                Color = color
            };
            return engine;
        }

        public static SingleViewSpecification SetEncoding(this SingleViewSpecification engine, Field x, Field y)
        {
            return engine.SetEncoding(x, y, null);
        }

        public static SingleViewSpecification SetEncoding(this SingleViewSpecification engine, string xName, string yName
            , FieldType xFieldType = FieldType.Nominal, FieldType yFieldType = FieldType.Quantitative)
        {
            engine = engine.Copy();
            engine.Encoding = new Encoding
            {
                X = Vega.X_Y(xName, xFieldType),
                Y = Vega.X_Y(yName, yFieldType),
            };
            return engine;
        }

        public static SingleViewSpecification SetEncoding(this SingleViewSpecification engine, IEncoding encoding)
        {
            engine = engine.Copy();
            engine.Encoding = encoding;
            return engine;
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

    }




}
