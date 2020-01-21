using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CrystalWind.VegaSharp.WindowsFormsSamples
{
    using CrystalWind.VegaSharp;
    using CrystalWind.VegaSharp.VegaMode;

    public struct SamplesResult
    {
        public string Desc { get; set; }

        public string Html { get; set; }
    }

    static class Samples
    {

        public static SamplesResult NewMethod1()
        {
            var names = "a b c d e f g h i".Split(' ');
            var values = new[] { 28, 55, 43, 91, 81, 53, 19, 87, 52 };
            var source = names.Zip(values, (f, s) => new { name = f, value = s });


            var res = Vega.SetData(source)
                .SetMark(Vega.Marks.Bar)
                .SetEncoding(x: "name:N", y: "value:Q")
                .ToHtml();

            return new SamplesResult
            {
                Desc = "普通柱状图",
                Html = res
            };
        }

        public static SamplesResult NewMethod2()
        {
            var url = @"https://vega.github.io/vega-datasets/data/movies.json";


            var res = Vega.SetData(url)
                .SetMark(Vega.Marks.Bar)
                .SetEncoding(en =>
                {
                    en.X = Vega.PcField("IMDB_Rating:Q").SetBin(true);
                    en.Y = Vega.PcField().SetAggregate("count");
                })
                .ToHtml();

            return new SamplesResult
            {
                Desc = "柱状图，y轴直接指定聚合 count，按x轴统计个数",
                Html = res
            };
        }

        public static SamplesResult NewMethod3()
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

            return new SamplesResult
            {
                Desc = "点图 + 线图 叠加",
                Html = (line + point).ToHtml()
            };
        }

        public static SamplesResult NewMethod4()
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

            return new SamplesResult
            {
                Desc = "设置条件，价格高于400的，点图中的点会设置为红色",
                Html = (line + point).ToHtml()
            };
        }


        public static SamplesResult NewMethod5()
        {
            var url = @"https://vega.github.io/vega-datasets/data/cars.json";

            var selection = Vega.SingleSelection("pts").SetOn("mouseover");


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

            return new SamplesResult
            {
                Desc = "鼠标经过，高亮颜色，其他地方灰色",
                Html = rect.ToHtml()
            };
        }

        public static SamplesResult NewMethod6()
        {
            var url = @"https://vega.github.io/vega-datasets/data/cars.json";

            var selection = Vega.IntervalSelection("pts")
                .SetBind(IntervalSelectionBind.Scales);

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

            return new SamplesResult
            {
                Desc = @"2个表相同的y轴，不同的x轴。
能用鼠标点击拖动移动图表显示范围，用滚轮放大或缩小范围。
并且2个表是同步更新",
                Html = (left | right).ToHtml()
            };
        }


        public static SamplesResult NewMethod7()
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
            return new SamplesResult
            {
                Desc = @"范围选择，鼠标左键点击可画出范围框，然后点击框能拖动。
框范围内正常颜色，其他为灰色",
                Html = (left | right).ToHtml()
            };
        }

        /// <summary>
        /// https://vega.github.io/vega-lite/docs/sort.html#sort-by-encoding
        /// </summary>
        public static SamplesResult NewMethod8()
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

            return new SamplesResult
            {
                Desc = "Y轴按x轴值倒序排序",
                Html = cm.ToHtml()
            };

        }
    }











}


