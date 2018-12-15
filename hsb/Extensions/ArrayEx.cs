using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Extensions
{
    #region 【Static Class : ArrayEx】
    /// <summary>
    /// 配列の拡張メソッド
    /// </summary>
    public static class ArrayEx
    {
        #region ■ Extension Methods

        #region - Get : 配列より値を取得する(1)
        /// <summary>
        /// 配列より値を取得する（添え字が範囲外だった場合はデフォルト値を返す）
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="array">this 配列</param>
        /// <param name="i">添え字</param>
        /// <param name="defaultValue">デフォルト値</param>
        /// <returns>配列の値</returns>
        public static T Get<T>(this T[] array, int i, T defaultValue)
            => array.IsWithin(i) ? array[i] : defaultValue;
        #endregion

        #region - Get : 配列より値を取得する(2)
        /// <summary>
        /// 配列より値を取得する（添え字が範囲外の場合、デフォルト値を返す）
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="array">this 配列</param>
        /// <param name="i">インデックス</param>
        /// <param name="generator">添え字が範囲外だった場合に呼ばれるコールバック</param>
        /// <returns>リストの値</returns>
        public static T Get<T>(this T[] array, int i, Func<T> generator)
            => array.IsWithin(i) ? array[i] : generator();
        #endregion

        #region - IsWithin : インデックスが範囲内かどうかチェックする
        /// <summary>
        /// インデックスが範囲内かどうかチェックする
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="array">this 配列</param>
        /// <param name="i">インデックス</param>
        /// <returns>True : 範囲内 / False : 範囲外</returns>
        public static bool IsWithIn<T>(this T[] array, int i)
            => array.Length > i && i >= 0;
        #endregion

        #region - Choice : 配列より要素をランダムに取得する
        /// <summary>
        /// 配列より要素をランダムに取得する
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="array">this 配列</param>
        /// <param name="r">Randomクラスのインスタンス</param>
        /// <returns>ランダムに選択された配列の要素</returns>
        public static T Choice<T>(this T[] array, Random r = null)
            => array[(r ?? new Random()).Next(array.Length )];
        #endregion

        #endregion
    }
    #endregion
}
