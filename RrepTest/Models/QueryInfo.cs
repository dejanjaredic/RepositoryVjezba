using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace RrepTest.Models
{
    public class QueryInfo : Controller 
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public List<SortInfo> Sorters { get; set; } = new List<SortInfo>();
        public FilterInfo Filter { get; set; }

        public static Expression<Func<TEntity, bool>> GetWhereExpression<TEntity>(string op, string propertyName,
           string value)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "x");

            var propExpression = Expression.Property(parameter, propertyName);
            var type = propExpression.Type;
            var convertedValue = Convert.ChangeType(value, type);
            var constant = Expression.Constant(convertedValue);

            BinaryExpression binary;
            switch (convertedValue)
            {
                case string _:
                    binary = GetBinaryExpressionForString(op, propExpression, constant);
                    break;
                case int _:
                    binary = GetBinaryExpressdionForInt(op, propExpression, constant);
                    break;
                default:
                    throw new ArgumentException($"Neocekivani tip vrijednosti '{type.Name}'");
            }

            return Expression.Lambda<Func<TEntity, bool>>(binary, parameter);
        }



        public static BinaryExpression GetBinaryExpressdionForInt(string op, MemberExpression propExpression, ConstantExpression constant)
        {
            switch (op)
            {
                case "gt":
                    return Expression.GreaterThan(propExpression, constant);
                case "lt":
                    return Expression.LessThan(propExpression, constant);
                case "gte":
                    return Expression.GreaterThanOrEqual(propExpression, constant);
                case "lte":
                    return Expression.LessThanOrEqual(propExpression, constant);
                case "eq":
                    return Expression.Equal(propExpression, constant);

                default:
                    throw new InvalidOperationException($"Neocekivani operator {op}");
            }
        }

        public static BinaryExpression GetBinaryExpressionForString(string op, MemberExpression propExpression, ConstantExpression constant)
        {

            var trueExpression = Expression.Constant(true, typeof(bool));
            BinaryExpression bin;
            switch (op)
            {
                case "eq":
                    return Expression.Equal(propExpression, constant);
                case "ct":
                    MethodInfo methodInfo1 = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    var contains = Expression.Call(propExpression, methodInfo1, constant);
                    bin = Expression.Equal(contains, trueExpression);
                    break;

                default:
                    throw new InvalidOperationException($"neocekivani poerator {op}");
            }

            return bin;
        }

        public static Expression<Func<TEntity, object>> OrderThings<TEntity>(string propName)
        {
            var type = typeof(TEntity);
            var prop = type.GetProperty(propName);
            var param = Expression.Parameter(type);
            var access = Expression.Property(param, prop);
            var convert = Expression.Convert(access, typeof(object));
            var finalExp = Expression.Lambda<Func<TEntity, object>>(convert, param);
            return finalExp;
        }
        /*
         *_context.DeviceUsage.Where(x => x.PersonId == 1)
         * .OrderByDescending(x => x.DataFrom)
         * .ThenBy(x => x.Device.Name)
         * .Skip(0).Take(10)
        // */
        //public static IQueryable<TEntity> OrderByDinamic<TEntity>(IQueryable<TEntity> query, string propName,
        //    bool descending)
        //{
        //    var parameter = Expression.Parameter(typeof(TEntity), "x");
        //    string ordering = "OrderBy";
        //    if (descending)
        //    {
        //        ordering = "OrderByDescending";
        //    }

        //    Expression resultExpression = null;
        //    var property = typeof(TEntity).GetProperty(propName);
        //    var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        //    var orderByExpression = Expression.Lambda(propertyAccess, parameter);

        //    resultExpression = Expression.Call(typeof(Queryable), ordering, new Type[]{typeof(TEntity), property.PropertyType}, query.Expression, Expression.Quote(orderByExpression))
        //        ;

        //    return query.Provider.CreateQuery<TEntity>(resultExpression);
        //}

    }


}
