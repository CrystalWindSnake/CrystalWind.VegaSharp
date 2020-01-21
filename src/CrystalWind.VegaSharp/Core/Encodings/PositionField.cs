

namespace CrystalWind.VegaSharp.Core.Encodings
{
    public interface IPositionChannel : IVegaObject
    {
    }

    public class PositionField : Field, IPositionChannel
    {
        public Scale Scale { get; set; }
        public Axis Axis { get; set; }
        public dynamic Sort { get; set; }

        public double Band { get; set; }


    }
}