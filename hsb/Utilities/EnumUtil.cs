using System;
using System.Collections.Generic;
using System.Linq;
using hsb.Classes;

using static hsb.Utilities.AttributeUtil;

namespace hsb.Utilities
{
    #region 【Static Class : EnumUtil】
    /// <summary>
    /// 列挙型関連ユーティリティ
    /// </summary>
    public static class EnumUtil
    {
        #region ■ Static Methods

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
                return it.Select(v => new ValueWithName<T>(v, GetEnumFieldDisplayName<T>(v))).ToList();
            return null;
        }
        #endregion

        #endregion
    }
    #endregion
}
