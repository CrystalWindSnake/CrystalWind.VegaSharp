using System.Collections.Generic;
using System.Linq;

namespace CrystalWind.VegaSharp
{
    public interface IMixValue
    {
    }

    public interface IMixInternalValue : IMixValue
    {
        object GetValue();
    }

    public class StringValue : IMixInternalValue
    {
        public StringValue(string value)
        {
            Value = value;
        }

        public string Value { get; set; }



        public static implicit operator StringValue(string value)
        {
            return new StringValue(value);
        }


        public object GetValue()
        {
            return Value;
        }
    }

    public class StringArrayValue : IMixInternalValue
    {
        public StringArrayValue(IEnumerable<string> values)
        {
            Values = values;
        }

        public IEnumerable<string> Values { get; }

        public object GetValue()
        {
            return Values.ToArray();
        }



        public static implicit operator StringArrayValue(string[] values)
        {
            return new StringArrayValue(values);
        }

        public static implicit operator StringArrayValue(List<string> values)
        {
            return new StringArrayValue(values);
        }
    }

    public class NumberValue : IMixInternalValue
    {
        public NumberValue(double value)
        {
            Value = value;
        }

        public double Value { get; set; }

        public object GetValue()
        {
            return Value;
        }
    }



}
