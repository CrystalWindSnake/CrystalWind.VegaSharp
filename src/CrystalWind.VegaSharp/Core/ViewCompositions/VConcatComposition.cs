using CrystalWind.VegaSharp.Core.Specifications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrystalWind.VegaSharp.Core.ViewCompositions
{
    public class VConcatComposition : MultiViewComposition
    {
        public VConcatComposition(IEnumerable<TopLevelSpecification> specifications) : base(specifications)
        {
        }

        [JsonProperty(PropertyName = "vconcat")]
        public IReadOnlyCollection<TopLevelSpecification> VConcat => Specifications;

        public static VConcatComposition operator &(VConcatComposition left, SingleViewSpecification right)
        {
            //var res = left.Copy();
            left.AddSpecification(right);
            //res.Transforms = null;
            return left;
        }
    }



}



