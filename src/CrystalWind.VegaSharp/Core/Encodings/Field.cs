using Newtonsoft.Json;

namespace CrystalWind.VegaSharp.Core.Encodings
{
    public class Field : IVegaObject
    {
        [JsonProperty(PropertyName = "field")]
        public string Name { get; set; }

        public FieldType Type { get; set; } = FieldType.None;

        public bool Bin { get; set; }

        public string Aggregate { get; set; }

    }
}