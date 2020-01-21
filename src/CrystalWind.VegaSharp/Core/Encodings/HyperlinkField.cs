using Newtonsoft.Json;

namespace CrystalWind.VegaSharp.Core.Encodings
{
    public interface IHyperlinkChannel
    {

    }
    public class HyperlinkField : Field, IHyperlinkChannel
    {
        public dynamic Scale { get; set; }
        public dynamic Legend { get; set; }
        public dynamic Condition { get; set; }

    }
}