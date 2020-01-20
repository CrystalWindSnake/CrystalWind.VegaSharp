

using System;
using System.Linq.Expressions;

namespace CrystalWind.VegaSharp
{
    public static class Datum
    {
        public static string To(Expression<Func<DatumModel, bool>> expression)
        {
            return new JsExpressionVisitor().GetExpressionString(expression);
        }
    }

}
