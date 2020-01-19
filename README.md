# VegaSharp
a .NET port of Vega



# 使用
生成柱状图：
```C#
var names = "a b c d e f g h i".Split(" ");
var values = new[] { 28, 55, 43, 91, 81, 53, 19, 87, 52 };
var source = names.Zip(values, (f, s) => new { name = f, value = s });


Vega.SetData(source)
    .SetMark(Mark.Bar)
    .SetEncoding(xName: "name", yName: "value")
    .ToFile("res.html");
```

从网络直接读取json数据，生成柱状图，y轴统计x轴分数段的个数
```C#
var url = @"https://vega.github.io/vega-datasets/data/movies.json";

Vega.SetData(url)
    .SetMark(Mark.Bar)
    .SetEncoding(
        x: Vega.X_Y("IMDB_Rating", FieldType.Quantitative, bin: true),
        y: Vega.X_Y_Aggregate("count")
        )
    .ToFile("res.html");
```

线图 和 点图 叠加。只显示 symbol值为 GOOG 的数据：
```C#
var url = @"https://vega.github.io/vega-datasets/data/stocks.csv";

var cm = Vega.SetData(url)
                .SetEncoding(
                    x: Vega.X_Y("date", FieldType.Temporal),
                    y: Vega.X_Y("price", FieldType.Quantitative),
                    color: Vega.X_Y("symbol", FieldType.Nominal))
                .SetFilter("datum.symbol == 'GOOG'");

var line = cm.SetMark(Mark.Line);
var point = cm.SetMark(Mark.Point);

(line + point).ToFile("res.html");
```


# 开发设计资料
- [vega-lite官网](https://vega.github.io/vega-lite/)