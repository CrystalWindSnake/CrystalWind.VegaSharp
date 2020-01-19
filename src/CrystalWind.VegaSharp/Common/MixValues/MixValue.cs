

using System.Collections.Generic;

namespace CrystalWind.VegaSharp
{

    public static class MixValue
    {

        static public IMixInternalValue SetNumber(double value)
        {
            return new NumberValue(value);
        }

        static public IMixInternalValue SetText(string value)
        {
            return new StringValue(value);
        }

        static public IMixInternalValue SetStringArray(IEnumerable<string> values)
        {
            return new StringArrayValue(values);
        }

        static public IMixInternalValue SetContainer()
        {
            return new StringValue("container");
        }

        static public IMixValue SetStep(double step)
        {
            return new StepObject { Step = step };
        }
    }
}
