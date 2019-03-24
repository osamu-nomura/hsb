using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public static bool IsEven(this short num) => num % 2 == 0;
        public static bool IsEven(this int num) => num % 2 == 0;
        public static bool IsEven(this long num) => num % 2 == 0;
        public static bool IsEven(this decimal num) => num % 2 == 0;
        #endregion

        #region - IsOdd : 値が奇数
        /// <summary>
        /// 値が奇数
        /// </summary>
        /// <param name="num">this 値</param>
        /// <returns>True : 奇数 / False : 偶数</returns>
        public static bool IsOdd(this short num) => num % 2 != 0;
        public static bool IsOdd(this int num) => num % 2 != 0;
        public static bool IsOdd(this long num) => num % 2 != 0;
        public static bool IsOdd(this decimal num) => num % 2 != 0;
        #endregion

        #region - IsPrime : 値が素数
        /// <summary>
        /// 値が素数
        /// </summary>
        /// <param name="num">値</param>
        /// <returns>True : 素数 / False : 素数でない</returns>
        public static bool IsPrime(this short num)
        {
            if (num == 2) return true;
            if (num < 2 || num % 2 == 0) return false;
            for (short i = 3; i < num; i += 2)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
        public static bool IsPrime(this int num)
        {
            if (num == 2) return true;
            if (num < 2 || num % 2 == 0) return false;
            for (int i = 3; i < num; i += 2)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
        public static bool IsPrime(this long num)
        {
            if (num == 2) return true;
            if (num < 2 || num % 2 == 0) return false;
            for (long i = 3; i < num; i += 2)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
        public static bool IsPrime(this decimal num)
        {
            if (num == 2) return true;
            if (num < 2 || num % 2 == 0) return false;
            for (decimal i = 3; i < num; i += 2)
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
        public static DateTime UnixTimeToDateTime(this int n) => DateTimeEx.UnixEpoch.AddSeconds(n).ToLocalTime();
        public static DateTime UnixTimeToDateTime(this uint n) => DateTimeEx.UnixEpoch.AddSeconds(n).ToLocalTime();
        public static DateTime UnixTimeToDateTime(this long n) => DateTimeEx.UnixEpoch.AddSeconds(n).ToLocalTime();
        #endregion

        #region - ToHumanReadable : 数値を人間が読みやすい書式に変換
        /// <summary>
        /// 数値を人間が読みやすい書式に変換
        /// </summary>
        /// <param name="n">this 数値</param>
        /// <param name="unit">単位の基数</param>
        /// <returns>文字列</returns>
        public static string ToHumanReadable(this double n, double unit = 1024.0d)
        {
            var units = new string[] { "", "K", "M", "T" };
            var i = 0;
            while (i < units.Length)
            {
                if (n < unit)
                    break;
                n /= unit;
                i++;
            }
            return string.Format("{0}{1}", Regex.Replace(n.ToString("#,##0.0"), @"\.0$", ""), units[i]);
        }
        public static string ToHumanReadable(this decimal n, decimal unit = 1024M)
        {
            var units = new string[] { "", "K", "M", "T" };
            var i = 0;
            while (i < units.Length)
            {
                if (n < unit)
                    break;
                n /= unit;
                i++;
            }
            return string.Format("{0}{1}", Regex.Replace(n.ToString("#,##0.0"), @"\.0$", ""), units[i]);
        }
        #endregion

        #region - RadianToDegree : 値をラジアンとして度を返す
        /// <summary>
        /// 値をラジアンとして度を返す
        /// </summary>
        /// <param name="num">this 値（ラジアン）</param>
        /// <returns>度数</returns>
        public static double RadianToDegree(this double num) => num * (180.0d / Math.PI);
        public static double RadianToDegree(this float num) => num * (180.0f / Math.PI);
        public static decimal RadianToDegree(this decimal num) => num * (180.0m / (decimal)Math.PI);
        #endregion

        #region - DegreeToRadian : 値を度としてラジアンを返す
        /// <summary>
        /// 値を度としてラジアンを返す
        /// </summary>
        /// <param name="num">this 値（度）</param>
        /// <returns>ラジアン</returns>
        public static double DegreeToRadian(this double num) => num * (Math.PI / 180.0d);
        public static double DegreeToRadian(this float num) => num * (Math.PI / 180.0d);
        public static decimal DegreeToRadian(this decimal num) => num * ((decimal)Math.PI / 180.0m);
        #endregion

        #region - Ceiling : 最小の整数値を返す
        /// <summary>
        /// 最小の整数値を返す
        /// </summary>
        /// <param name="num">this 値</param>
        /// <returns>整数値</returns>
        public static double Ceiling(this double num) => Math.Ceiling(num);
        public static double Ceiling(this float num) => Math.Ceiling(num);
        #endregion

        #region - Floor : 最大の整数値を返す
        /// <summary>
        /// 最大の整数値を返す
        /// </summary>
        /// <param name="num">this 値</param>
        /// <returns>整数値</returns>
        public static double Floor(this double num) => Math.Floor(num);
        public static double Floor(this float num) => Math.Floor(num);
        #endregion

        #region - Round : 指定した小数点の桁数に丸める
        /// <summary>
        /// 指定した小数点の桁数に丸める
        /// </summary>
        /// <param name="num">this 値</param>
        /// <param name="decimals">桁数</param>
        /// <returns>丸めた数値</returns>
        public static double Round(this double num, int decimals = 0) => Math.Round(num, decimals);
        public static double Round(this float num, int decimals = 0) => Math.Round(num, decimals);
        #endregion

        #region - Digits : 整数値を桁毎に列挙する
        /// <summary>
        /// 整数値を桁毎に列挙する
        /// </summary>
        /// <param name="n">this n 値</param>
        /// <returns>IEnumerable</returns>
        public static IEnumerable<int> Digits(this short n)
            => Math.Abs(n).ToString().Select(c => c - '0');
        public static IEnumerable<int> Digits(this int n)
            => Math.Abs(n).ToString().Select(c => c - '0');
        public static IEnumerable<int> Digits(this long n)
            => Math.Abs(n).ToString().Select(c => c - '0');
        #endregion
    }
    #endregion
}
