using CrystalWind.VegaSharp.Core;
using CrystalWind.VegaSharp.Core.Configurations;
using CrystalWind.VegaSharp.Core.Data;
using CrystalWind.VegaSharp.Core.Encodings;
using CrystalWind.VegaSharp.Core.Marks;
using CrystalWind.VegaSharp.Core.Selections;
using CrystalWind.VegaSharp.Core.Specifications;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CrystalWind.VegaSharp.Shadow
{
    public class VegaMarks
    {
        public Bar Bar => new Bar();
        public Area Area => new Area();
        public BoxPlot BoxPlot => new BoxPlot();
        public Circle Circle => new Circle();
        public ErrorBand ErrorBand => new ErrorBand();
        public ErrorBar ErrorBar => new ErrorBar();
        public Geoshape Geoshape => new Geoshape();
        public Image Image => new Image();
        public Line Line => new Line();
        public Point Point => new Point();
        public Rect Rect => new Rect();
        public Rule Rule => new Rule();
        public Square Square => new Square();
        public Text Text => new Text();
        public Tick Tick => new Tick();
        public Trail Trail => new Trail();

    }




}
