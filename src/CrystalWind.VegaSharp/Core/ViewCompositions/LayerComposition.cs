using CrystalWind.VegaSharp.Core.Configurations;
using CrystalWind.VegaSharp.Core.Data;
using CrystalWind.VegaSharp.Core.Encodings;
using CrystalWind.VegaSharp.Core.Marks;
using CrystalWind.VegaSharp.Properties;
using System.Drawing;
using System.IO;

using Newtonsoft.Json;
using CrystalWind.VegaSharp.Core.Selections;
using CrystalWind.VegaSharp.Core.Projections;
using System.Linq;
using System.Collections.Generic;
using CrystalWind.VegaSharp.Core.Transforms;
using CrystalWind.VegaSharp.Core.Specifications;

namespace CrystalWind.VegaSharp.Core.ViewCompositions
{
    public class LayerComposition : MultiViewComposition
    {
        public LayerComposition(IEnumerable<TopLevelSpecification> specifications) : base(specifications)
        {
        }

        [JsonProperty(PropertyName = "Layer")]
        public IReadOnlyCollection<TopLevelSpecification> Layers => Specifications;

        /// <summary>
        /// 使用 <see cref="MixValue"/> 类静态方法设置值。
        /// 此属性允许使用以下方法：
        /// <see cref="MixValue.SetNumber(double)"/>
        /// <see cref="MixValue.SetContainer"/>
        /// <see cref="MixValue.SetStep(double)"/>
        /// </summary>
        public IMixInternalValue Width { get; set; }

        /// <summary>
        /// 使用 <see cref="MixValue"/> 类静态方法设置值。
        /// 此属性允许使用以下方法：
        /// <see cref="MixValue.SetNumber(double)"/>;
        /// <see cref="MixValue.SetContainer"/>;
        /// <see cref="MixValue.SetStep(double)"/>;
        /// </summary>
        public IMixInternalValue Height { get; set; }


        public IEncoding Encoding { get; set; }


        public ViewBackground View { get; set; }


        public Projection Projection { get; set; }


        //public LayerComposition Copy()
        //{

        //    return new LayerComposition
        //    {
        //        Layers = Layers == null ? null : new List<TopLevelSpecification>(Layers),
        //        Autosize = Autosize,
        //        Background = Background,
        //        Config = Config,
        //        Data = Data,
        //        Description = Description,
        //        Name = Name,
        //        Padding = Padding,
        //        Schema = Schema,

        //        Title = Title,
        //        Transforms = Transforms == null ? null : new List<ITransform>(Transforms),
        //        Usermeta = Usermeta,

        //        Encoding = Encoding,
        //        Height = Height,
        //        Projection = Projection,
        //        View = View,
        //        Width = Width,
        //    };
        //}



        public static LayerComposition operator +(LayerComposition left, SingleViewSpecification right)
        {
            //var res = left.Copy();
            left.AddSpecification(right);
            //res.Transforms = null;
            return left;
        }

        public static HConcatComposition operator |(LayerComposition left, SingleViewSpecification right)
        {
            return new HConcatComposition(new TopLevelSpecification[] { left, right });
        }

        public static VConcatComposition operator &(LayerComposition left, SingleViewSpecification right)
        {
            return new VConcatComposition(new TopLevelSpecification[] { left, right });
        }
    }




}
