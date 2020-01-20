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
using System.Collections.Generic;
using CrystalWind.VegaSharp.Core.Transforms;
using CrystalWind.VegaSharp.Core.ViewCompositions;

namespace CrystalWind.VegaSharp.Core.Specifications
{
    public class SingleViewSpecification : TopLevelSpecification
    {
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


        public IMark Mark { get; set; }

        public Encoding Encoding { get; set; }


        public ViewBackground View { get; set; }

        [JsonProperty(PropertyName = "selection")]
        public IDictionary<string, Selection> Selections { get; set; }

        public Projection Projection { get; set; }

        public SingleViewSpecification Copy()
        {

            return new SingleViewSpecification
            {
                Autosize = Autosize,
                Background = Background,
                Config = Config,
                Data = Data,
                Description = Description,
                Name = Name,
                Padding = Padding,
                Schema = Schema,

                Title = Title,
                Transforms = Transforms == null ? null : new List<ITransform>(Transforms),
                Usermeta = Usermeta,

                Encoding = Encoding,
                Height = Height,
                Mark = Mark,
                Projection = Projection,
                Selections = Selections,
                View = View,
                Width = Width,
            };
        }


        public static LayerComposition operator +(SingleViewSpecification left, SingleViewSpecification right)
        {
            return new LayerComposition(new[] { left, right });
        }

        public static HConcatComposition operator |(SingleViewSpecification left, SingleViewSpecification right)
        {
            return new HConcatComposition(new[] { left, right });
        }

        public static VConcatComposition operator &(SingleViewSpecification left, SingleViewSpecification right)
        {
            return new VConcatComposition(new[] { left, right });
        }
    }




}
