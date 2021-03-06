﻿using System;

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

            test2();
            Console.WriteLine("done");
            Console.ReadKey();

        }

        private static void test2()
        {
            var names = "a b c d e f g h i".Split(" ");
            var values = new[] { 28, 55, 43, 91, 81, 53, 19, 87, 52 };
            var source = names.Zip(values, (f, s) => new { name = f, value = s });

            var cond = Vega.ColorCondition(d => d.Number("value") > 60, Color.Red);

            Vega.SetData(source)
                .SetMark(Vega.Marks.Bar)
                .SetEncoding(
                    Vega.Y("value:Q"),
                    Vega.X("name:N"),
                    Vega.Color(condition: cond, color: Color.Blue)
                    )
                .ToFile("res.html");
        }


        private static void test1()
        {
            var url = @"https://vega.github.io/vega-datasets/data/movies.json";

            var selection = Vega.MultiSelection("click")
                            //.SetOn("mousemove{100}")
                            .SetEncodings("x");

            var x = Vega.PcField("IMDB_Rating:Q").SetBin(true);
            var y = Vega.PcField("Rotten_Tomatoes_Rating:Q").SetBin(true);

            var rect = Vega.SetData(url)
                .SetMark(Vega.Marks.Rect)
                .SetEncoding(en =>
                {
                    en.X = x;
                    en.Y = y;
                    en.Color = Vega.McField()
                                .SetAggregate("count")
                                .SetScale("greenblue")
                                .SetLegend("总数");
                });

            var circ = Vega.SetData(url)
                .SetMark(Vega.Marks.Point)
                .SetEncoding(en =>
                {
                    en.X = x;
                    en.Y = y;
                    en.Color = Vega.McField().SetColor("grey");
                    en.Size = Vega.McField()
                                .SetAggregate("count")
                                .SetLegend("选中的总数");
                })
                .SetFilter(selection);


            var bar = Vega.SetData(url)
                 .SetMark(Vega.Marks.Bar)
                 .SetEncoding(en =>
                 {
                     en.X = Vega.PcField("Major_Genre:N");
                     en.Y = Vega.PcField().SetAggregate("count");
                     en.Color = Vega.Condition().AddSelection(selection).AddValue(Color.SteelBlue)
                         .ToColor(Color.Gray);
                 })
                 .SetSelection(selection);

            ((rect + circ) | bar)
                .SetResolveLegend(g =>
                {
                    g.Color = ResolveValue.Independent;
                    g.Size = ResolveValue.Independent;
                })
                .ToFile("res.html");

        }

#if true
        private static void NewMethod1()
        {
            var names = "a b c d e f g h i".Split(" ");
            var values = new[] { 28, 55, 43, 91, 81, 53, 19, 87, 52 };
            var source = names.Zip(values, (f, s) => new { name = f, value = s });


            Vega.SetData(source)
                .SetMark(Vega.Marks.Bar)
                .SetEncoding(x: "name:N", y: "value:Q")
                .ToFile("res.html");
        }

        private static void NewMethod2()
        {
            var url = @"https://vega.github.io/vega-datasets/data/movies.json";


            Vega.SetData(url)
                .SetMark(Vega.Marks.Bar)
                .SetEncoding(en =>
                {
                    en.X = Vega.PcField("IMDB_Rating:Q").SetBin(true);
                    en.Y = Vega.PcField().SetAggregate("count");
                })
                .ToFile("res.html");
        }

        private static void NewMethod3()
        {
            var url = @"https://vega.github.io/vega-datasets/data/stocks.csv";

            var cm = Vega.SetData(url)
                           .SetEncoding(en =>
                           {
                               en.X = Vega.PcField("date:T");
                               en.Y = Vega.PcField("price:Q");
                               en.Color = Vega.McField("symbol:N");
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
                               en.X = Vega.PcField().SetName("date:T");
                               en.Y = Vega.PcField().SetName("price:Q");
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
                           .AddFiled(Vega.PcField().SetAggregate("count").SetType(FieldType.Quantitative))
                           .AddSelection(selection);


            var cm = Vega.SetData(url)
                           .SetEncoding(en =>
                           {
                               en.X = Vega.PcField().SetName("Origin:O");
                               en.Y = Vega.PcField().SetName("Cylinders:O");
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
                           .AddFiled(Vega.PcField("Origin:N"))
                           .AddSelection(selection);


            var cm = Vega.SetData(url)
                        .SetMark(Vega.Marks.Point)
                        .SetEncoding(en =>
                        {
                            en.Y = Vega.PcField().SetName("Horsepower:Q");
                            en.Color = cond.ToColor(Color.Gray);
                        })
                        .SetSelection(selection);

            var left = cm.SetEncoding(en => en.X = Vega.PcField("Acceleration:Q"));
            var right = cm.SetEncoding(en => en.X = Vega.PcField("Miles_per_Gallon:Q"));

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
                           .AddFiled(Vega.PcField("Origin:N"))
                           .AddSelection(selection);

            var cm = Vega.SetData(url)//数据
                        .SetMark(Vega.Marks.Point) // 图表形状
                        .SetEncoding(en => //数据对应
                        {
                            en.Y = Vega.PcField("Horsepower:Q");
                            en.Color = cond.ToColor(Color.Gray);
                        })
                        .SetSelection(selection);

            var left = cm.SetEncoding(en => en.X = Vega.PcField("Acceleration:Q"));
            var right = cm.SetEncoding(en => en.X = Vega.PcField("Miles_per_Gallon:Q"));
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
                            en.Y = Vega.PcField().SetName("age:O").SetSort("-x");
                            en.X = Vega.PcField().SetName("people:Q")
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
