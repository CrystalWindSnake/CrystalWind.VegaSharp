namespace CrystalWind.VegaSharp.Core.Marks
{
    public class Bar : Mark
    {
        public override string Type => "bar";

        public string Orient { get; set; }

        /// <summary>
        /// The horizontal alignment of the text or ranged marks (area, bar, image, rect, rule). 
        /// One of "left", "right", "center"
        /// </summary>
        public RangedMarksAlign Align { get; set; }

        /// <summary>
        /// The vertical alignment of the text or ranged marks (area, bar, image, rect, rule). 
        /// One of "top", "middle", "bottom".
        /// Default value: "middle"
        /// </summary>
        public RangedMarksBaseline Baseline { get; set; }
        public double BinSpacing { get; set; }

        public double CornerRadius { get; set; }

        public double CornerRadiusTopLeft { get; set; }
        public double CornerRadiusTopRight { get; set; }
        public double CornerRadiusBottomRight { get; set; }
        public double CornerRadiusBottomLeft { get; set; }
    }
}