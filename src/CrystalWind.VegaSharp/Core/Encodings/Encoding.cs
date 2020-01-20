namespace CrystalWind.VegaSharp.Core.Encodings
{
    public class Encoding : IVegaObject
    {
        public dynamic X { get; set; }
        public dynamic Y { get; set; }

        public dynamic Color { get; set; }

        public Field Column { get; set; }
    }

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