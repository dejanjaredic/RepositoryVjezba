using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.EntityFrameworkCore.Internal;

namespace RrepTest.Models
{
    public class QueryInfo 
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public List<SortInfo> Sorters { get; set; } = new List<SortInfo>();
        public FilterInfo Filter { get; set; }

        public BinaryExpression GetWhereExp<TEntity>(ParameterExpression par, string op, string propName, string value)
        {
            Expression findPropExp = par;
            Expression curePropExp = par;

            string[] propNamesExp = propName.Split(".");
            foreach (var propNameExp in propNamesExp)
            {
                
                curePropExp = Expression.Property(curePropExp, propNameExp);

                findPropExp = Expression.Property(findPropExp, propNameExp);
            }

            var type = curePropExp.Type;
            var convertValue = Convert.ChangeType(value, type);
            var constant = Expression.Constant(convertValue);

            BinaryExpression binary;
            switch (convertValue)
            {
                case string _:
                    binary = GetBinaryExpressionForString(op, findPropExp, constant);
                    break;
                case int _:
                    binary = GetBinaryExpressdionForInt(op, findPropExp, constant);
                    break;
                default:
                    throw new ArgumentException($"Neocekivani tip vrijednosti '{type.Name}'");
            }

            return binary;
        }

        public Expression<Func<TEntity, bool>> GetWhereLambda<TEntity>(Expression binaryExp, ParameterExpression parameter)
        {
            var lambdaExp = Expression.Lambda<Func<TEntity, bool>>(binaryExp, parameter);
            return lambdaExp;
        }

        public BinaryExpression GetBinaryExpressdionForInt(string op, Expression propExpression, ConstantExpression constant)
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

        public  BinaryExpression GetBinaryExpressionForString(string op, Expression propExpression, ConstantExpression constant)
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

        public Expression<Func<TEntity, object>> OrderThings<TEntity>(string propName, string direction)
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
        //public static IQueryable<TEntity> OrderByQuery<TEntity>(IQueryable<TEntity> data, string propName, bool isAsc)
        //{
        //    string sort = isAsc ? "ascending" : "descendin";
        //    return data.OrderBy();
        //}

    }


}
