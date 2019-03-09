using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Extensions
{
    #region 【Static Class : RandomEx】
    /// <summary>
    /// Randomクラスの拡張メソッド
    /// </summary>
    public static class RandomEx
    {
        #region ■ Extension Methods

        #region - NextBool : ランダムな真偽値を返す
        /// <summary>
        /// ランダムな真偽値を返す
        /// </summary>
        /// <param name="r">this Randomオブジェクト</param>
        /// <returns>ランダムな真偽値</returns>
        public static bool NextBool(this Random r)
            => r.Next(2) == 0;
        #endregion

        #region - NextBool : 指定の確率で真を返す
        /// <summary>
        /// 指定の確率で真を返す
        /// </summary>
        /// <param name="r"></param>
        /// <param name="probability">確率(パーセント)</param>
        /// <returns>指定した確率で真を返す真偽値</returns>
        public static bool NextBool(this Random r, int probability)
            => r.Next(100) < probability;
        #endregion

        #region - Sequence : ランダムな値を列挙する
        /// <summary>
        /// ランダムな値を列挙する
        /// </summary>
        /// <param name="r">this Randomオブジェクト</param>
        /// <param name="minValue">最小値</param>
        /// <param name="maxValue">最大値</param>
        /// <param name="count">生成件数(nullなら無限)</param>
        /// <returns>乱数値の列挙</returns>
        public static IEnumerable<int> Sequence(this Random r, int minValue, int maxValue, int? count = null)
        {
            var i = 0;
            while (count == null || i < count)
            {
                yield return r.Next(minValue, maxValue);
                i++;
            }
        }
        #endregion

        #region - SequenceDouble : ランダムなDouble値を列挙する
        /// <summary>
        /// ランダムなDouble値を列挙する
        /// </summary>
        /// <param name="r">this Randomオブジェクト</param>
        /// <param name="count">生成件数(nullなら無限）</param>
        /// <returns>乱数値の列挙</returns>
        public static IEnumerable<double> SequenceDouble(this Random r, int? count = null)
        {
            var i = 0;
            while (count == null || i < count)
            {
                yield return r.NextDouble();
                i++;
            }
        }
        #endregion

        #region - Next2 : ランダムな整数を要素2個のタプルで返す
        /// <summary>
        /// ランダムな整数を要素2個のタプルで返す
        /// </summary>
        /// <param name="r">this Randomオブジェクト</param>
        /// <returns>乱数値のタプル</returns>
        public static (int, int) Next2(this Random r)
            => (r.Next(), r.Next());
        /// <summary>
        /// ランダムな整数を要素2個のタプルで返す
        /// </summary>
        /// <param name="r">this Randomオブジェクト</param>
        /// <param name="maxValue">最大値</param>
        /// <returns>乱数値のタプル</returns>
        public static (int, int) Next2(this Random r, int maxValue)
            => (r.Next(maxValue), r.Next(maxValue));
        /// <summary>
        /// ランダムな整数を要素2個のタプルで返す
        /// </summary>
        /// <param name="r">this Randomオブジェクト</param>
        /// <param name="minValue">最小値</param>
        /// <param name="maxValue">最大値</param>
        /// <returns>乱数値のタプル</returns>
        public static (int, int) Next2(this Random r, int minValue, int maxValue)
            => (r.Next(minValue, maxValue), r.Next(minValue, maxValue));
        #endregion

        #region - Next3 : ランダムな整数を要素3個のタプルで返す
        /// <summary>
        /// ランダムな整数を要素3個のタプルで返す
        /// </summary>
        /// <param name="r">this Randomオブジェクト</param>
        /// <returns>乱数値のタプル</returns>
        public static (int, int, int) Next3(this Random r)
            => (r.Next(), r.Next(), r.Next());
        /// <summary>
        /// ランダムな整数を要素3個のタプルで返す
        /// </summary>
        /// <param name="r">this Randomオブジェクト</param>
        /// <param name="maxValue">最大値</param>
        /// <returns>乱数値のタプル</returns>
        public static (int, int, int) Next3(this Random r, int maxValue)
            => (r.Next(maxValue), r.Next(maxValue), r.Next(maxValue));
        /// <summary>
        /// ランダムな整数を要素3個のタプルで返す
        /// </summary>
        /// <param name="r">this Randomオブジェクト</param>
        /// <param name="minValue">最小値</param>
        /// <param name="maxValue">最大値</param>
        /// <returns>乱数値のタプル</returns>
        public static (int, int, int) Next3(this Random r, int minValue, int maxValue)
            => (r.Next(minValue, maxValue), r.Next(minValue, maxValue), r.Next(minValue, maxValue));
        #endregion

        #region - Next4 : ランダムな整数を要素4個のタプルで返す
        /// <summary>
        /// ランダムな整数を要素4個のタプルで返す
        /// </summary>
        /// <param name="r">this Randomオブジェクト</param>
        /// <returns>乱数値のタプル</returns>
        public static (int, int, int, int) Next4(this Random r)
            => (r.Next(), r.Next(), r.Next(), r.Next());
        /// <summary>
        /// ランダムな整数を要素4個のタプルで返す
        /// </summary>
        /// <param name="r">this Randomオブジェクト</param>
        /// <param name="maxValue">最大値</param>
        /// <returns>乱数値のタプル</returns>
        public static (int, int, int, int) Next4(this Random r, int maxValue)
            => (r.Next(maxValue), r.Next(maxValue), r.Next(maxValue), r.Next(maxValue));
        /// <summary>
        /// ランダムな整数を要素4個のタプルで返す
        /// </summary>
        /// <param name="r">this Randomオブジェクト</param>
        /// <param name="minValue">最小値</param>
        /// <param name="maxValue">最大値</param>
        /// <returns>乱数値のタプル</returns>
        public static (int, int, int, int) Next4(this Random r, int minValue, int maxValue)
            => (r.Next(minValue, maxValue), r.Next(minValue, maxValue), r.Next(minValue, maxValue), r.Next(minValue, maxValue));
        #endregion

        #region - Next5 : ランダムな整数を要素5個のタプルで返す
        /// <summary>
        /// ランダムな整数を要素5個のタプルで返す
        /// </summary>
        /// <param name="r">this Randomオブジェクト</param>
        /// <returns>乱数値のタプル</returns>
        public static (int, int, int, int, int) Next5(this Random r)
            => (r.Next(), r.Next(), r.Next(), r.Next(), r.Next());
        /// <summary>
        /// ランダムな整数を要素5個のタプルで返す
        /// </summary>
        /// <param name="r">this Randomオブジェクト</param>
        /// <param name="maxValue">最大値</param>
        /// <returns>乱数値のタプル</returns>
        public static (int, int, int, int, int) Next5(this Random r, int maxValue)
            => (r.Next(maxValue), r.Next(maxValue), r.Next(maxValue), r.Next(maxValue), r.Next(maxValue));
        /// <summary>
        /// ランダムな整数を要素5個のタプルで返す
        /// </summary>
        /// <param name="r">this Randomオブジェクト</param>
        /// <param name="minValue">最小値</param>
        /// <param name="maxValue">最大値</param>
        /// <returns>乱数値のタプル</returns>
        public static (int, int, int, int, int) Next5(this Random r, int minValue, int maxValue)
            => (r.Next(minValue, maxValue), r.Next(minValue, maxValue), r.Next(minValue, maxValue),
                r.Next(minValue, maxValue), r.Next(minValue, maxValue));
        #endregion

        #endregion
    }
    #endregion
}
