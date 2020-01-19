# VegaSharp
a .NET port of Vega



# 使用
```C#
var names = "a b c d e f g h i".Split(" ");
var values = new[] { 28, 55, 43, 91, 81, 53, 19, 87, 52 };
var source = names.Zip(values, (f, s) => new { name = f, value = s });


Vega.SetData(source)
    .SetMark(Mark.Bar)
    .SetEncoding(xName: "name", yName: "value")
    .ToFile("res.html");
```

```html
<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8" />

    <script src="https://cdn.jsdelivr.net/npm/vega@5.9.0"></script>
    <script src="https://cdn.jsdelivr.net/npm/vega-lite@4.0.2"></script>
    <script src="https://cdn.jsdelivr.net/npm/vega-embed@6.2.1"></script>

    <style media="screen">
        /* Add space between Vega-Embed links  */
        .vega-actions a {
            margin-right: 5px;
        }
    </style>
</head>

<body>
    <!-- Container for the visualization -->
    <div id="vis"></div>

    <script>
        // Assign the specification to a local variable vlSpec.
        var vlSpec = {
  "layer": [
    {
      "mark": {
        "type": "line"
      },
      "encoding": {
        "x": {
          "field": "date",
          "type": "temporal"
        },
        "y": {
          "field": "price",
          "type": "quantitative"
        },
        "color": {
          "field": "symbol",
          "type": "nominal"
        }
      },
      "transform": [
        {
          "filter": "datum.symbol == 'GOOG'"
        }
      ]
    },
    {
      "mark": {
        "type": "point"
      },
      "encoding": {
        "x": {
          "field": "date",
          "type": "temporal"
        },
        "y": {
          "field": "price",
          "type": "quantitative"
        },
        "color": {
          "field": "symbol",
          "type": "nominal"
        }
      },
      "transform": [
        {
          "filter": "datum.symbol == 'GOOG'"
        }
      ]
    }
  ],
  "$schema": "https://vega.github.io/schema/vega-lite/v3.4.0.json",
  "config": {
    "view": {
      "width": 400.0,
      "height": 300.0
    }
  },
  "data": {
    "url": "https://vega.github.io/vega-datasets/data/stocks.csv"
  }
};

        // Embed the visualization in the container with id `vis`
        vegaEmbed('#vis', vlSpec);
    </script>
</body>

</html>

```


# 开发设计资料
- [vega-lite官网](https://vega.github.io/vega-lite/)