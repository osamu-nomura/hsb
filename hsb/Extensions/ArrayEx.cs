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
        {
            if (array.Length > i && i >= 0)
                return array[i];
            else
                return defaultValue;
        }
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
        {
            if (array.Length > i && i >= 0)
                return array[i];
            else
                return generator();
        }
        #endregion

        #endregion
    }
    #endregion
}
