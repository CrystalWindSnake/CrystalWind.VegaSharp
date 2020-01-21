namespace CrystalWind.VegaSharp.Core.Encodings
{
    public class Encoding : IVegaObject
    {
        public dynamic X { get; set; }
        public dynamic Y { get; set; }

        public dynamic Color { get; set; }

        public Field Column { get; set; }
    }


}