using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Utilities
{
    #region 【Static Class : EtcUtil】
    /// <summary>
    /// その他
    /// </summary>
    public static class EtcUtil
    {
        #region - LapTime : 引数で渡したアクションの実行時間を計測する
        /// <summary>
        /// 引数で渡したアクションの実行時間を計測する
        /// </summary>
        /// <param name="act">アクション</param>
        /// <returns>経過時間(TimeSpan</returns>
        public static TimeSpan LapTime(Action act)
        {
            var sw = new Stopwatch();
            sw.Start();
            try
            {
                act();
            }
            finally
            {
                sw.Stop();
            }
            return sw.Elapsed;
        }
        #endregion

        #region - SafeExecute : 例外を出さすにアクションを実行する
        /// <summary>
        /// 例外を出さすにアクションを実行する
        /// </summary>
        /// <param name="action">アクション</param>
        /// <returns>正常時：null / 例外が発生した場合：発生した例外</returns>
        public static Exception SafeExecute(Action action)
        {
            try
            {
                action?.Invoke();
                return null;
            }
            catch (Exception e)
            {
                return e;
            }
        }
        #endregion
    }
    #endregion
}
