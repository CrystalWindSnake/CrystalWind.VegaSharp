using System;

using CrystalWind.VegaSharp.Core;
using CrystalWind.VegaSharp.Core.Marks;
using CrystalWind.VegaSharp;
using Newtonsoft.Json;
using System.IO;
using System.Drawing;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp_test
{




    class Program
    {
        static void Main(string[] args)
        {


            NewMethod3();
            Console.ReadKey();

        }

        private static void NewMethod1()
        {
            var names = "a b c d e f g h i".Split(" ");
            var values = new[] { 28, 55, 43, 91, 81, 53, 19, 87, 52 };
            var source = names.Zip(values, (f, s) => new { name = f, value = s });


            Vega.SetData(source)
                .SetMark(Mark.Bar)
                .SetEncoding(xName: "name", yName: "value")
                .ToFile("res.html");
        }

        private static void NewMethod2()
        {
            var url = @"https://vega.github.io/vega-datasets/data/movies.json";


            Vega.SetData(url)
                .SetMark(Mark.Bar)
                .SetEncoding(
                    x: Vega.X_Y("IMDB_Rating", FieldType.Quantitative, bin: true),
                    y: Vega.X_Y_Aggregate("count")
                    )
                .ToFile("res.html");
        }

        private static void NewMethod3()
        {
            var url = @"https://vega.github.io/vega-datasets/data/stocks.csv";

            var cm = Vega.SetData(url)
                           .SetEncoding(
                                x: Vega.X_Y("date", FieldType.Temporal),
                                y: Vega.X_Y("price", FieldType.Quantitative),
                                color: Vega.X_Y("symbol", FieldType.Nominal))
                           .SetFilter(Datum.To(d => d.String("symbol") == "GOOG"))
                //.SetFilter("datum.symbol == 'GOOG'")
                ;

            var line = cm.SetMark(Mark.Line);
            var point = cm.SetMark(Mark.Point);

            (line + point).ToFile("res.html");
        }


    }



    class MyClass
    {
        public StringValue Name { get; set; }


        public int Value { get; set; }


        public RangedMarksAlign Align { get; set; }
    }






    class TestClass
    {
        public IMixValue Value { get; set; }

        public IMixValue Number { get; set; }
    }
}
