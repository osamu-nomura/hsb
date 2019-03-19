using System;
using System.Collections.Generic;

namespace hsb.Extensions
{
    #region 【Static Class : TypeEx】
    /// <summary>
    /// Typeの拡張メソッド
    /// </summary>
    public static class TypeEx
    {
        #region ■ Extension Methods

        #region - IsList : Listか?
        /// <summary>
        /// Listか
        /// </summary>
        /// <param name="type">this 型情報</param>
        /// <returns>True : List / False : Listでない</returns>
        public static bool IsList(this Type type)
            => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        #endregion

        #region - IsDictionary : Dictionaryか？
        /// <summary>
        /// Dictionaryか？
        /// </summary>
        /// <param name="type">this 型情報</param>
        /// <returns>True : 辞書 / False :  辞書でない</returns>
        public static bool IsDictionary(this Type type)
            => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<,>);
        #endregion

        #region - IsNullable : NULL許容型?
        /// <summary>
        /// NULL許容型?
        /// </summary>
        /// <param name="type">this 型情報</param>
        /// <returns>True : NULL許容型 / False : NULL許容型でない</returns>
        public static bool IsNullable(this Type type)
            => type.IsValueType && type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        #endregion

        #endregion
    }
    #endregion
}