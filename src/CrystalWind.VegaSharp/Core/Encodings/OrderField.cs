using Newtonsoft.Json;

namespace CrystalWind.VegaSharp.Core.Encodings
{
    public interface IOrderChannel
    {

    }
    public class OrderField : Field, IOrderChannel
    {
        public OrderFieldSort Sort { get; set; }
    }
}