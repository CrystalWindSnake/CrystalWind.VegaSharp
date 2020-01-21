using Newtonsoft.Json;

namespace CrystalWind.VegaSharp.Core.Encodings
{
    public class Field : IVegaObject
    {
        [JsonProperty(PropertyName = "field")]
        public string Name { get; set; }

        public FieldType Type { get; set; } = FieldType.None;

        public dynamic Bin { get; set; }

        public string Aggregate { get; set; }
        public TimeUnit TimeUnit { get; set; }

        public string Title { get; set; }

        public dynamic Value { get; set; }
    }
}