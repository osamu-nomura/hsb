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

        #region - IsPrime : 値が素数
        /// <summary>
        /// 値が素数
        /// </summary>
        /// <param name="num">値</param>
        /// <returns>True : 素数 / False : 素数でない</returns>
        public static bool IsPrime(this Int16 num)
        {
            if (num == 2) return true;
            if (num < 2 || num % 2 == 0) return false;
            for (Int16 i = 3; i < num; i += 2)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
        public static bool IsPrime(this Int32 num)
        {
            if (num == 2) return true;
            if (num < 2 || num % 2 == 0) return false;
            for (Int32 i = 3; i < num; i += 2)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
        public static bool IsPrime(this Int64 num)
        {
            if (num == 2) return true;
            if (num < 2 || num % 2 == 0) return false;
            for (Int64 i = 3; i < num; i += 2)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
        public static bool IsPrime(this Decimal num)
        {
            if (num == 2) return true;
            if (num < 2 || num % 2 == 0) return false;
            for (Decimal i = 3; i < num; i += 2)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
        #endregion

        #region - UnixTimeToDateTime : 値をUnixTime値としてDateTimeを返す
        /// <summary>
        /// 値をUnixTime値としてDateTimeを返す
        /// </summary>
        /// <param name="n">this 値</param>
        /// <returns>DateTime</returns>
        public static DateTime UnixTimeToDateTime(this Int32 n) => DateTimeEx.UnixEpoch.AddSeconds(n).ToLocalTime();
        public static DateTime UnixTimeToDateTime(this UInt32 n) => DateTimeEx.UnixEpoch.AddSeconds(n).ToLocalTime();
        public static DateTime UnixTimeToDateTime(this Int64 n) => DateTimeEx.UnixEpoch.AddSeconds(n).ToLocalTime();
        #endregion
    }
    #endregion
}
