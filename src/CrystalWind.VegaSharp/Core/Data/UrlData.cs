
using System;
using System.IO;
using Newtonsoft.Json;

namespace CrystalWind.VegaSharp.Core.Data
{
    internal class UrlData : IData
    {
        public UrlData(string url)
        {
            Url = url ?? throw new ArgumentNullException(nameof(url));

        }


        public string Name { get; set; }

        public Format Format { get; set; }
        public string Url { get; }
    }
}