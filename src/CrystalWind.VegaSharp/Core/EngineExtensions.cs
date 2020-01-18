using CrystalWind.VegaSharp.Core.Data;
using CrystalWind.VegaSharp.Core.Encodings;
using CrystalWind.VegaSharp.Core.Marks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CrystalWind.VegaSharp.Core
{
    public static class EngineExtensions
    {

        public static Engine SetData(this Engine engine, IData data)
        {
            engine.Data = data;
            return engine;
        }

        public static Engine SetData<TData>(this Engine engine, IEnumerable<TData> data)
        {
            var array = new ArrayData<TData>()
            {
                Records = data.ToArray()
            };
            engine.Data = array;
            return engine;
        }

        public static Engine SetMark(this Engine engine, IMark mark)
        {
            engine.Mark = mark;
            return engine;
        }

        public static Engine SetEncoding(this Engine engine, IEncoding encoding)
        {
            engine.Encoding = encoding;
            return engine;
        }

    }




}
