using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Net.Mail;
using hsb.Utilities;

namespace hsb.Extensions
{
    #region 【Static Class : StringEx】
    /// <summary>
    /// 文字列拡張メソッド
    /// </summary>
    public static class StringEx
    {
        #region ■ Extension Methods

        #region - ToInt : 例外を発生させずに文字列を整数に変換する
        /// <summary>
        /// 例外を発生させずに文字列を整数に変換する
        /// 変換できなかった場合はNULLを返す。
        /// </summary>
        /// <param name="s">this 文字列</param>
        /// <returns>int?</returns>
        public static int? ToInt(this string s)
            => int.TryParse(s, out int n) ? (int?)n : null;
        #endregion

        #region - ToDouble : 例外を発生させずに文字列を実数に変換する
        /// <summary>
        /// 例外を発生させずに文字列を実数に変換する
        /// 変換できなかった場合はNULLを返す。
        /// </summary>
        /// <param name="s">this 文字列</param>
        /// <returns>double?</returns>
        public static double? ToDouble(this string s)
            => double.TryParse(s, out double n) ? (double?)n : null;
        #endregion

        #region - ToDecimal : 例外を発生させずに文字列をデシマルに変換する
        /// <summary>
        /// 例外を発生させずに文字列をデシマルに変換する
        /// 変換できなかった場合はNULLを返す。
        /// </summary>
        /// <param name="s">this 文字列</param>
        /// <returns>decimal?</returns>
        public static decimal? ToDecimal(this string s)
            => decimal.TryParse(s, out decimal n) ? (decimal?)n : null;
        #endregion

        #region - ToDateTime : 例外を発生させずに文字列を日時型に変換する
        /// <summary>
        /// 例外を発生させずに文字列を日時型に変換する
        /// 変換できなかった場合はNULLを返す。
        /// </summary>
        /// <param name="s">this 文字列</param>
        /// <returns>DateTime?</returns>
        public static DateTime? ToDateTime(this string s)
            => DateTime.TryParse(s, out DateTime dt) ? (DateTime?)dt : null;
        #endregion

        #region - IsValidMailAddress : 文字列がメールアドレスとしての正しいかどうかチェックする
        /// <summary>
        /// 文字列がメールアドレスとしての正しいかどうかチェックする
        /// </summary>
        /// <param name="s">this 文字列</param>
        /// <returns>bool</returns>
        public static bool IsValidMailAddress(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;
            return EtcUtil.SafeExecute(() => { new MailAddress(s); }) == null;
        }
        #endregion

        #region - TextElements : 文字列を文字単位（サロゲートペア等を考慮して）で列挙する
        /// <summary>
        /// 文字列を文字単位（サロゲートペア等を考慮して）で列挙する
        /// </summary>
        /// <param name="s">this 文字列</param>
        /// <returns>1文字毎の列挙</returns>
        public static IEnumerable<string> TextElements(this string s)
        {
            var tee = StringInfo.GetTextElementEnumerator(s);
            tee.Reset();
            while (tee.MoveNext())
            {
                yield return tee.GetTextElement();
            }
        }
        #endregion

        #region - Translate : 文字列中の指定文字列を置き換える
        /// <summary>
        /// 文字列中の指定文字列を置き換える
        /// </summary>
        /// <param name="s">this 文字列</param>
        /// <param name="inTable">置換対象となる文字のリスト</param>
        /// <param name="outTable">置換する文字のリスト</param>
        /// <returns>置換後の文字列</returns>
        public static string Translate(this string s, IList<string> inTable, IList<string> outTable = null)
        {
            if (string.IsNullOrEmpty(s) || (inTable?.Count ?? 0) == 0)
                return s;

            for (var i = 0; i < inTable.Count; i++)
            {
                var newValue = (outTable?.Count ?? 0) > i ? outTable[i] : "";
                s = s.Replace(inTable[i], newValue);
            }
            return s;
        }
        #endregion

        #region - Translate : 文字列中の指定文字列を置き換える
        /// <summary>
        /// 文字列中の指定文字列を置き換える
        /// </summary>
        /// <param name="s">this 文字列</param>
        /// <param name="inStr">置換対象となる文字を並べた文字列</param>
        /// <param name="outStr">置換する文字を並べた文字列</param>
        /// <returns>置換後の文字列</returns>
        public static string Translate(this string s, string inStr, string outStr = null)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(inStr))
                return s;
            return Translate(s, inStr.TextElements().ToList(), outStr?.TextElements().ToList());
        }
        #endregion

        #region - ReplaceCrLf : 文字列中の改行コードを置換する
        /// <summary>
        /// 文字列中の改行コードを置換する
        /// </summary>
        /// <param name="s">this 文字列</param>
        /// <param name="replaceString">改行コードと置換する文字列</param>
        /// <returns>置換後の文字列</returns>
        public static string ReplaceCrLf(this string s, string replaceString = null)
        {
            if (string.IsNullOrEmpty(s))
                return s;
            return s.Replace("\r\n", replaceString)
                    .Replace("\r", replaceString)
                    .Replace("\n", replaceString);
        }
        #endregion

        #endregion
    }
    #endregion
}
