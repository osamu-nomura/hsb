using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Extensions
{
    #region 【Static Class : DictionaryEx】
    /// <summary>
    /// Dictionayの拡張メソッド
    /// </summary>
    public static class DictionaryEx
    {
        #region ■ Extension Methods

        #region - Get : 辞書より値を取得する(1)
        /// <summary>
        /// 辞書より値を取得する（キーが存在しなければデフォルト値を返す）
        /// </summary>
        /// <typeparam name="T1">型パラメータ</typeparam>
        /// <typeparam name="T2">型パラメータ</typeparam>
        /// <param name="dict">this 辞書</param>
        /// <param name="key">キー</param>
        /// <param name="defaultValue">デフォルト値</param>
        /// <returns>辞書の値</returns>
        public static T2 Get<T1, T2>(this Dictionary<T1, T2> dict, T1 key, T2 defaultValue)
            => (dict.ContainsKey(key)) ? dict[key] : defaultValue;
        #endregion

        #region - Get : 辞書より値を取得する(2)
        /// <summary>
        /// 辞書より値を取得する（キーが存在しなければデフォルト値を返す）
        /// </summary>
        /// <typeparam name="T1">型パラメータ</typeparam>
        /// <typeparam name="T2">型パラメータ</typeparam>
        /// <param name="dict">this 辞書</param>
        /// <param name="key">キー</param>
        /// <param name="generator">キーが存在しない場合に呼ばれるコールバック</param>
        /// <returns>辞書の値</returns>
        public static T2 Get<T1, T2>(this Dictionary<T1, T2> dict, T1 key, Func<T2> generator)
            => (dict.ContainsKey(key)) ? dict[key] : generator();
        #endregion

        #region - GetOrAdd : キーが存在すれば値を返し、存在しなければ追加して返す
        /// <summary>
        /// キーが存在すれば値を返し、存在しなければ追加して返す
        /// </summary>
        /// <typeparam name="T1">型パラメータ</typeparam>
        /// <typeparam name="T2">型パラメータ</typeparam>
        /// <param name="dict">this 辞書</param>
        /// <param name="key">キー</param>
        /// <param name="generator">キーが存在しない場合に呼ばれるコールバック</param>
        /// <returns>価</returns>
        public static T2 GetOrAdd<T1,T2>(this Dictionary<T1,T2> dict, T1 key, Func<T2> generator)
        {
            if (!dict.ContainsKey(key))
                dict.Add(key, generator());
            return dict[key];
        }
        #endregion

        #endregion
    }
    #endregion
}
