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
            if (int.TryParse(s, out int n))
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
            if (double.TryParse(s, out double n))
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
            if (decimal.TryParse(s, out decimal n))
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
            if (DateTime.TryParse(s, out DateTime dt))
                return dt;
            else
                return null;
        }
        #endregion

        #endregion
    }
    #endregion
}
