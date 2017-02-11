using System;
using System.Runtime.InteropServices;
using System.Globalization;

using hsb.Types;

namespace hsb.Extensions
{
    #region 【Static Class : StringEx】
    /// <summary>
    /// 文字列拡張メソッド
    /// </summary>
    public static class StringEx
    {
        #region ■ DLL Import ■

        #region - LCMapStringW
        /// <summary>
        /// LCMapStringW
        /// </summary>
        /// <param name="Locale">int</param>
        /// <param name="dwMapFlags">uint</param>
        /// <param name="lpSrcStr">string</param>
        /// <param name="cchSrc">int</param>
        /// <param name="lpDestStr">string</param>
        /// <param name="cchDest">int</param>
        /// <returns>int</returns>
        [DllImport("kernel32.dll")]
        static extern int LCMapStringW(int Locale, uint dwMapFlags,
            [MarshalAs(UnmanagedType.LPWStr)]string lpSrcStr, int cchSrc,
            [MarshalAs(UnmanagedType.LPWStr)] string lpDestStr, int cchDest);
        #endregion

        #endregion

        #region ■ Extension Methods

        #region - ToInt : 例外を発生させずに文字列を整数に変換する
        /// <summary>
        /// 例外を発生させずに文字列を整数に変換する
        /// 変換できなかった場合はNULLを返す。
        /// </summary>
        /// <param name="s">this 文字列</param>
        /// <returns>int?</returns>
        public static int? ToInt(this string s)
        {
            var n = 0;
            if (int.TryParse(s, out n))
                return n;
            else
                return null;
        }
        #endregion

        #region - ToDouble : 例外を発生させずに文字列を実数に変換する
        /// <summary>
        /// 例外を発生させずに文字列を実数に変換する
        /// 変換できなかった場合はNULLを返す。
        /// </summary>
        /// <param name="s">this 文字列</param>
        /// <returns>double?</returns>
        public static double? ToDouble(this string s)
        {
            var n = 0.0d;
            if (double.TryParse(s, out n))
                return n;
            else
                return null;
        }
        #endregion

        #region - ToDecimal : 例外を発生させずに文字列をデシマルに変換する
        /// <summary>
        /// 例外を発生させずに文字列をデシマルに変換する
        /// 変換できなかった場合はNULLを返す。
        /// </summary>
        /// <param name="s">this 文字列</param>
        /// <returns>decimal?</returns>
        public static decimal? ToDecimal(this string s)
        {
            decimal n = 0m;
            if (decimal.TryParse(s, out n))
                return n;
            else
                return null;
        }
        #endregion

        #region - ToDateTime : 例外を発生させずに文字列を日時型に変換する
        /// <summary>
        /// 例外を発生させずに文字列を日時型に変換する
        /// 変換できなかった場合はNULLを返す。
        /// </summary>
        /// <param name="s">this 文字列</param>
        /// <returns>DateTime?</returns>
        public static DateTime? ToDateTime(this string s)
        {
            DateTime dt;
            if (DateTime.TryParse(s, out dt))
                return dt;
            else
                return null;
        }
        #endregion

        #region - MapString : 文字列を変換する（LCMapStringWのラッパー)
        /// <summary>
        ///  文字列を変換する（LCMapStringWのラッパー)
        /// </summary>
        /// <param name="s">this 文字列</param>
        /// <param name="flags">変換条件</param>
        /// <returns>変換された文字列</returns>
        public static string MapString(this string s, MapStringFlags flags)
        {
            var ci = CultureInfo.CurrentCulture;
            var result = new string(' ', s.Length);
            LCMapStringW(ci.LCID, (uint)flags, s, s.Length, result, result.Length);
            return result;
        }
        #endregion

        #region - ToFullWidth : 半角文字列を全角にする
        /// <summary>
        /// 半角文字列を全角にする
        /// </summary>
        /// <param name="s">this 文字列</param>
        /// <returns>全角文字列</returns>
        public static string ToFullWidth(this string s)
        {
            return MapString(s, MapStringFlags.LCMAP_FULLWIDTH | MapStringFlags.LCMAP_KATAKANA);
        }
        #endregion

        #region- ToHalfWidth : 全角文字列を半角にする
        /// <summary>
        /// 全角文字列を半角にする
        /// </summary>
        /// <param name="s">this 文字列</param>
        /// <returns>半角文字列</returns>
        public static string ToHalfWidth(this string s)
        {
            return MapString(s, MapStringFlags.LCMAP_HALFWIDTH);
        }
        #endregion

        #endregion
    }
    #endregion
}
