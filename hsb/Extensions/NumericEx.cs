using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Extensions
{
    #region 【Static Class : NumericEx】
    /// <summary>
    /// 数値型拡張メソッド
    /// </summary>
    public static class NumericEx
    {
        #region - IsEven : 値が偶数
        /// <summary>
        ///  値が偶数
        /// </summary>
        /// <param name="num">this 値</param>
        /// <returns>True : 偶数 / False : 奇数</returns>
        public static bool IsEven(this Int16 num) => num % 2 == 0;
        public static bool IsEven(this Int32 num) => num % 2 == 0;
        public static bool IsEven(this Int64 num) => num % 2 == 0;
        public static bool IsEven(this decimal num) => num % 2 == 0;
        #endregion

        #region - IsOdd : 値が奇数
        /// <summary>
        /// 値が奇数
        /// </summary>
        /// <param name="num">this 値</param>
        /// <returns>True : 奇数 / False : 偶数</returns>
        public static bool IsOdd(this Int16 num) => num % 2 != 0;
        public static bool IsOdd(this Int32 num) => num % 2 != 0;
        public static bool IsOdd(this Int64 num) => num % 2 != 0;
        public static bool IsOdd(this decimal num) => num % 2 != 0;
        #endregion

        #region - UnitTimeToDateTime : 値をUnixTime値としてDateTimeを返す
        /// <summary>
        /// 値をUnixTime値としてDateTimeを返す
        /// </summary>
        /// <param name="n">this 値</param>
        /// <returns>DateTime</returns>
        public static DateTime UnitTimeToDateTime(this Int32 n) => DateTimeEx.UnixEpoch.AddSeconds(n).ToLocalTime();
        public static DateTime UnitTimeToDateTime(this UInt32 n) => DateTimeEx.UnixEpoch.AddSeconds(n).ToLocalTime();
        public static DateTime UnitTimeToDateTime(this Int64 n) => DateTimeEx.UnixEpoch.AddSeconds(n).ToLocalTime();
        #endregion
    }
    #endregion
}
