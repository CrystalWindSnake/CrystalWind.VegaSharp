using CrystalWind.VegaSharp.Core.Selections;
using Newtonsoft.Json;

namespace CrystalWind.VegaSharp.Core.Encodings
{
    public class Condition : IVegaObject
    {
        public dynamic Selection { get; set; }

        public string Test { get; set; }

        public string Field { get; set; }

        public FieldType Type { get; set; } = FieldType.None;

        public bool Bin { get; set; }

        public string Aggregate { get; set; }


        public dynamic Value { get; set; }
    }
}