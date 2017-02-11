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
        /// <param name="values">this 列挙子</param>
        /// <param name="separator">区切り文字</param>
        /// <param name="converter">変換関数</param>
        /// <returns>列挙された値を結合した文字列</returns>
        public static string ToString<T>(this IEnumerable<T> values, string separator, Func<T, string> converter = null)
        {
            if (converter != null)
                return string.Join(separator, values.Select(converter));
            else
                return string.Join(separator, values);
        }
        #endregion

        #endregion
    }
    #endregion
}
