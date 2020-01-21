using CrystalWind.VegaSharp.Core.Configurations;
using CrystalWind.VegaSharp.Core.Data;
using CrystalWind.VegaSharp.Core.Encodings;
using CrystalWind.VegaSharp.Core.Marks;
using CrystalWind.VegaSharp.Properties;
using System.Drawing;
using System.IO;

using Newtonsoft.Json;
using CrystalWind.VegaSharp.Core.Transforms;
using System.Collections.Generic;

namespace CrystalWind.VegaSharp.Core.Specifications
{
    public class Specification : ISpecification
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IMixValue Title { get; set; }

        [JsonProperty(PropertyName = "transform")]
        public IList<ITransform> Transforms { get; set; }

        public Resolve Resolve { get; set; }

    }




}
