using System;
using System.Collections.Generic;
using System.Text;

namespace CrystalWind.VegaSharp.Core.Configurations
{
    public class Autosize : IConfiguration
    {
        public string Type { get; set; }

        public bool Resize { get; set; }

        public string Contains { get; set; }

    }
}
