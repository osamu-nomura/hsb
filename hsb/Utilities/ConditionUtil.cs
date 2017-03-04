using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Utilities
{
    #region 【Class : ConditionUtil】
    /// <summary>
    /// 条件関連ユーティリティ
    /// </summary>
    public static class ConditionUtil
    {
        #region ■ Static Methods

        #region - All : すべての引数が真である
        /// <summary>
        /// すべての引数が真である
        /// </summary>
        /// <param name="args">引数リスト</param>
        /// <returns>True : すべての引数が真である / False : 引数リストに偽が存在する</returns>
        public static bool All(params bool[] args)
        {
            return !args.Any(c => !c);
        }
        #endregion

        #region - Nothing : すべての引数が偽である
        /// <summary>
        /// すべての引数が偽である
        /// </summary>
        /// <param name="args">引数リスト</param>
        /// <returns>True : すべての引数が偽である / False : 引数リストに真が存在する</returns>
        public static bool Nothing(params bool[] args)
        {
            return !args.Any(c => c);
        }
        #endregion

        #region - Any : 引数の中の一つ以上の真が存在する
        /// <summary>
        /// 引数の中の一つ以上の真が存在する
        /// </summary>
        /// <param name="args">引数リスト</param>
        /// <returns>True : 引数リストに真が存在する / False : 引数リストに真が存在しない</returns>
        public static bool Any(params bool[] args)
        {
            return args.Any(c => c);
        }
        #endregion

        #endregion
    }
    #endregion
}
