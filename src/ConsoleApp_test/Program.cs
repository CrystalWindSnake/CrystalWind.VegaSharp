using System;

using CrystalWind.VegaSharp.Core;
using CrystalWind.VegaSharp.Core.Data;
using CrystalWind.VegaSharp.Core.Marks;
using CrystalWind.VegaSharp.Core.Encodings;
using Newtonsoft.Json;
using System.IO;

namespace ConsoleApp_test
{
    class Program
    {
        static void Main(string[] args)
        {
            NewMethod();



            Console.ReadKey();

        }

        private static void NewMethod()
        {
            var engine = Engine.Create()
                 .SetData(new[]
                 {
                    new MyClass{Name="a",Value=12},
                    new MyClass{Name="b",Value=20},
                    new MyClass{Name="c",Value=25},
                 })
                 .SetMark(Mark.Point)
                 .SetEncoding(new Encoding
                 {
                     X = new Field { Name = "Name", Type = "nominal" },
                     Y = new Field { Name = "Value", Type = "quantitative" }
                 });



            var res = engine.ToHtml();
            File.WriteAllText("res.html", res);
        }
    }


    class MyClass
    {
        public string Name { get; set; }


        public int Value { get; set; }
    }
}
