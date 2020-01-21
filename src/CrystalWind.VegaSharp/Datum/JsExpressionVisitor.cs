

using System;
using System.Linq.Expressions;
using System.Text;

namespace CrystalWind.VegaSharp
{
    internal class JsExpressionVisitor : ExpressionVisitor
    {
        private StringBuilder stringBuilder = new StringBuilder(50);

        private static string GetOperationChar(ExpressionType type)
        {
            switch (type)
            {
                case ExpressionType.Add:
                    return "+";
                case ExpressionType.Subtract:
                    return "-";
                case ExpressionType.Multiply:
                    return "*";
                case ExpressionType.Divide:
                    return "/";
                case ExpressionType.And | ExpressionType.AndAlso:
                    return "&&";
                case ExpressionType.Or | ExpressionType.OrElse:
                    return "||";
                case ExpressionType.NotEqual:
                    return "!==";
                case ExpressionType.Equal:
                    return "===";
                case ExpressionType.GreaterThan:
                    return ">";
                case ExpressionType.GreaterThanOrEqual:
                    return ">=";
                case ExpressionType.LessThan:
                    return "<";
                case ExpressionType.LessThanOrEqual:
                    return "<=";
            }

            return null;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            //日期属性的调用
            if (node.Member.DeclaringType == typeof(DateTime))
            {
                stringBuilder.Append(node.Member.Name.ToLower());
                stringBuilder.Append("(");
                Visit(node.Expression);
                stringBuilder.Append(")");
            }
            else
            {
                stringBuilder.Append(node.Member.Name);
            }

            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node.Type == typeof(string))
            {
                stringBuilder.AppendFormat("'{0}'", node.Value);
            }
            else
            {
                stringBuilder.Append(node.Value);
            }

            return node;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Object.Type == typeof(DatumModel))
            {
                var arg = node.Arguments[0] as ConstantExpression;
                stringBuilder.AppendFormat("datum.{0}", arg.Value);
                //base.Visit(node.Arguments[0]);
            }

            return node;
        }


        protected override Expression VisitBinary(BinaryExpression node)
        {
            stringBuilder.Append("(");
            base.Visit(node.Left);
            stringBuilder.Append(GetOperationChar(node.NodeType));
            base.Visit(node.Right);
            stringBuilder.Append(")");
            return node;
        }


        public string GetExpressionString(Expression<Func<DatumModel, bool>> expression)
        {
            Visit(expression);
            return stringBuilder.ToString();

        }
    }

}
