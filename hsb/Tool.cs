using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using hsb.Classes;

namespace hsb
{
    #region 【Static Class : Tool】
    /// <summary>
    /// ヘルパメソッド
    /// </summary>
    public static class Tool
    {
        #region ■ Static Methods

        #region - Enumerator : 引数リストを列挙子で返す
        /// <summary>
        /// 引数リストを列挙子で返す
        /// </summary>
        /// <typeparam name="T">型パラメーター</typeparam>
        /// <param name="parameters">引数（可変）</param>
        /// <returns>列挙子</returns>
        public static IEnumerable<T> Enumerator<T>(params T[] parameters)
        {
            return parameters;
        }
        #endregion

        #region - GetFieldDisplayName : フィールドのDisplayName属性を取得する
        /// <summary>
        /// フィールドのDisplayName属性を取得する
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="field">取得対象</param>
        /// <returns>取得対象に対するDisplayName属性値</returns>
        public static string GetFieldDisplayName<T>(T field)
        {
            var fieldInfo = field.GetType().GetField(field.ToString());
            if (fieldInfo != null)
            {
                var descriptionAttributes = fieldInfo.GetCustomAttributes(
                    typeof(DisplayAttribute), false) as DisplayAttribute[];
                if (descriptionAttributes?.Length > 0)
                    return descriptionAttributes[0].Name;

            }
            return field.ToString();
        }
        #endregion

        #region - GetEnumList : EnumよりValueWithName型のリストを生成する
        /// <summary>
        /// EnumよりValueWithName型のリストを生成する
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <returns>ValueWithName型のリスト</returns>
        public static List<ValueWithName<T>> GetEnumList<T>() where T : IComparable
        {
            var it = Enum.GetValues(typeof(T)) as IEnumerable<T>;
            if (it != null)
                return it.Select(v => new ValueWithName<T>(v, GetFieldDisplayName<T>(v))).ToList();
            return null;
        }
        #endregion

        #endregion
    }
    #endregion
}
