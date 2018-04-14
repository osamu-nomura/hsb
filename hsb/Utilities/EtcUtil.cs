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

        #region - ValueIf : 値1を条件式で評価し、真の場合は値1でなければ値2を返す。
        /// <summary>
        /// 値1を条件式で評価し、真の場合は値1でなければ値2を返す。
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="value">値1</param>
        /// <param name="conditon">条件式</param>
        /// <param name="elseValue">値2</param>
        /// <returns>値</returns>
        public static T ValueIf<T>(T value, Func<T, bool>conditon, T elseValue)
        {
            return conditon(value) ? value : elseValue;
        }
        #endregion
    }
    #endregion
}
