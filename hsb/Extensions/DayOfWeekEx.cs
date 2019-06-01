using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hsb.Extensions
{
    #region 【Static Class : DayOfWeekEx】
    /// <summary>
    /// 曜日拡張メソッド」
    /// </summary>
    public static class DayOfWeekEx
    {
        #region ■ Static Members
        /// <summary>
        /// 基準とする日曜日の日付(2017/01/01)
        /// </summary>
        private static readonly DateTime _sunday = new DateTime(2017, 1, 1);

        #endregion

        #region ■ Extension Methods

        #region - ToFullString : 長い文字列化
        /// <summary>
        /// 長い文字列化(ex 月曜日, Monday)
        /// </summary>
        /// <param name="dow">曜日</param>
        /// <param name="provider">フォーマットプロバイダー</param>
        /// <returns>曜日を示す長い文字列</returns>
        public static string ToFullString(this DayOfWeek dow, IFormatProvider provider = null)
            => _sunday.AddDays((int)dow).ToString("dddd", provider ?? Thread.CurrentThread.CurrentUICulture);
        #endregion

        #region - ToShortString : 短い文字列化
        /// <summary>
        /// 短い文字列化(ex 月, Mon)
        /// </summary>
        /// <param name="dow">曜日</param>
        /// <param name="provider">フォーマットプロバイダー</param>
        /// <returns>曜日を示す短い文字列</returns>
        public static string ToShortString(this DayOfWeek dow, IFormatProvider provider = null)
            => _sunday.AddDays((int)dow).ToString("ddd", provider ?? Thread.CurrentThread.CurrentUICulture);
        #endregion

        #endregion
    }
    #endregion
}
