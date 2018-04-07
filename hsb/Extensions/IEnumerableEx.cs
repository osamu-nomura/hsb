using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Extensions
{
    #region 【Static Class : IEnumerableEx】
    /// <summary>
    /// IEnumerableの拡張メソッド
    /// </summary>
    public static class IEnumerableEx
    {
        #region ■ Extension Methods

        #region - ToString : 文字列化
        /// <summary>
        /// 文字列化
        /// </summary>
        /// <typeparam name="T">型パラメーター</typeparam>
        /// <param name="collection">this 列挙子</param>
        /// <param name="separator">区切り文字</param>
        /// <param name="converter">変換関数</param>
        /// <returns>列挙された値を結合した文字列</returns>
        public static string ToString<T>(this IEnumerable<T> collection, string separator, Func<T, string> converter = null)
        {
            if (converter != null)
                return string.Join(separator, collection.Select(converter));
            else
                return string.Join(separator, collection);
        }
        #endregion

        #region - Shuffle : IEnumerable をシャッフルする
        /// <summary>
        /// Enumerable をシャッフルする
        /// </summary>
        /// <typeparam name="T">要素の型</typeparam>
        /// <param name="collection">IEnumerable</param>
        /// <returns>IEnumerable</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> collection)
        {
            return collection.OrderBy(i => Guid.NewGuid());
        }
        #endregion

        #region - ForEach : IEnumerable版 ForEach
        /// <summary>
        /// IEnumerable版 ForEach
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="collection">IEnumerable版</param>
        /// <param name="action">コールバック</param>
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }
        #endregion

        #region - Split : IEnumerable を指定個数のリストのリストに変換する
        /// <summary>
        /// IEnumerable を指定個数のリストのリストに変換する
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="collection">IEnumerable版</param>
        /// <param name="size">配列のサイズ</param>
        /// <returns>リストのリスト</returns>
        public static List<List<T>> Split<T>(this IEnumerable<T> collection, int size)
        {
            if (size <= 0)
                throw new ArgumentException();

            var n = 0;
            var list = new List<List<T>>();
            var items = new List<T>();
            foreach (var item in collection)
            {
                if (n >= size)
                {
                    list.Add(items);
                    items = new List<T>();
                    n = 0;
                }
                items.Add(item);
                n++;
            }
            if (n > 0)
                list.Add(items);
            return list;
        }
        #endregion

        #endregion
    }
    #endregion
}
