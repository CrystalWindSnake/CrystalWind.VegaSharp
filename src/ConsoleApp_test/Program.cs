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

            NewMethod7();
            Console.WriteLine("done");
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
                .SetEncoding(en =>
                {
                    en.X = Vega.X_Y("IMDB_Rating", FieldType.Quantitative, bin: true);
                    en.Y = Vega.X_Y_Aggregate("count");
                })
                .ToFile("res.html");
        }

        private static void NewMethod3()
        {
            var url = @"https://vega.github.io/vega-datasets/data/stocks.csv";

            var cm = Vega.SetData(url)
                           .SetEncoding(en =>
                           {
                               en.X = Vega.X_Y("date", FieldType.Temporal);
                               en.Y = Vega.X_Y("price", FieldType.Quantitative);
                               en.Color = Vega.X_Y("symbol", FieldType.Nominal);
                           })
                           .SetFilter(d => d.String("symbol") == "GOOG")
                //.SetFilter("datum.symbol == 'GOOG'")
                ;

            var line = cm.SetMark(Mark.Line);
            var point = cm.SetMark(Mark.Point);

            (line + point).ToFile("res.html");
        }

        private static void NewMethod4()
        {
            var url = @"https://vega.github.io/vega-datasets/data/stocks.csv";

            var cond = Vega.Condition()
                           .AddTest(d => d.Number("price") > 400)
                           .AddValue(Color.Red);


            var cm = Vega.SetData(url)
                           .SetEncoding(en =>
                           {
                               en.X = Vega.X_Y("date", FieldType.Temporal);
                               en.Y = Vega.X_Y("price", FieldType.Quantitative);
                               en.Color = cond.ToColor(Color.Blue);
                           })
                           .SetFilter(d => d.String("symbol") == "GOOG")
                ;

            var line = cm.SetMark(Mark.Line);
            var point = cm.SetMark(Mark.Point);

            (line + point).ToFile("res.html");
        }


        private static void NewMethod5()
        {
            var url = @"https://vega.github.io/vega-datasets/data/cars.json";

            var selection = Vega.SingleSelection("pts").SetOn("mouseover")
                .SetNearest(true);


            var cond = Vega.Condition()
                           .AddFiled(aggregate: "count", fieldType: FieldType.Quantitative)
                           .AddSelection(selection);


            var cm = Vega.SetData(url)
                           .SetEncoding(en =>
                           {
                               en.X = Vega.X_Y("Origin", FieldType.Ordinal);
                               en.Y = Vega.X_Y("Cylinders", FieldType.Ordinal);
                               en.Color = cond.ToColor(Color.Gray);
                           })
                            .SetSelection(selection);

            var rect = cm.SetMark(Mark.Rect);

            rect.ToFile("res.html");
        }

        private static void NewMethod6()
        {
            var url = @"https://vega.github.io/vega-datasets/data/cars.json";

            var selection = Vega.IntervalSelection("pts");

            var cond = Vega.Condition()
                           .AddFiled(fieldName: "Origin", fieldType: FieldType.Nominal)
                           .AddSelection(selection);


            var cm = Vega.SetData(url)
                        .SetMark(Mark.Point)
                        .SetEncoding(en =>
                        {
                            en.Y = Vega.X_Y("Horsepower", FieldType.Quantitative);
                            en.Color = cond.ToColor(Color.Gray);
                        })
                        .SetSelection(selection);

            var left = cm.SetEncoding(en => en.X = Vega.X_Y("Acceleration", FieldType.Quantitative));
            var right = cm.SetEncoding(en => en.X = Vega.X_Y("Miles_per_Gallon", FieldType.Quantitative));

            (left | right).ToFile("res.html");
        }

        private static void NewMethod7()
        {
            var url = @"https://vega.github.io/vega-datasets/data/cars.json";

            var selection = Vega.IntervalSelection("pts")
                //.SetEncodings("x")
                .SetEmpty(SelectionEmpty.None)
                .SetBind(IntervalSelectionBind.Scales);

            var cond = Vega.Condition()
                           .AddFiled(fieldName: "Origin", fieldType: FieldType.Nominal)
                           .AddSelection(selection);


            var cm = Vega.SetData(url)
                        .SetMark(Mark.Point)
                        .SetEncoding(en =>
                        {
                            en.Y = Vega.X_Y("Horsepower", FieldType.Quantitative);
                            en.Color = cond.ToColor(Color.Gray);
                        })
                        .SetSelection(selection);

            var left = cm.SetEncoding(en => en.X = Vega.X_Y("Acceleration", FieldType.Quantitative));
            var right = cm.SetEncoding(en => en.X = Vega.X_Y("Miles_per_Gallon", FieldType.Quantitative));

            (left | right).ToFile("res.html");
        }
    }










    class TestClass
    {
        public IMixValue Value { get; set; }

        public IMixValue Number { get; set; }
    }
}
