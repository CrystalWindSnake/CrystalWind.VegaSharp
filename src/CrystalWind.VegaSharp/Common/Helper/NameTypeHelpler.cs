using System;
using System.Collections.Generic;
using System.Text;

namespace CrystalWind.VegaSharp.Common.Helper
{
    public class NameTypeHelpler
    {
        private static Dictionary<string, FieldType> _mapping = new Dictionary<string, FieldType>
        {
            {"N",FieldType.Nominal },
            {"Q",FieldType.Quantitative },
            {"O",FieldType.Ordinal },
            {"T",FieldType.Temporal },
        };

        public struct Result
        {
            public string Name { get; set; }

            public FieldType Type { get; set; }
        }

        static public Result Convert(string nameWithType)
        {
            var arr = nameWithType.Split(':');
            if (arr.Length > 2)
            {
                throw new ArgumentException($"名字不合法:{nameWithType}");
            }

            var res = new Result
            {
                Name = arr[0],
                Type = FieldType.None
            };

            if (arr.Length == 2)
            {
                res.Type = _mapping[arr[1]];
            };
            return res;
        }
    }
}
