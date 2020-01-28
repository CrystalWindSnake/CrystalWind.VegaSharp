using CrystalWind.VegaSharp.Core.Encodings;
using System;
using System.Collections.Generic;

namespace CrystalWind.VegaSharp.VegaMode
{
    public class ColorEncodingAction : MarkPropertyField, IEncodingAction
    {

        void IEncodingAction.Action(Encoding encoding)
        {
            if (!string.IsNullOrEmpty(Name) && Type == FieldType.None)
            {
                this.SetName(Name);
            }
            encoding.Color = this;
        }
    }
}
