
using Newtonsoft.Json;

namespace CrystalWind.VegaSharp.Core.Data
{
    public class InlineData<TData> : IData
    {
        public InlineData(TData values)
        {
            Values = values;
        }

        public TData Values { get; }

        public string Name { get; set; }

        public Format Format { get; set; }
    }
}