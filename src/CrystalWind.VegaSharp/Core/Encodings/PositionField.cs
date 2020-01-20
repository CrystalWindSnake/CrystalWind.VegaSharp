using Newtonsoft.Json;

namespace CrystalWind.VegaSharp.Core.Encodings
{
    public class PositionField : Field
    {
        public Scale Scale { get; set; }
        public Axis Axis { get; set; }
        public dynamic Sort { get; set; }
    }
}