using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Extensions
{
    #region 【Static Class : ListEx】
    /// <summary>
    /// Listの拡張メソッド
    /// </summary>
    public static class ListEx
    {
        #region ■ Extension Methods

        #region - Add : リストに要素を追加する
        /// <summary>
        /// リストに要素を追加する
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="list">this リスト</param>
        /// <param name="items">要素（可変）</param>
        public static void Add<T>(this List<T> list, params T[] items)
        {
            list.AddRange(items);
        }
        #endregion

        #region - AddWithoutNull : 要素がNULLでなければリストに追加する
        /// <summary>
        /// 要素がNULLでなければリストに追加する
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="list">this リスト</param>
        /// <param name="item">要素</param>
        public static void AddWithoutNull<T>(this List<T> list, T item) where T: class
        {
            if (item != null)
                list.Add(item);
        }
        #endregion

        #region - Get : リストより値を取得する(1)
        /// <summary>
        /// リストより値を取得する（添え字が範囲外の場合、デフォルト値を返す）
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="list">this リスト</param>
        /// <param name="i">インデックス</param>
        /// <param name="defaultVallue">デフォルト値</param>
        /// <returns>リストの値</returns>
        public static T Get<T>(this IList<T> list, int i, T defaultVallue)
            => (list.Count > i && i >= 0) ? list[i] : defaultVallue;
        #endregion

        #region - Get : リストより値を取得する(2)
        /// <summary>
        /// リストより値を取得する（添え字が範囲外の場合、デフォルト値を返す）
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="list">this リスト</param>
        /// <param name="i">インデックス</param>
        /// <param name="generator">添え字が範囲外だった場合に呼ばれるコールバック</param>
        /// <returns>リストの値</returns>
        public static T Get<T>(this IList<T> list, int i, Func<T> generator)
            => (list.Count > i && i >= 0) ? list[i] : generator();
        #endregion

        #region - PickOut : リストより値を取り出す。
        /// <summary>
        /// リストより要素を取り出す。
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="list">this リスト</param>
        /// <param name="i">インデックス</param>
        /// <returns>リストより取り出した値</returns>
        public static T PickOut<T>(this IList<T> list, int i)
        {
            if (list.Count > i && i >= 0)
            {
                var item = list[i];
                list.RemoveAt(i);
                return item;
            }
            throw new IndexOutOfRangeException();
        }
        #endregion

        #endregion
    }
    #endregion
}
