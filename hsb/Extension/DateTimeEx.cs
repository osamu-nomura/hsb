using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Extension
{
    #region 【Static Class : DateTimeEx】
    /// <summary>
    /// DateTime 拡張メソッド
    /// </summary>
    public static class DateTimeEx
    {
        #region ■ Extension Methods

        #region - BeginOfMonth : 月初日を取得する
        /// <summary>
        /// 月初日を取得する
        /// </summary>
        /// <param name="dt">this : 日付</param>
        /// <returns>対象日付の月初日を返す。</returns>
        public static DateTime BeginOfMonth(this DateTime dt)
        {
            return dt.AddDays((dt.Day - 1) * -1);
        }
        #endregion

        #endregion
    }
    #endregion
}
