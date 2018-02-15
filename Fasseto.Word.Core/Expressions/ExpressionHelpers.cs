using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// A helper for expressions
    /// </summary>
    public static class ExpressionHelpers
    {
        /// <summary>
        /// Compiles an expression and Invoke it
        /// </summary>
        /// <typeparam name="T">return Generic type (Unknown type)</typeparam>
        /// <param name="lambda">Name of an expression</param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lambda)
        {
            return lambda.Compile().Invoke();
        }
        /// <summary>
        /// Sets the underlying properties value to the given value, from an expression that contains the property
        /// </summary>
        /// <typeparam name="T">The type of value to set</typeparam>
        /// <param name="lambda">Expression</param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> lambda, T value)
        {
            //This converts a lambda => some.property, to some.peroperty
            var expression = (lambda as LambdaExpression).Body as MemberExpression;

            //Get the property information se we can set it

            var propertyInfo = (PropertyInfo)expression.Member;

            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            //Set the property value
            propertyInfo.SetValue(target, value);
        }

    }
}
