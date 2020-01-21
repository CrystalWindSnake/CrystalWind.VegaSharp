namespace CrystalWind.VegaSharp.Core.Encodings
{
    public class Scale : IVegaObject
    {

        public string Type { get; set; }

        public dynamic Domain { get; set; }

        public dynamic Scheme { get; set; }

        public string[] Range { get; set; }
    }
}