namespace CrystalWind.VegaSharp.Core.Configurations
{
    public class View : IVegaObject
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double ContinuousWidth { get; set; }
        public double ContinuousHeight { get; set; }
        public IMixValue DiscreteWidth { get; set; }
        public IMixValue DiscreteHeight { get; set; }
        public double Step { get; set; }
    }
}