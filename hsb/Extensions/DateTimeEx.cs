using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Extensions
{
    #region 【Static Class : DateTimeEx】
    /// <summary>
    /// DateTime 拡張メソッド
    /// </summary>
    public static class DateTimeEx
    {
        #region ■ Extension Methods

        #region - SetYear : 対象日の年を変更した値を返す
        /// <summary>
        /// 対象日の年を変更した値を返す
        /// </summary>
        /// <param name="dt">this 日付</param>
        /// <param name="year">年</param>
        /// <returns>指定した年に変更した日付</returns>
        public static DateTime SetYear(this DateTime dt, int year)
        {
            return new DateTime(year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }
        #endregion

        #region - SetMonth : 対象日の月を変更した値を返す
        /// <summary>
        /// 対象日の月を変更した値を返す
        /// </summary>
        /// <param name="dt">this 日付</param>
        /// <param name="month">月</param>
        /// <returns>指定した月に変更した日付</returns>
        public static DateTime SetMonth(this DateTime dt, int month)
        {
            return new DateTime(dt.Year, month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }
        #endregion

        #region - SetDay : 対象日の日を変更した値を返す
        /// <summary>
        /// 対象日の日を変更した値を返す
        /// </summary>
        /// <param name="dt">this 日付</param>
        /// <param name="day">日</param>
        /// <returns>指定した日に変更した日付</returns>
        public static DateTime SetDay(this DateTime dt, int day)
        {
            return new DateTime(dt.Year, dt.Month, day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }
        #endregion

        #region - SafeSetYear : 対象日の年を変更した値を返す(安全版)
        /// <summary>
        /// 対象日の年を変更した値を返す
        /// 値が不正な場合はNULLを返す
        /// </summary>
        /// <param name="dt">this 日付</param>
        /// <param name="year">年</param>
        /// <returns>指定した年に変更した日付</returns>
        public static DateTime? SafeSetYear(this DateTime dt, int year)
        {
            try { return dt.SetYear(year); }
            catch (ArgumentOutOfRangeException) { return null;  }
        }
        #endregion

        #region - SafeSetMonth : 対象日の月を変更した値を返す(安全版)
        /// <summary>
        /// 対象日の月を変更した値を返す
        /// 値が不正な場合はNULLを返す
        /// </summary>
        /// <param name="dt">this 日付</param>
        /// <param name="month">月</param>
        /// <returns>指定した月に変更した日付</returns>
        public static DateTime? SafeSetMonth(this DateTime dt, int month)
        {
            try { return dt.SetMonth(month); }
            catch (ArgumentOutOfRangeException) { return null; }
        }
        #endregion

        #region - SafeSetDay : 対象日の日を変更した値を返す(安全版)
        /// <summary>
        /// 対象日の日を変更した値を返す
        /// 値が不正な場合はNULLを返す
        /// </summary>
        /// <param name="dt">this 日付</param>
        /// <param name="day">日</param>
        /// <returns>指定した日に変更した日付</returns>
        public static DateTime? SafeSetDay(this DateTime dt, int day)
        {
            try { return dt.SetDay(day); }
            catch (ArgumentOutOfRangeException) { return null; }
        }
        #endregion

        #region - IsLeapYear : 対象日を含む年が閏年かどうかを返す
        /// <summary>
        /// 対象日を含む年が閏年かどうかを返す
        /// </summary>
        /// <param name="dt">this 日付</param>
        /// <returns>True : 閏年 / False: 閏年でない</returns>
        public static bool IsLeapYear(this DateTime dt)
        {
            return DateTime.IsLeapYear(dt.Year);
        }
        #endregion

        #region - BeginOfYear : 対象日を含む年の年初日を返す
        /// <summary>
        /// 対象日を含む年の年初日を返す
        /// </summary>
        /// <param name="dt">this 日付</param>
        /// <returns>対象日を含む年の年初日</returns>
        public static DateTime BeginOfYear(this DateTime dt)
        {
            return new DateTime(dt.Year, 1, 1, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }
        #endregion

        #region - EndOfYear : 対象日を含む年の大みそかを返す
        /// <summary>
        /// 対象日を含む年の大みそかを返す
        /// </summary>
        /// <param name="dt">this 日付</param>
        /// <returns>対象日を含む年の大みそか</returns>
        public static DateTime EndOfYear(this DateTime dt)
        {
            return new DateTime(dt.Year, 12, 31, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }
        #endregion

        #region - BeginOfMonth : 対象日を含む月の月初日を返す
        /// <summary>
        /// 対象日を含む月の月初日を返す
        /// </summary>
        /// <param name="dt">this : 日付</param>
        /// <returns>対象日を含む月の月初日</returns>
        public static DateTime BeginOfMonth(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }
        #endregion

        #region - EndOfMonth : 対象日を含む月の月末日を返す
        /// <summary>
        /// 対象日を含む月の月末日を返す
        /// </summary>
        /// <param name="dt">this : 日付</param>
        /// <returns>対象日付の月末日</returns>
        public static DateTime EndOfMonth(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month), dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }
        #endregion

        #endregion
    }
    #endregion
}
