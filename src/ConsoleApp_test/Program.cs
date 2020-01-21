using System;

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
    using CrystalWind.VegaSharp;
    using CrystalWind.VegaSharp.VegaMode;


    class Program
    {
        static void Main(string[] args)
        {

            NewMethod7();
            Console.WriteLine("done");
            Console.ReadKey();

        }

#if true
        private static void NewMethod1()
        {
            var names = "a b c d e f g h i".Split(" ");
            var values = new[] { 28, 55, 43, 91, 81, 53, 19, 87, 52 };
            var source = names.Zip(values, (f, s) => new { name = f, value = s });


            Vega.SetData(source)
                .SetMark(Vega.Marks.Bar)
                .SetEncoding(x: "name", y: "value")
                .ToFile("res.html");
        }

        private static void NewMethod2()
        {
            var url = @"https://vega.github.io/vega-datasets/data/movies.json";


            Vega.SetData(url)
                .SetMark(Vega.Marks.Bar)
                .SetEncoding(en =>
                {
                    en.X = Vega.Field("IMDB_Rating:Q").SetBin(true);
                    en.Y = Vega.Field().SetAggregate("count");
                })
                .ToFile("res.html");
        }

        private static void NewMethod3()
        {
            var url = @"https://vega.github.io/vega-datasets/data/stocks.csv";

            var cm = Vega.SetData(url)
                           .SetEncoding(en =>
                           {
                               en.X = Vega.Field("date:T");
                               en.Y = Vega.Field("price:Q");
                               en.Color = Vega.Field("symbol:N");
                           })
                           .SetFilter(d => d.String("symbol") == "GOOG")
                //.SetFilter("datum.symbol == 'GOOG'")
                ;

            var line = cm.SetMark(Vega.Marks.Line);
            var point = cm.SetMark(Vega.Marks.Point);

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
                               en.X = Vega.Field().SetName("date:T");
                               en.Y = Vega.Field().SetName("price:Q");
                               en.Color = cond.ToColor(Color.Blue);
                           })
                           .SetFilter(d => d.String("symbol") == "GOOG")
                ;

            var line = cm.SetMark(Vega.Marks.Line);
            var point = cm.SetMark(Vega.Marks.Point);

            (line + point).ToFile("res.html");
        }


        private static void NewMethod5()
        {
            var url = @"https://vega.github.io/vega-datasets/data/cars.json";

            var selection = Vega.SingleSelection("pts").SetOn("mouseover")
                .SetNearest(true);


            var cond = Vega.Condition()
                           .AddFiled(Vega.Field().SetAggregate("count").SetType(FieldType.Quantitative))
                           .AddSelection(selection);


            var cm = Vega.SetData(url)
                           .SetEncoding(en =>
                           {
                               en.X = Vega.Field().SetName("Origin:O");
                               en.Y = Vega.Field().SetName("Cylinders:O");
                               en.Color = cond.ToColor(Color.Gray);
                           })
                            .SetSelection(selection);

            var rect = cm.SetMark(Vega.Marks.Rect);

            rect.ToFile("res.html");
        }

        private static void NewMethod6()
        {
            var url = @"https://vega.github.io/vega-datasets/data/cars.json";

            var selection = Vega.IntervalSelection("pts");

            var cond = Vega.Condition()
                           .AddFiled(Vega.Field("Origin:N"))
                           .AddSelection(selection);


            var cm = Vega.SetData(url)
                        .SetMark(Vega.Marks.Point)
                        .SetEncoding(en =>
                        {
                            en.Y = Vega.Field().SetName("Horsepower:Q");
                            en.Color = cond.ToColor(Color.Gray);
                        })
                        .SetSelection(selection);

            var left = cm.SetEncoding(en => en.X = Vega.Field("Acceleration:Q"));
            var right = cm.SetEncoding(en => en.X = Vega.Field("Miles_per_Gallon:Q"));

            (left | right).ToFile("res.html");
        }
#endif

        private static void NewMethod7()
        {
            var url = @"https://vega.github.io/vega-datasets/data/cars.json";
            //设置范围选择
            var selection = Vega.IntervalSelection("pts");
            //设置条件
            var cond = Vega.Condition()
                           .AddFiled(Vega.Field("Origin:N"))
                           .AddSelection(selection);

            var cm = Vega.SetData(url)//数据
                        .SetMark(Vega.Marks.Point) // 图表形状
                        .SetEncoding(en => //数据对应
                        {
                            en.Y = Vega.Field("Horsepower:Q");
                            en.Color = cond.ToColor(Color.Gray);
                        })
                        .SetSelection(selection);

            var left = cm.SetEncoding(en => en.X = Vega.Field("Acceleration:Q"));
            var right = cm.SetEncoding(en => en.X = Vega.Field("Miles_per_Gallon:Q"));
            //左右2张图
            (left | right).ToFile("res.html");
        }

        /// <summary>
        /// https://vega.github.io/vega-lite/docs/sort.html#sort-by-encoding
        /// </summary>
        private static void NewMethod8()
        {
            var url = @"https://vega.github.io/vega-datasets/data/population.json";

            var cm = Vega.SetData(url)
                        .SetMark(Vega.Marks.Bar)
                        .SetEncoding(en =>
                        {
                            en.Y = Vega.Field().SetName("age:O").SetSort("-x");
                            en.X = Vega.Field().SetName("people:Q")
                                            .SetAggregate("sum");

                        })
                        .SetFilter(d => d.Number("year") == 2000);

            cm.ToFile("res.html");

        }
    }










    class TestClass
    {
        public string Value { get; set; }

        public int Number { get; set; }
    }
}
