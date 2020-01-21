using Newtonsoft.Json;

namespace CrystalWind.VegaSharp.Core.Encodings
{
    public interface IMarkPropertyChannel
    {

    }


    public class MarkPropertyField : Field, IMarkPropertyChannel
    {
        public dynamic Scale { get; set; }
        public Legend Legend { get; set; }
        public dynamic Condition { get; set; }

    }
}