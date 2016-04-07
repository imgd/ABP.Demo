using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Demo.EntityFramework.Common
{
    public static class LinqExtesions
    {
        #region LINQ 扩展

        /// <summary>
        /// 去除重复项
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <typeparam name="TKey">对象key</typeparam>
        /// <param name="source">数据对象</param>
        /// <param name="keySelector">去除重复项规则</param>
        /// <returns></returns>
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();

            foreach (T element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// 根据条件选择
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="func">选择器</param>        
        /// <returns></returns>
        public static IQueryable<T> WhereIfNull<T>(this IQueryable<T> source, Expression<Func<T, bool>> func)
        {
            return source == null ? null : source.Where(func);
        }
        /// <summary>
        /// 根据条件选择
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="func">选择器</param>
        /// <param name="condition">是否采用选择器</param>
        /// <returns></returns>
        public static IQueryable<T> WhereIfNull<T>(this IQueryable<T> source, Expression<Func<T, bool>> func, bool condition)
        {
            return source == null ? null : (condition ? source.Where(func) : source);
        }
        /// <summary>
        /// 根据条件选择
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="func">选择器</param>        
        /// <returns></returns>
        public static IEnumerable<T> WhereIfNull<T>(this IEnumerable<T> source, Func<T, bool> func)
        {
            return source == null ? null : source.Where(func);
        }

        /// <summary>
        /// 根据条件选择
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="func">选择器</param>
        /// <param name="condition">是否采用选择器</param>
        /// <returns></returns>
        public static IEnumerable<T> WhereIfNull<T>(this IEnumerable<T> source, Func<T, bool> func, bool condition)
        {
            return source == null ? null : (condition ? source.Where(func) : source);
        }


        /// <summary>
        /// 判断对象是否在数组内
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="t">对象</param>
        /// <param name="tc">对象集合</param>
        /// <returns></returns>
        public static bool IsInArray<T>(this T t, params T[] tc)
        {
            return tc.Any(o => o.Equals(t));
        }

        #endregion
    }
}
