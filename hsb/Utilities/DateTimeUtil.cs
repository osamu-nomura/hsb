﻿using System;
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
        {
            try
            {
                return new DateTime(year, month, day, hour, minute, second, millisecond);
            }
            catch
            {
                return null;
            }
        }
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
        {
            try
            {
                return new DateTime(year, month, day, hour, minute, second, millisecond, kind);
            }
            catch
            {
                return null;
            }
        }
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
        {
            try
            {
                return new DateTime(year, month, day, hour, minute, second, millisecond, calendar);
            }
            catch
            {
                return null;
            }
        }
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
        {
            try
            {
                return new DateTime(year, month, day, hour, minute, second, millisecond, calendar, kind);
            }
            catch
            {
                return null;
            }
        }
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
        {
            try
            {
                return new DateTime(year, month, day, hour, minute, second);
            }
            catch
            {
                return null;
            }
        }
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
        {
            try
            {
                return new DateTime(year, month, day, hour, minute, second, kind);
            }
            catch
            {
                return null;
            }
        }
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
        {
            try
            {
                return new DateTime(year, month, day, hour, minute, second, calendar);
            }
            catch
            {
                return null;
            }
        }
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
        {
            try
            {
                return new DateTime(year, month, day);
            }
            catch
            {
                return null;
            }
        }
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
        {
            try
            {
                return new DateTime(year, month, day, calendar);
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #endregion
    }
    #endregion
}
