using CrystalWind.VegaSharp.Core.Specifications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystalWind.VegaSharp.Core.ViewCompositions
{
    public abstract class MultiViewComposition : TopLevelSpecification
    {
        private readonly IList<TopLevelSpecification> _specifications;

        protected MultiViewComposition(IEnumerable<TopLevelSpecification> specifications)
        {
            _specifications = specifications.ToArray();
            this.Data = specifications.First().Data;
            foreach (var item in specifications)
            {
                item.Data = null;
            }

        }


        [JsonIgnore]
        public IReadOnlyList<TopLevelSpecification> Specifications => _specifications as IReadOnlyList<TopLevelSpecification>;


        public void AddSpecification(TopLevelSpecification specification)
        {
            _specifications.Add(specification);
        }
    }



}



