
using Newtonsoft.Json;

namespace CrystalWind.VegaSharp.Core.Data
{
    public class ArrayData<TRecord> : IData
    {
        [JsonProperty(PropertyName = "values")]
        public TRecord[] Records { get; set; }
    }
}