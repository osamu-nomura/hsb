using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace hsb.Utilities
{
    #region 【Static Class : DateTimeUtil】
    /// <summary>
    /// 日時型関連ユーティリティ
    /// </summary>
    public static class DateTimeUtil
    {
        #region ■ Static Methods

        #region - YYYYMMDD2DateTime : YYYYMMDD形式の文字列をDateTime?に変換する
        /// <summary>
        /// YYYYMMDD形式の文字列をDateTimeに変換する
        /// </summary>
        /// <param name="s">YYYYMMDD形式の文字列</param>
        /// <returns>DateTime?</returns>
        public static DateTime? YYYYMMDD2DateTime(string s)
        {
            var match = Regex.Match(s, @"^(\d{4})(\d{2})(\d{2})$");
            if (match.Success)
            {
                return EtcUtil.SafeExecute(() =>
                {
                    return (DateTime?)new DateTime(
                        int.Parse(match.Groups[1].Value),
                        int.Parse(match.Groups[2].Value),
                        int.Parse(match.Groups[3].Value));
                }, (DateTime?)null).Value;
            }
            else
                return null;
        }
        #endregion

        #region - YYYYMMDDHHII2DateTime : YYYYMMDDHHII形式の文字列をDateTime?に変換する
        /// <summary>
        /// YYYYMMDDHHII形式の文字列をDateTimeに変換する
        /// </summary>
        /// <param name="s">YYYYMMDDHHII形式の文字列</param>
        /// <returns>DateTime?</returns>
        public static DateTime? YYYYMMDDHHII2DateTime(string s)
        {
            var match = Regex.Match(s, @"^(\d{4})(\d{2})(\d{2})(\d{2})(\d{2})$");
            if (match.Success)
            {
                return EtcUtil.SafeExecute(() =>
                {
                    return (DateTime?)new DateTime(
                        int.Parse(match.Groups[1].Value),
                        int.Parse(match.Groups[2].Value),
                        int.Parse(match.Groups[3].Value),
                        int.Parse(match.Groups[4].Value),
                        int.Parse(match.Groups[5].Value),
                        0);
                }, (DateTime?)null).Value;
            }
            else
                return null;
        }
        #endregion

        #region - YYYYMMDDHHIISS2DateTime : YYYYMMDDHHIISS形式の文字列をDateTime?に変換する
        /// <summary>
        /// YYYYMMDDHHIISS形式の文字列をDateTimeに変換する
        /// </summary>
        /// <param name="s">YYYYMMDDHHII形式の文字列</param>
        /// <returns>DateTime?</returns>
        public static DateTime? YYYYMMDDHHIISS2DateTime(string s)
        {
            var match = Regex.Match(s, @"^(\d{4})(\d{2})(\d{2})(\d{2})(\d{2})(\d{2})$");
            if (match.Success)
            {
                return EtcUtil.SafeExecute(() =>
                {
                    return (DateTime?)new DateTime(
                        int.Parse(match.Groups[1].Value),
                        int.Parse(match.Groups[2].Value),
                        int.Parse(match.Groups[3].Value),
                        int.Parse(match.Groups[4].Value),
                        int.Parse(match.Groups[5].Value),
                        int.Parse(match.Groups[6].Value));
                }, (DateTime?)null).Value;
            }
            else
                return null;
        }
        #endregion

        #region - Create : DateTimeを生成する(1)
        /// <summary>
        /// DateTimeを生成する。引数が不正の場合はNULLを返す。(1)
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <param name="hour">時</param>
        /// <param name="minute">分</param>
        /// <param name="second">秒</param>
        /// <param name="millisecond">mm秒</param>
        /// <returns>DateTime?</returns>
        public static DateTime? Create(int year, int month, int day, int hour, int minute, int second, int millisecond)
           => EtcUtil.SafeExecute(
                () => (DateTime?)new DateTime(year, month, day, hour, minute, second, millisecond),
                (DateTime?)null).Value;
        #endregion

        #region - Create : DateTimeを生成する(2)
        /// <summary>
        /// DateTimeを生成する。引数が不正の場合はNULLを返す。(2)
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <param name="hour">時</param>
        /// <param name="minute">分</param>
        /// <param name="second">秒</param>
        /// <param name="millisecond">mm秒</param>
        /// <param name="kind">種別</param>
        /// <returns>DateTime?</returns>
        public static DateTime? Create(int year, int month, int day, int hour, int minute, int second, int millisecond, DateTimeKind kind)
           => EtcUtil.SafeExecute(
                () => (DateTime?)new DateTime(year, month, day, hour, minute, second, millisecond, kind),
                (DateTime?)null).Value;
        #endregion

        #region - Create : DateTimeを生成する(3)
        /// <summary>
        /// DateTimeを生成する。引数が不正の場合はNULLを返す。(3)
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <param name="hour">時</param>
        /// <param name="minute">分</param>
        /// <param name="second">秒</param>
        /// <param name="millisecond">mm秒</param>
        /// <param name="calendar">カレンダー</param>
        /// <returns>DateTime?</returns>
        public static DateTime? Create(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar)
           => EtcUtil.SafeExecute(
                () => (DateTime?)new DateTime(year, month, day, hour, minute, second, millisecond, calendar),
                (DateTime?)null).Value;
        #endregion

        #region - Create : DateTimeを生成する(4)
        /// <summary>
        /// DateTimeを生成する。引数が不正の場合はNULLを返す。(4)
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <param name="hour">時</param>
        /// <param name="minute">分</param>
        /// <param name="second">秒</param>
        /// <param name="millisecond">mm秒</param>
        /// <param name="calendar">カレンダー</param>
        /// <param name="kind">種別</param>
        /// <returns>DateTime?</returns>
        public static DateTime? Create(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar, DateTimeKind kind)
            => EtcUtil.SafeExecute(
                () => (DateTime?)new DateTime(year, month, day, hour, minute, second, millisecond, calendar, kind),
                (DateTime?)null).Value;
        #endregion

        #region - Create : DateTimeを生成する(5)
        /// <summary>
        /// DateTimeを生成する。引数が不正の場合はNULLを返す。(1)
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <param name="hour">時</param>
        /// <param name="minute">分</param>
        /// <param name="second">秒</param>
        /// <returns>DateTime?</returns>
        public static DateTime? Create(int year, int month, int day, int hour, int minute, int second)
            => EtcUtil.SafeExecute(
                () => (DateTime?)new DateTime(year, month, day, hour, minute, second),
                (DateTime?)null).Value;
        #endregion

        #region - Create : DateTimeを生成する(6)
        /// <summary>
        /// DateTimeを生成する。引数が不正の場合はNULLを返す。(6)
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <param name="hour">時</param>
        /// <param name="minute">分</param>
        /// <param name="second">秒</param>
        /// <param name="kind">種別</param>
        /// <returns>DateTime?</returns>
        public static DateTime? Create(int year, int month, int day, int hour, int minute, int second, DateTimeKind kind)
            => EtcUtil.SafeExecute(
                () => (DateTime?)new DateTime(year, month, day, hour, minute, second, kind),
                (DateTime?)null).Value;
        #endregion

        #region - Create : DateTimeを生成する(7)
        /// <summary>
        /// DateTimeを生成する。引数が不正の場合はNULLを返す。(7)
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <param name="hour">時</param>
        /// <param name="minute">分</param>
        /// <param name="second">秒</param>
        /// <param name="calendar">カレンダー</param>
        /// <returns>DateTime?</returns>
        public static DateTime? Create(int year, int month, int day, int hour, int minute, int second, Calendar calendar)
            => EtcUtil.SafeExecute(
                () => (DateTime?)new DateTime(year, month, day, hour, minute, second, calendar), 
                (DateTime?)null).Value;
        #endregion

        #region - Create : DateTimeを生成する(8)
        /// <summary>
        /// DateTimeを生成する。引数が不正の場合はNULLを返す。(8)
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns>DateTime?</returns>
        public static DateTime? Create(int year, int month, int day)
            => EtcUtil.SafeExecute(
                () => (DateTime?)new DateTime(year, month, day), (DateTime?)null).Value;
        #endregion

        #region - Create : DateTimeを生成する(9)
        /// <summary>
        /// DateTimeを生成する。引数が不正の場合はNULLを返す。(9)
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <param name="calendar">カレンダー</param>
        /// <returns>DateTime?</returns>
        public static DateTime? Create(int year, int month, int day, Calendar calendar)
            => EtcUtil.SafeExecute(
                () => (DateTime?)new DateTime(year, month, day, calendar), (DateTime?)null).Value;
        #endregion

        #region - String2DayOfWeek : 曜日を示す文字列からDayOfWeekを返す
        /// <summary>
        /// 曜日を示す文字列からDayOfWeekを返す
        /// </summary>
        /// <param name="s">曜日を示す文字列</param>
        /// <returns>DayOfWeek?</returns>
        public static DayOfWeek? String2DayOfWeek(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                switch (s.Substring(0, 1))
                {
                    case "月": return DayOfWeek.Monday;
                    case "火": return DayOfWeek.Tuesday;
                    case "水": return DayOfWeek.Wednesday;
                    case "木": return DayOfWeek.Thursday;
                    case "金": return DayOfWeek.Friday;
                    case "土": return DayOfWeek.Saturday;
                    case "日": return DayOfWeek.Sunday;
                }
            }
            return null;
        }
        #endregion

        #endregion
    }
    #endregion
}
