using Newtonsoft.Json;

namespace CrystalWind.VegaSharp.Core.Encodings
{
    public class Field : IVegaObject
    {
        [JsonProperty(PropertyName = "field")]
        public string Name { get; set; }

        public string Type { get; set; }
    }
}