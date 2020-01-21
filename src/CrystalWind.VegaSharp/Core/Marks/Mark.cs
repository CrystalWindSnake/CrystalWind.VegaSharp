namespace CrystalWind.VegaSharp.Core.Marks
{
    public abstract class Mark : IMark
    {
        public abstract string Type { get; }

        /// <summary>
        /// 使用 <see cref="MixValue"/> 类静态方法设置值。
        /// 此属性允许使用以下方法：
        /// <see cref="MixValue.SetText(string)"/>;
        /// <see cref="MixValue.SetStringArray(System.Collections.Generic.IEnumerable{string})"/>;
        /// </summary>
        public IMixInternalValue Style { get; set; }

        public IMixValue Tooltip { get; set; }

        public bool Clip { get; set; }

        public string Invalid { get; set; }

        public bool? Order { get; set; }

        public IMixInternalValue X { get; set; }
        public IMixInternalValue Y { get; set; }
        public IMixInternalValue X2 { get; set; }
        public IMixInternalValue Y2 { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double XOffset { get; set; }
        public double X2Offset { get; set; }
        public double YOffset { get; set; }
        public double Y2Offset { get; set; }


        public bool Filled { get; set; }
        public IMixValue Color { get; set; }
        public IMixValue Fill { get; set; }
        public IMixValue Stroke { get; set; }
        public double Opacity { get; set; }
        public double FillOpacity { get; set; }
        public double StrokeOpacity { get; set; }



    }
}