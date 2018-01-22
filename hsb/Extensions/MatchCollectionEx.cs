using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace hsb.Extensions
{
    #region 【Static Class : MatchCollectionEx】
    /// <summary>
    /// MatchCollectionの拡張メソッド　
    /// </summary>
    public static class MatchCollectionEx
    {
        #region 【Inner Class : MatchEnumerator】
        /// <summary>
        /// MatchCollectionから、IEnumerable<Match>を生成する
        /// </summary>
        public class MatchEnumerator : IEnumerable<Match>
        {
            #region ■ Members
            /// <summary>
            /// MatchCollection
            /// </summary>
            private MatchCollection _mc;
            #endregion

            #region ■ Constructor
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="mc">MatchCollection</param>
            public MatchEnumerator(MatchCollection mc)
            {
                _mc = mc;
            }
            #endregion

            #region ■ Methods

            #region - GetEnumerator : IEnumerable.GetEnumerator の実装(Generics版)
            /// <summary>
            /// IEnumerable.GetEnumerator の実装(Generics版)
            /// </summary>
            /// <returns>IEnumerator of DateTime</returns>
            IEnumerator<Match> IEnumerable<Match>.GetEnumerator()
            {
                if (_mc != null)
                {
                    foreach (Match match in _mc)
                        yield return match;
                }
            }
            #endregion

            #region - GetEnumerator : IEnumerable.GetEnumerator の実装
            /// <summary>
            /// IEnumerable.GetEnumerator の実装
            /// </summary>
            /// <returns>IEnumerator of DateTime</returns>
            /// 
            IEnumerator IEnumerable.GetEnumerator()
            {
                if (_mc != null)
                {
                    foreach (Match match in _mc)
                        yield return match;
                }
            }
            #endregion

            #endregion
        }
        #endregion

        #region ■ Extension Methods

        #region - GetGenericEnumerator : IEnumerator<Match>を返す
        /// <summary>
        /// IEnumerator<Match>を返す
        /// </summary>
        /// <param name="matches">this MatchCollection</param>
        /// <returns>IEnumerator<Match></returns>
        public static MatchEnumerator GetGenericEnumerator(this MatchCollection matches)
        {
            return new MatchEnumerator(matches);
        }
        #endregion

        #region - ToList : MatchCollectionをMatchのリストに変換する
        /// <summary>
        /// MatchCollectionをMatchのリストに変換する
        /// </summary>
        /// <param name="matches">MatchCollection</param>
        /// <returns>Matchのリスト</returns>
        public static List<Match> ToList(this MatchCollection matches)
        {
            var list = new List<Match>();
            foreach (Match match in matches)
                list.Add(match);
            return list;
        }
        #endregion

        #endregion
    }
    #endregion
}
