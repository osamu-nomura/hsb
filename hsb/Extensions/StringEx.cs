using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Net.Mail;
using System.Text;
using hsb.Utilities;

using static hsb.Utilities.Constants;

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

        #region - MD5 : 文字列のMD5ダイジェスト値を取得する。
        /// <summary>
        /// 文字列のMD5ダイジェスト値を取得する。
        /// </summary>
        /// <param name="s">this 文字列</param>
        /// <param name="enc">エンコーディング</param>
        /// <returns>MD5ダイジェスト値</returns>
        public static string MD5(this string s, Encoding enc = null)
        {
            return Utilities.MD5.CreateDigest(s, enc);
        }
        #endregion

        #region - SHA1 : 文字列のSHA1ダイジェスト値を取得する。
        /// <summary>
        /// 文字列のSHA1ダイジェスト値を取得する。
        /// </summary>
        /// <param name="s">this 文字列</param>
        /// <param name="enc">エンコーディング</param>
        /// <returns>MD5ダイジェスト値</returns>
        public static string SHA1(this string s, Encoding enc = null)
        {
            return Utilities.SHA1.CreateDigest(s, enc);
        }
        #endregion

        #region - SHA256 : 文字列のSHA256ダイジェスト値を取得する。
        /// <summary>
        /// 文字列のSHA256ダイジェスト値を取得する。
        /// </summary>
        /// <param name="s">this 文字列</param>
        /// <param name="enc">エンコーディング</param>
        /// <returns>MD5ダイジェスト値</returns>
        public static string SHA256(this string s, Encoding enc = null)
        {
            return Utilities.SHA256.CreateDigest(s, enc);
        }
        #endregion

        #region - Omission : 文字列を指定桁数で省略する
        /// <summary>
        /// 文字列を指定桁数で省略する
        /// </summary>
        /// <param name="s">this : 文字列</param>
        /// <param name="length">長さ</param>
        /// <param name="safix">省略記号</param>
        /// <returns>省略された文字列</returns>
        public static string Omission(this string s, int length, string safix = "…")
            => s.Length > length ? string.Format("{0}{1}", s.Substring(0, length - (safix?.Length ?? 0)), safix) : s;
        #endregion

        #region - ToBase64String : 文字列をBASE64でエンコードする
        /// <summary>
        /// 文字列をBASE64でエンコードする
        /// </summary>
        /// <param name="s">this : 文字列</param>
        /// <returns>BASE64にエンコードした文字列</returns>
        public static string ToBase64String(this string s)
            => string.IsNullOrEmpty(s) ? s : Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
        #endregion

        #region - ToBase64UrlString : 文字列をBASE64URLでエンコードする
        /// <summary>
        /// 文字列をBASE64URLでエンコードする
        /// </summary>
        /// <param name="s">this : 文字列</param>
        /// <returns>BASE64URLにエンコードした文字列</returns>
        public static string ToBase64UrlString(this string s)
            => string.IsNullOrEmpty(s) ? s : s.ToBase64String().TrimEnd('=').Replace('+', '-').Replace('/', '_');
        #endregion

        #region - DecodeBase64String : BASE64でエンコードされた文字列をデコードする
        /// <summary>
        /// BASE64でエンコードされた文字列をデコードする
        /// </summary>
        /// <param name="s">this : 文字列</param>
        /// <returns>バイト配列</returns>
        public static byte[] DecodeBase64String(this string s)
            => EtcUtil.SafeExecute(() => Convert.FromBase64String(s), (byte[])null).Value;
        #endregion

        #region - DecodeBase64UrlString : BASE64URLでエンコードされた文字列をデコードする
        /// <summary>
        /// BASE64URLでエンコードされた文字列をデコードする
        /// </summary>
        /// <param name="s">this: 文字列</param>
        /// <returns>バイト配列</returns>
        public static byte[] DecodeBase64UrlString(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;
            var padding = new string('=', (s.Length % 4 != 0) ? 4 - (s.Length % 4) : 0);
            return (s + padding).Replace('_', '/').Replace('-', '+').DecodeBase64String();
        }
        #endregion

        #region - ToZenkakuKatakana : 半角カタカナを全角カタカナに変換する
        /// <summary>
        /// 半角カタカナを全角カタカナに変換する
        /// </summary>
        /// <param name="s">this : 文字列</param>
        /// <returns>半角カタカナが全角カタカナに変換された文字列</returns>
        public static string ToZenkakuKatakana(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;
            foreach(var (hankaku, zenkaku) in HANKAKU_ZENKAKU_KANA_CHARS)
            {
                s = s.Replace(hankaku, zenkaku);
            }
            return s;
        }
        #endregion

        #region - ToHankakuAlphaNum : 全角英数を半角に変換する
        /// <summary>
        /// 全角英数を半角に変換する
        /// ※記号はそのまま
        /// </summary>
        /// <param name="s">this : 文字列</param>
        /// <returns>全角英数が半角に変換された文字列</returns>
        public static string ToHankakuAlphaNum(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;
            return System.Text.RegularExpressions.Regex.Replace(s, @"[Ａ-Ｚａ-ｚ０-９]",
                m => ((char)(m.Value[0] - 0xFEE0)).ToString());
        }
        #endregion

        #region - ToHankakuAlphaNumSymbol : 全角英数記号を半角に変換する
        /// <summary>
        /// 全角英数記号を半角に変換する
        /// </summary>
        /// <param name="s">this : 文字列</param>
        /// <returns>全角英数記号を半角に変換した文字列</returns>
        public static string ToHankakuAlphaNumSymbol(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;
            return System.Text.RegularExpressions.Regex.Replace(s, @"[！-～]",
                m => ((char)(m.Value[0] - 0xFEE0)).ToString())
                .Replace("”", "\"").Replace("’", "'").Replace("￥", "\\")
                .Replace("　", " ");
        }
        #endregion

        #endregion
    }
    #endregion
}
