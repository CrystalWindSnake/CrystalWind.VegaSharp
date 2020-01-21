using CrystalWind.VegaSharp;
using System;
using System.IO;
using Xunit;

namespace CrystalWind.VegaSharp.UnitTest
{
    public class DatumTest
    {

        [Fact]
        public void Test_ToJsForString()
        {
            var act = Datum.To(d => d.String("symbol") == "GOOG");
            var exp = "(datum.symbol==='GOOG')";
            Assert.Equal(exp, act);
        }


        [Fact]
        public void Test_ToJsForDateTimeFunction_Year()
        {
            var act = Datum.To(d => d.DateTime("test").Year == 2010);
            var exp = "(year(datum.test)===2010)";
            Assert.Equal(exp, act);
        }

        [Fact]
        public void Test_ToJsForDateTimeFunction_Month()
        {
            var act = Datum.To(d => d.DateTime("test").Month == 12);
            var exp = "(month(datum.test)===12)";
            Assert.Equal(exp, act);
        }

        [Fact]
        public void Test_ToJsForDateTimeFunction_Day()
        {
            var act = Datum.To(d => d.DateTime("test").Day == 15);
            var exp = "(day(datum.test)===15)";
            Assert.Equal(exp, act);
        }
    }
}
