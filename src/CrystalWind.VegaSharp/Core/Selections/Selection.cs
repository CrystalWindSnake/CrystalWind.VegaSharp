using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace CrystalWind.VegaSharp.Core.Selections
{
    public abstract class Selection : ISelection
    {
        protected Selection(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        [JsonIgnore]
        public string Name { get; set; }

        public abstract SelectionType Type { get; }

        public dynamic Clear { get; set; }

        public SelectionEmpty Empty { get; set; }

        public dynamic On { get; set; }

        public string Resolve { get; set; }
        public string[] Encodings { get; set; }
        public string[] Fields { get; set; }




    }
}
