using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb
{
    #region 【Static Class : Tool】
    /// <summary>
    /// ヘルパメソッド
    /// </summary>
    public static class Tool
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
        {
            return parameters;
        }
        #endregion

        #endregion
    }
    #endregion
}
