using CrystalWind.VegaSharp.VegaMode;

namespace CrystalWind.VegaSharp.Core.Encodings
{
    public class Encoding : IVegaObject
    {
        #region Position Channels
        public IPositionChannel X { get; set; }
        public IPositionChannel Y { get; set; }

        public IPositionChannel X2 { get; set; }
        public IPositionChannel Y2 { get; set; }

        public IPositionChannel XError { get; set; }
        public IPositionChannel YError { get; set; }

        public IPositionChannel XError2 { get; set; }
        public IPositionChannel YError2 { get; set; }
        #endregion


        #region Mark Property Channels
        /// <summary>
        /// Mark Property Channels
        /// </summary>
        public IMarkPropertyChannel Color { get; set; }
        /// <summary>
        /// Mark Property Channels
        /// </summary>
        public IMarkPropertyChannel Fill { get; set; }

        /// <summary>
        /// Mark Property Channels
        /// </summary>
        public IMarkPropertyChannel Stroke { get; set; }

        /// <summary>
        /// Mark Property Channels
        /// </summary>
        public IMarkPropertyChannel Opacity { get; set; }

        /// <summary>
        /// Mark Property Channels
        /// </summary>
        public IMarkPropertyChannel FillOpacity { get; set; }

        /// <summary>
        /// Mark Property Channels
        /// </summary>
        public IMarkPropertyChannel StrokeOpacity { get; set; }

        /// <summary>
        /// Mark Property Channels
        /// </summary>
        public IMarkPropertyChannel Shape { get; set; }

        /// <summary>
        /// Mark Property Channels
        /// </summary>
        public IMarkPropertyChannel Size { get; set; }

        /// <summary>
        /// Mark Property Channels
        /// </summary>
        public IMarkPropertyChannel StrokeWidth { get; set; }
        #endregion

        #region Text and Tooltip Channels
        public ITextAndTooltipChannel Text { get; set; }
        public ITextAndTooltipChannel Tooltip { get; set; }

        #endregion

        /// <summary>
        /// Hyperlink Channel
        /// </summary>
        public IHyperlinkChannel Href { get; set; }

        /// <summary>
        /// Level of Detail Channel
        /// </summary>
        public ILevelOfDetailChannel Detail { get; set; }
        /// <summary>
        /// Key Channel
        /// </summary>
        public IKeyChannel Key { get; set; }
        /// <summary>
        /// Order Channel
        /// </summary>
        public IOrderChannel Order { get; set; }


        /// <summary>
        /// Facet Channel
        /// </summary>
        public IFacetChannel Facet { get; set; }
        /// <summary>
        /// Facet Channel
        /// </summary>
        public IFacetChannel Row { get; set; }
        /// <summary>
        /// Facet Channel
        /// </summary>
        public IFacetChannel Column { get; set; }

    }


}