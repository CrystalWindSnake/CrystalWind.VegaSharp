using System.Drawing;

namespace CrystalWind.VegaSharp.Core.Encodings
{
    public class Legend : IVegaObject
    {

        //https://vega.github.io/vega-lite/docs/legend.html#properties
        #region General
        public double CornerRadius { get; set; }

        public string Direction { get; set; }

        public Color? FillColor { get; set; }

        public double LegendX { get; set; }
        public double LegendY { get; set; }
        public double Offset { get; set; }
        public string Orient { get; set; }
        public double Padding { get; set; }
        public Color? StrokeColor { get; set; }
        public dynamic StrokeWidth { get; set; }
        public string Type { get; set; }
        public dynamic TickCount { get; set; }
        public dynamic UnselectedOpacity { get; set; }
        public dynamic Values { get; set; }

        public double Zindex { get; set; }
        #endregion

        //https://vega.github.io/vega-lite/docs/legend.html#gradient
        #region Gradient
        public double GradientLength { get; set; }
        public double GradientThickness { get; set; }
        public Color? GradientStrokeColor { get; set; }
        public double GradientStrokeWidth { get; set; }

        #endregion


        //https://vega.github.io/vega-lite/docs/legend.html#labels
        #region Labels
        public string Format { get; set; }

        public string FormatType { get; set; }
        public string LabelAlign { get; set; }
        public string LabelBaseline { get; set; }
        public Color? LabelColor { get; set; }
        public string LabelFont { get; set; }
        public double LabelFontSize { get; set; }
        public string LabelFontStyle { get; set; }
        public double LabelLimit { get; set; }
        public double LabelOffset { get; set; }
        public string LabelOverlap { get; set; }

        #endregion


        //https://vega.github.io/vega-lite/docs/legend.html#symbols
        #region Symbols
        public Color? SymbolFillColor { get; set; }

        public double SymbolSize { get; set; }
        public Color? SymbolStrokeColor { get; set; }
        public double SymbolStrokeWidth { get; set; }
        public string SymbolType { get; set; }

        #endregion


        //https://vega.github.io/vega-lite/docs/legend.html#symbol-layout
        #region Symbol Layout
        public double ClipHeight { get; set; }

        public double ColumnPadding { get; set; }
        public double Columns { get; set; }
        public string GridAlign { get; set; }
        public double RowPadding { get; set; }

        #endregion

        //https://vega.github.io/vega-lite/docs/legend.html#title
        #region Title
        public string Title { get; set; }
        public string TitleAlign { get; set; }
        public string TitleAnchor { get; set; }
        public string TitleBaseline { get; set; }
        public Color? TitleColor { get; set; }
        public string TitleFont { get; set; }
        public double TitleFontSize { get; set; }
        public string TitleFontStyle { get; set; }
        public dynamic TtitleFontWeight { get; set; }
        public double TitleLimit { get; set; }
        public double TitleOpacity { get; set; }
        public double TitlePadding { get; set; }


        #endregion

    }
}