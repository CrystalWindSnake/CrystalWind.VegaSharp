using CrystalWind.VegaSharp.Core;
using CrystalWind.VegaSharp.Core.Configurations;
using CrystalWind.VegaSharp.Core.Data;
using CrystalWind.VegaSharp.Core.Encodings;
using CrystalWind.VegaSharp.Core.Marks;
using CrystalWind.VegaSharp.Core.Specifications;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CrystalWind.VegaSharp
{
    public static partial class Vega
    {


        private static SingleViewSpecification GetDefalut()
        {
            return new SingleViewSpecification
            {

            };
        }

        public static SingleViewSpecification SetData(IData data)
        {
            var eg = GetDefalut();
            eg.Data = data;
            return eg;
        }

        public static SingleViewSpecification SetData(string url)
        {
            var eg = GetDefalut();
            eg.Data = new UrlData(url);
            return eg;
        }

        public static SingleViewSpecification SetData<TData>(IEnumerable<TData> data)
        {
            var eg = GetDefalut();
            eg.Data = new RecordArrayData<TData>(data.ToArray());
            return eg;
        }

        public static SingleViewSpecification SetMark(IMark mark)
        {
            var eg = GetDefalut();
            eg.Mark = mark;
            return eg;
        }

        public static SingleViewSpecification SetEncoding(IEncoding encoding)
        {
            var eg = GetDefalut();
            eg.Encoding = encoding;
            return eg;
        }



    }




}
