using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Extensions
{
    public static class ExpressionExtensions
    {
        public static string? AsPath(this LambdaExpression expression)
        {
            if (expression == null) return default;

            var exp = expression.Body;
            string path;
            TryParsePath(exp, out path);
            return path;
        }

        // This method is a slight modification of EF6 source code
        private static bool TryParsePath(Expression expression, out string path)
        {
            path = null;
            var withoutConvert = RemoveConvert(expression);
            var memberExpression = withoutConvert as MemberExpression;
            var callExpression = withoutConvert as MethodCallExpression;

            if (memberExpression != null)
            {
                var thisPart = memberExpression.Member.Name;
                string parentPart;
                if (!TryParsePath(memberExpression.Expression, out parentPart))
                {
                    return false;
                }
                path = parentPart == null ? thisPart : (parentPart + "." + thisPart);
            }
            else if (callExpression == null)
                return true;


            if (callExpression.Method.Name == nameof(Enumerable.Select)
                && callExpression.Arguments.Count == 2)
            {
                if (!TryParsePath(callExpression.Arguments[0], out string parentPart) || parentPart == null)
                {
                    return false;
                }
                var subExpression = callExpression.Arguments[1] as LambdaExpression;
                if (subExpression == null)
                    return false;
                string thisPart;
                if (!TryParsePath(subExpression.Body, out thisPart) || thisPart == null)
                {
                    return false;
                }
                path = parentPart + "." + thisPart;
                return true;
            }
            else if (callExpression.Method.Name == nameof(Enumerable.Where))
            {
                throw new NotSupportedException("Filtering an Include expression is not supported");
            }
            else if (callExpression.Method.Name == nameof(Enumerable.OrderBy) || callExpression.Method.Name == nameof(Enumerable.OrderByDescending))
            {
                throw new NotSupportedException("Ordering an Include expression is not supported");
            }
            return false;
        }

        // Removes boxing
        private static Expression RemoveConvert(Expression expression)
        {
            while (expression.NodeType == ExpressionType.Convert
                   || expression.NodeType == ExpressionType.ConvertChecked)
            {
                expression = ((UnaryExpression)expression).Operand;
            }

            return expression;
        }
    }
}
