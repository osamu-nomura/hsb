using System;
using System.Collections.Generic;
using System.Linq;

namespace hsb.Classes
{
    #region 【Class : Probability】
    /// <summary>
    /// 確率クラス
    /// </summary>
    public class Probability<T>
    {
        #region ■ Members

        #region - _r : 乱数発生器
        /// <summary>
        /// 乱数発生器
        /// </summary>
        private Random _r = new Random();
        #endregion

        #endregion

        #region ■ Properties

        #region - Probabilities : 確率リスト
        /// <summary>
        /// 確率リスト
        /// </summary>
        public List<(T item, int ratio)> Probabilities { get; set; }
        #endregion

        #region - Sum : 確率合計
        /// <summary>
        /// 確率合計
        /// </summary>
        public int Sum
        {
            get => Probabilities.Sum(t => t.ratio);
        }
        #endregion

        #endregion

        #region ■ Constructor

        #region - Constructor(1)
        /// <summary>
        /// コンストラクタ(1)
        /// </summary>
        public Probability()
        {
        }
        #endregion

        #region - Constructor(2)
        /// <summary>
        /// コンストラクタ(2)
        /// </summary>
        /// <param name="probabilities">確率リスト</param>
        public Probability(IEnumerable<(T item, int ratio)> probabilities) : this()
        {
            Probabilities = new List<(T item, int ratio)>(probabilities);
        }
        #endregion

        #endregion

        #region ■ Methods

        #region - Next : 次の値を取得する
        /// <summary>
        /// 次の値を取得する
        /// </summary>
        /// <returns>確率に応じた値</returns>
        public T Next()
        {
            var n = _r.Next(Sum);
            foreach(var t in Probabilities)
            {
                if (n < t.ratio)
                    return t.item;
                n -= t.ratio;
            }
            return Probabilities.FirstOrDefault().item;
        }
        #endregion

        #endregion
    }
    #endregion
}
