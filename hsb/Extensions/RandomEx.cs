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
            => r.Next(1) == 0;
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

        #endregion
    }
    #endregion
}
