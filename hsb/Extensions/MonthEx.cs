using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hsb.Types;

namespace hsb.Extensions
{
    #region 【Static Class : MonthEx】
    /// <summary>
    /// 月 拡張メソッド
    /// </summary>
    public static class MonthEx
    {
        #region ■ Extension Methods

        #region - Add : 月を加算する
        /// <summary>
        /// 月を加算する
        /// </summary>
        /// <param name="month">this</param>
        /// <param name="n">加算数</param>
        /// <returns>nカ月後の月</returns>
        public static Month Add(this Month month, int n)
        {
            var m = (int)month + n;
            return (Month)(m > 12 ? m - 12 : (m < 1 ? m + 12 : m));
        }
        #endregion

        #endregion
    }
    #endregion
}
