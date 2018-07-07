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

        #region - SafeExecute : 例外を出さずに関数を実行する
        /// <summary>
        /// 例外を出さずに関数を実行する
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="func">関数</param>
        /// <param name="whenException">例外が発生した場合の代替値</param>
        /// <returns>関数の戻り値と例外のタプル</returns>
        public static (T Value, Exception E) SafeExecute<T>(Func<T> func, T whenException)
        {
            try
            {
                if (func != null)
                    return (func(), null);
                return (whenException, null);
            }
            catch (Exception e)
            {
                return (whenException, e);
            }
        }
        public static (T Value, Exception E) SafeExecute<T>(Func<T> func, Func<T> whenException = null)
        {
            try
            {
                if (func != null)
                    return (func(), null);
                return (whenException != null) ? (whenException(), (Exception)null) : (default(T), (Exception)null);
            }
            catch (Exception e)
            {
                return (whenException != null) ? (whenException(), e) : (default(T), e);
            }
        }
        public static (T2 Value, Exception E) SafeExecute<T1,T2>(Func<T1,T2> func, T1 p, T2 whenException)
        {
            try
            {
                if (func != null)
                    return (func(p), null);
                return (whenException, null);
            }
            catch (Exception e)
            {
                return (whenException, e);
            }
        }
        public static (T2 Value, Exception E) SafeExecute<T1, T2>(Func<T1, T2> func, T1 p, Func<T2> whenException = null)
        {
            try
            {
                if (func != null)
                    return (func(p), null);
                return (whenException != null) ? (whenException(), (Exception)null) : (default(T2), (Exception)null);
            }
            catch (Exception e)
            {
                return (whenException != null) ? (whenException(), e) : (default(T2), e);
            }
        }
        public static (T3 Value, Exception E) SafeExecute<T1, T2, T3>(Func<T1, T2, T3> func, T1 p1, T2 p2, T3 whenException)
        {
            try
            {
                if (func != null)
                    return (func(p1, p2), null);
                return (whenException, null);
            }
            catch (Exception e)
            {
                return (whenException, e);
            }
        }
        public static (T3 Value, Exception E) SafeExecute<T1, T2, T3>(Func<T1, T2, T3> func, T1 p1, T2 p2, Func<T3> whenException = null)
        {
            try
            {
                if (func != null)
                    return (func(p1, p2), null);
                return (whenException != null) ? (whenException(), (Exception)null) : (default(T3), (Exception)null);
            }
            catch (Exception e)
            {
                return (whenException != null) ? (whenException(), e) : (default(T3), e);
            }
        }
        #endregion
    }
    #endregion
}
