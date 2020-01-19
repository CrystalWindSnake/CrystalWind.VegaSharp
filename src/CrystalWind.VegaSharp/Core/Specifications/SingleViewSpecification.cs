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

        public IEncoding Encoding { get; set; }


        public ViewBackground View { get; set; }

        public Selection Selection { get; set; }

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
                Selection = Selection,
                View = View,
                Width = Width,
            };
        }




        public static LayerSpecification operator +(SingleViewSpecification left, SingleViewSpecification right)
        {
            return LayerSpecification.CreateFrom(left, right);
        }

        public static LayerSpecification operator +(LayerSpecification left, SingleViewSpecification right)
        {
            var res = left.Copy();
            res.Layers.Add(right);

            res.Transforms = null;
            return res;
        }
    }




}
