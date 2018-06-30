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
        /// <returns>関数の戻り値と例外のタプル</returns>
        public static (T Value, Exception E) SafeExecute<T>(Func<T> func)
        {
            try
            {
                if (func != null)
                    return (func(), null);
                return (default(T), null);
            }
            catch (Exception e)
            {
                return (default(T), e);
            }
        }
        public static (T2 Value, Exception E) SafeExecute<T1,T2>(Func<T1,T2> func, T1 p)
        {
            try
            {
                if (func != null)
                    return (func(p), null);
                return (default(T2), null);
            }
            catch (Exception e)
            {
                return (default(T2), e);
            }
        }
        public static (T3 Value, Exception E) SafeExecute<T1, T2, T3>(Func<T1, T2, T3> func, T1 p1, T2 p2)
        {
            try
            {
                if (func != null)
                    return (func(p1, p2), null);
                return (default(T3), null);
            }
            catch (Exception e)
            {
                return (default(T3), e);
            }
        }
        #endregion

        #region - SafeEvaluate : 関数を実行し、例外が発生した場合別の関数を実行し値を返す。
        /// <summary>
        /// 関数を実行し、例外が発生した場合別の関数を実行し値を返す。
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="func">関数</param>
        /// <param name="whenException">例外発生時に呼ばれる関数</param>
        /// <returns>値</returns>
        public static T SafeEvaluate<T>(Func<T> func, Func<T> whenException)
        {
            try
            {
                return func();
            }
            catch
            {
                return whenException();
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
