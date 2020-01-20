using CrystalWind.VegaSharp.Core.Selections;
using Newtonsoft.Json;

namespace CrystalWind.VegaSharp.Core.Encodings
{
    public class ColorCondition : IVegaObject
    {
        public Condition Condition { get; set; }


        public dynamic Value { get; set; }


        public static implicit operator ColorCondition(Condition condition)
        {
            return new ColorCondition
            {
                Condition = condition
            };
        }
    }
}