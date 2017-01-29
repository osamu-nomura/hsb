using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hsb.Types;
using hsb.Classes;

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

        #region - SundayOfWeek : 対象日を含む週の日曜日を返す。
        /// <summary>
        /// 対象日を含む週の日曜日を返す。
        /// </summary>
        /// <param name="dt">this 日付</param>
        /// <returns>対象日を含む週の日曜日</returns>
        public static DateTime SundayOfWeek(this DateTime dt)
        {
            if (dt.DayOfWeek != DayOfWeek.Sunday)
                return dt.AddDays((int)dt.DayOfWeek * -1);
            else
                return dt;
        }
        #endregion

        #region - MondayOfWeek : 対象日を含む週の月曜日を返す。
        /// <summary>
        /// 対象日を含む週の月曜日を返す。
        /// </summary>
        /// <param name="dt">this 日付</param>
        /// <returns>対象日を含む週の月曜日</returns>
        public static DateTime MondayOfWeek(this DateTime dt)
        {
            if (dt.DayOfWeek != DayOfWeek.Monday)
                return dt.AddDays(((int)dt.DayOfWeek - 1) * -1);
            else
                return dt;
        }
        #endregion

        #region - TuesdayOfWeek : 対象日を含む週の火曜日を返す。
        /// <summary>
        /// 対象日を含む週の火曜日を返す。
        /// </summary>
        /// <param name="dt">this 日付</param>
        /// <returns>対象日を含む週の火曜日</returns>
        public static DateTime TuesdayOfWeek(this DateTime dt)
        {
            if (dt.DayOfWeek != DayOfWeek.Tuesday)
                return dt.AddDays(((int)dt.DayOfWeek - 2) * -1);
            else
                return dt;
        }
        #endregion

        #region - WednesdayOfWeek : 対象日を含む週の水曜日を返す。
        /// <summary>
        /// 対象日を含む週の水曜日を返す。
        /// </summary>
        /// <param name="dt">this 日付</param>
        /// <returns>対象日を含む週の水曜日</returns>
        public static DateTime WednesdayOfWeek(this DateTime dt)
        {
            if (dt.DayOfWeek != DayOfWeek.Wednesday)
                return dt.AddDays(((int)dt.DayOfWeek - 3) * -1);
            else
                return dt;
        }
        #endregion

        #region - ThursdayOfWeek : 対象日を含む週の木曜日を返す。
        /// <summary>
        /// 対象日を含む週の木曜日を返す。
        /// </summary>
        /// <param name="dt">this 日付</param>
        /// <returns>対象日を含む週の木曜日</returns>
        public static DateTime ThursdayOfWeek(this DateTime dt)
        {
            if (dt.DayOfWeek != DayOfWeek.Thursday)
                return dt.AddDays(((int)dt.DayOfWeek - 4) * -1);
            else
                return dt;
        }
        #endregion

        #region - FridayOfWeek : 対象日を含む週の金曜日を返す。
        /// <summary>
        /// 対象日を含む週の金曜日を返す。
        /// </summary>
        /// <param name="dt">this 日付</param>
        /// <returns>対象日を含む週の金曜日</returns>
        public static DateTime FridayOfWeek(this DateTime dt)
        {
            if (dt.DayOfWeek != DayOfWeek.Friday)
                return dt.AddDays(((int)dt.DayOfWeek - 5) * -1);
            else
                return dt;
        }
        #endregion

        #region - SaturdayOfWeek : 対象日を含む週の土曜日を返す。
        /// <summary>
        /// 対象日を含む週の土曜日を返す。
        /// </summary>
        /// <param name="dt">this 日付</param>
        /// <returns>対象日を含む週の土曜日</returns>
        public static DateTime SaturdayOfWeek(this DateTime dt)
        {
            if (dt.DayOfWeek != DayOfWeek.Saturday)
                return dt.AddDays(((int)dt.DayOfWeek - 6) * -1);
            else
                return dt;
        }
        #endregion

        #region - DropTime : 日時より時刻を落とす
        /// <summary>
        /// 日時より時刻を落とす
        /// </summary>
        /// <param name="dt">this 日時</param>
        /// <returns>対象日の0:00:00</returns>
        public static DateTime DropTime(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day);
        }
        #endregion

        #region - DropDate : 日時より日付を落とす
        /// <summary>
        /// 日時より日付を落とす
        /// </summary>
        /// <param name="dt">this 日時</param>
        /// <param name="baseDate">DateTime? : 基準日</param>
        /// <returns>対象日の時間のみ</returns>
        public static DateTime DropDate(this DateTime dt, DateTime? baseDate = null)
        {
            baseDate = baseDate ?? DateTime.MinValue;
            return new DateTime(baseDate.Value.Year, baseDate.Value.Month, baseDate.Value.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }
        #endregion

        #region - Add : 対象日に指定した単位で加算した日付を返す。
        /// <summary>
        /// 対象日に指定した単位で加算した日付を返す。
        /// </summary>
        /// <param name="dt">this 日付</param>
        /// <param name="span">加算値</param>
        /// <param name="spanUnit">加算する単位</param>
        /// <returns> 対象日に指定した単位で加算した日付</returns>
        public static DateTime Add(this DateTime dt, int span, DatePart spanUnit)
        {
            switch (spanUnit)
            {
                case DatePart.Year: return dt.AddYears(span);
                case DatePart.Month: return dt.AddMonths(span);
                case DatePart.Day: return dt.AddDays(span);
                case DatePart.Hour: return dt.AddHours(span);
                case DatePart.Minute: return dt.AddMinutes(span);
                case DatePart.Second: return dt.AddSeconds(span);
                case DatePart.Milisecond: return dt.AddMilliseconds(span);
                default: throw new ArgumentOutOfRangeException("Invalid spanUnit");
            }
        }
        #endregion

        #region - To : 対象日より指定日までの日付範囲を返す。
        /// <summary>
        /// 対象日より指定日までの日付範囲を返す。
        /// </summary>
        /// <param name="dt">this 日付</param>
        /// <param name="toDate">指定日</param>
        /// <param name="step">ステップ数</param>
        /// <param name="stepUnit"ステップ単位></param>
        /// <returns>対象日より指定日までの日付範囲</returns>
        public static DateRange To(this DateTime dt, DateTime toDate, int step = 1, DatePart stepUnit = DatePart.Day)
        {
            return new DateRange(dt, toDate, step, stepUnit);
        }
        #endregion

        #region - To : 対象日より指定した単位で加算した日付までの日付範囲を返す。
        /// <summary>
        /// 対象日より指定日までの日付範囲を返す。
        /// </summary>
        /// <param name="dt">this 日付</param>
        /// <param name="span">加算値</param>
        /// <param name="spanUnit">加算単位</param>
        /// <param name="step">ステップ数</param>
        /// <param name="stepUnit">ステップ単位</param>
        /// <returns>対象日より指定した単位で加算した日付までの日付範囲</returns>
        public static DateRange To(this DateTime dt, int span, DatePart spanUnit, int step = 1, DatePart stepUnit = DatePart.Day)
        {
            var toDate = dt.Add(span, spanUnit);
            return new DateRange(dt, toDate, step, stepUnit);
        }
        #endregion

        #endregion
    }
    #endregion
}
