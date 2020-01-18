using CrystalWind.VegaSharp.Core.Configurations;
using CrystalWind.VegaSharp.Core.Data;
using CrystalWind.VegaSharp.Core.Encodings;
using CrystalWind.VegaSharp.Core.Marks;
using CrystalWind.VegaSharp.Properties;


namespace CrystalWind.VegaSharp.Core
{
    public class Engine : IVegaObject
    {
        public double Width { get; set; }

        public double Height { get; set; }

        public IConfiguration Autosize { get; set; }


        public IData Data { get; set; }

        public IMark Mark { get; set; }

        public IEncoding Encoding { get; set; }


        public string ToJsonView()
        {
            return new JsonViewCreator().Create(this);
        }


        public string ToHtml()
        {
            return Resources.Template.Replace("{0}", ToJsonView());
        }


        static public Engine Create()
        {
            return new Engine();
        }
    }




}
