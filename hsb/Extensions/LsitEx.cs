using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Extensions
{
    #region 【Static Class : LsitEx】
    /// <summary>
    /// Listの拡張メソッド
    /// </summary>
    public static class LsitEx
    {
        #region ■ Extension Methods

        #region - Add : リストに要素を追加する
        /// <summary>
        /// リストに要素を追加する
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="list">this リスト</param>
        /// <param name="items">要素（可変）</param>
        public static void Add<T>(this List<T> list, params T[] items)
        {
            list.AddRange(items);
        }
        #endregion

        #endregion
    }
    #endregion
}
