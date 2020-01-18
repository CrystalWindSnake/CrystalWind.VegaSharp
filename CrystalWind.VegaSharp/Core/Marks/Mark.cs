namespace CrystalWind.VegaSharp.Core.Marks
{
    public abstract class Mark : IMark
    {
        public abstract string Type { get; }

        public static Bar Bar => new Bar();
        public static Area Area => new Area();
        public static BoxPlot BoxPlot => new BoxPlot();
        public static Circle Circle => new Circle();
        public static ErrorBand ErrorBand => new ErrorBand();
        public static ErrorBar ErrorBar => new ErrorBar();
        public static Geoshape Geoshape => new Geoshape();
        public static Image Image => new Image();
        public static Line Line => new Line();
        public static Point Point => new Point();
        public static Rect Rect => new Rect();
        public static Rule Rule => new Rule();
        public static Square Square => new Square();
        public static Text Text => new Text();
        public static Tick Tick => new Tick();
        public static Trail Trail => new Trail();
    }
}