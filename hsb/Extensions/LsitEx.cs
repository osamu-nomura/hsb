using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Extensions
{
    #region 【Static Class : LsitEx】
    /// <summary>
    /// Listの拡張メソッド
    /// </summary>
    public static class LsitEx
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

        #region - Get : リストより値を取得する(1)
        /// <summary>
        /// リストより値を取得する（添え字が範囲外の場合、デフォルト値を返す）
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="list">this リスト</param>
        /// <param name="i">インデックス</param>
        /// <param name="defaultVallue">デフォルト値</param>
        /// <returns>リストの値</returns>
        public static T Get<T>(this List<T> list, int i, T defaultVallue)
        {
            if (list.Count > i && i >= 0)
                return list[i];
            else
                return defaultVallue;
        }
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
        public static T Get<T>(this List<T> list, int i, Func<T> generator)
        {
            if (list.Count > i && i >= 0)
                return list[i];
            else
                return generator();
        }
        #endregion

        #endregion
    }
    #endregion
}
