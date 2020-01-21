using CrystalWind.VegaSharp.Core.Configurations;
using CrystalWind.VegaSharp.Core.Data;
using CrystalWind.VegaSharp.Core.Encodings;
using CrystalWind.VegaSharp.Core.Marks;
using CrystalWind.VegaSharp.Properties;
using System.Drawing;
using System.IO;

using Newtonsoft.Json;

namespace CrystalWind.VegaSharp.Core.Specifications
{
    public class TopLevelSpecification : Specification
    {


        [JsonProperty(PropertyName = "$schema")]
        public string Schema { get; set; }


        public Color? Background { get; set; }



        public Configuration Config { get; set; }


        public IData Data { get; set; }



        public IMixValue Padding { get; set; }


        public IMixValue Autosize { get; set; }

        public dynamic Usermeta { get; set; }





        public string ToJsonView()
        {
            if (string.IsNullOrWhiteSpace(Schema))
            {
                Schema = @"https://vega.github.io/schema/vega-lite/v3.4.0.json";
            }

            if (Config == null)
            {
                Config = new Configuration
                {
                    View = new View
                    {
                        Width = 400,
                        Height = 300
                    }
                };
            }

            return JsonViewCreator.Get.Create(this);
        }


        public string ToHtml()
        {
            return string.Format(Resources.Template, ToJsonView());
        }

        public void ToFile(string path)
        {
            File.WriteAllText(path, ToHtml(), System.Text.Encoding.UTF8);
        }
    }




}
