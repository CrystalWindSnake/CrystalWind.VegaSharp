using CrystalWind.VegaSharp;
using System;
using System.IO;
using Xunit;

namespace CrystalWind.VegaSharp.UnitTest
{
    public class DatumTest
    {

        [Fact]
        public void Test_ToJs()
        {
            var act = Datum.To(d => d.String("symbol") == "GOOG");
            var exp = "(datum.symbol==='GOOG')";
            Assert.Equal(exp, act);
        }

    }
}
