
using Newtonsoft.Json;

namespace CrystalWind.VegaSharp.Core.Data
{
    public class RecordArrayData<TRecord> : InlineData<TRecord[]>
    {
        public RecordArrayData(TRecord[] values) : base(values)
        {
        }


    }
}