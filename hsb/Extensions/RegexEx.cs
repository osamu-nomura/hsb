using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace hsb.Extensions
{
    #region 【Static Class : RegexEx】
    /// <summary>
    /// Regex関連の拡張メソッド　
    /// </summary>
    public static class RegexEx
    {
        #region ■ Extension Methods

        #region - GetGenericEnumerator : IEnumerable<Match>を返す
        /// <summary>
        /// IEnumerator<Match>を返す
        /// </summary>
        /// <param name="matches">this MatchCollection</param>
        /// <returns>IEnumerable<Match></returns>
        public static IEnumerable<Match> GetGenericEnumerator(this MatchCollection matches)
        {
            return matches.Cast<Match>();
        }
        #endregion

        #region - ToList : MatchCollectionをMatchのリストに変換する
        /// <summary>
        /// MatchCollectionをMatchのリストに変換する
        /// </summary>
        /// <param name="matches">this MatchCollection</param>
        /// <returns>Matchのリスト</returns>
        public static List<Match> ToList(this MatchCollection matches)
        {
            return matches.GetGenericEnumerator().ToList();
        }
        #endregion

        #region - ToArray : MatchCollectionをMatchの配列に変換する
        /// <summary>
        /// MatchCollectionをMatchの配列に変換する
        /// </summary>
        /// <param name="matches">this MatchCollection</param>
        /// <returns>Matchの配列</returns>
        public static Match[] ToArray(this MatchCollection matches)
        {
            return matches.GetGenericEnumerator().ToArray();
        }
        #endregion

        #endregion
    }
    #endregion
}
