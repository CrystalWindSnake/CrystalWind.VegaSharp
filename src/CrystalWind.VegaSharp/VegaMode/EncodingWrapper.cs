using CrystalWind.VegaSharp.Core;
using CrystalWind.VegaSharp.Core.Configurations;
using CrystalWind.VegaSharp.Core.Data;
using CrystalWind.VegaSharp.Core.Encodings;
using CrystalWind.VegaSharp.Core.Marks;
using CrystalWind.VegaSharp.Core.Specifications;
using CrystalWind.VegaSharp.Core.ViewCompositions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CrystalWind.VegaSharp.VegaMode
{


    public class EncodingWrapper : IVegaObject
    {
        public IXY X { get; set; }
        public IXY Y { get; set; }

        public dynamic Color { get; set; }

        public Field Column { get; set; }


        public static implicit operator Encoding(EncodingWrapper wrapper)
        {
            return new Encoding
            {
                X = wrapper.X,
                Y = wrapper.Y,
                Color = wrapper.Color,
                Column = wrapper.Column
            };
        }

        public static implicit operator EncodingWrapper(Encoding encoding)
        {
            return new EncodingWrapper
            {
                X = encoding.X as IXY,
                Y = encoding.Y as IXY,
                Color = encoding.Color,
                Column = encoding.Column
            };
        }
    }


}
