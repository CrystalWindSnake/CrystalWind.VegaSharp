using CrystalWind.VegaSharp.Core;
using CrystalWind.VegaSharp.Core.Data;
using CrystalWind.VegaSharp.Core.Encodings;
using CrystalWind.VegaSharp.Core.Marks;
using CrystalWind.VegaSharp.Core.Specifications;
using System;
using System.IO;
using Xunit;

namespace CrystalWind.VegaSharp.UnitTest
{
    public class EngineTest
    {
        [Fact]
        public void Test_ToJsonView()
        {
            var data = new RecordArrayData<MyClass>(new[]
                {
                    new MyClass{Name="a",Value=12},
                    new MyClass{Name="b",Value=20},
                    new MyClass{Name="c",Value=25},
                });

            var mark = new Bar();
            var ec = new Encoding
            {
                X = Vega.X_Y("Name"),
                Y = Vega.X_Y("Value", FieldType.Quantitative)
            };

            var eg = new SingleViewSpecification
            {
                Data = data,
                Encoding = ec,
                Mark = mark
            };

            var act = eg.ToJsonView();

            var exp = File.ReadAllText(@"Engine\Test_ToJsonView.txt", System.Text.Encoding.UTF8);
            Assert.Equal(exp, act);

        }
    }

    class MyClass
    {
        public string Name { get; set; }


        public int Value { get; set; }
    }
}
