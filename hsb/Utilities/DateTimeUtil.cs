using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #endregion
    }
    #endregion
}
