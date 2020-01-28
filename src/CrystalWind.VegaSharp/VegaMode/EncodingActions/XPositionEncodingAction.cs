using CrystalWind.VegaSharp.Core.Encodings;
using System;
using System.Collections.Generic;

namespace CrystalWind.VegaSharp.VegaMode
{
    public class XPositionEncodingAction : PositionField, IEncodingAction
    {

        void IEncodingAction.Action(Encoding encoding)
        {
            if (!string.IsNullOrEmpty(Name) && this.Type == FieldType.None)
            {
                this.SetName(this.Name);
            }
            encoding.X = this;
        }
    }
}
