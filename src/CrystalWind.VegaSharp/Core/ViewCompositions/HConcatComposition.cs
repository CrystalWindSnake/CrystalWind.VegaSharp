using CrystalWind.VegaSharp.Core.Specifications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrystalWind.VegaSharp.Core.ViewCompositions
{
    public class HConcatComposition : MultiViewComposition
    {
        public HConcatComposition(IEnumerable<TopLevelSpecification> specifications) : base(specifications)
        {
        }

        [JsonProperty(PropertyName = "hconcat")]
        public IReadOnlyCollection<TopLevelSpecification> HConcat => Specifications;

        public static HConcatComposition operator |(HConcatComposition left, SingleViewSpecification right)
        {
            //var res = left.Copy();
            left.AddSpecification(right);
            //res.Transforms = null;
            return left;
        }
    }



}



