using Newtonsoft.Json;

namespace CrystalWind.VegaSharp.Core.Encodings
{
    public interface ITextAndTooltipChannel
    {

    }
    public class TextAndTooltipField : Field, ITextAndTooltipChannel
    {
        public dynamic Format { get; set; }
        public dynamic FormatType { get; set; }
        public dynamic Condition { get; set; }

    }
}