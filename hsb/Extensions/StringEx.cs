using System;
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
            return ConditionUtil.SafeExecute(() => { new MailAddress(s); }) == null;
        }
        #endregion

        #endregion
    }
    #endregion
}
