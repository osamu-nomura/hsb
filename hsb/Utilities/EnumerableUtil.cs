using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Utilities
{
    #region 【Static Class : EnumerableUtil】
    /// <summary>
    /// 列挙関連ユーティリティ
    /// </summary>
    public static class EnumerableUtil
    {
        #region ■ Static Methods

        #region - Enumerator : 引数リストを列挙子で返す
        /// <summary>
        /// 引数リストを列挙子で返す
        /// </summary>
        /// <typeparam name="T">型パラメーター</typeparam>
        /// <param name="parameters">引数（可変）</param>
        /// <returns>列挙子</returns>
        public static IEnumerable<T> Enumerator<T>(params T[] parameters)
            => parameters;
        #endregion

        #region - Repeat : 指定した関数を指定回数実行し結果を列挙する
        /// <summary>
        /// 指定した関数を指定回数実行し結果を列挙する
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="func">値を返すコールバック</param>
        /// <param name="count">回数</param>
        /// <returns>列挙子</returns>
        public static IEnumerable<T> Repeat<T>(Func<int, T> func, int count)
            => Enumerable.Range(0, count).Select(n => func(n));
        #endregion

        #endregion
    }
    #endregion
}
