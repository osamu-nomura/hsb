using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Classes
{
    #region 【Class : SquareArrayRow】
    /// <summary>
    /// 2次元配列向け行クラス
    /// </summary>
    /// <typeparam name="T">型パラメータ</typeparam>
    public class SquareArrayRow<T> : IEnumerable<T>
    {
        #region ■ Members
        /// <summary>
        /// 2次元配列
        /// </summary>
        private T[,] _array;
        /// <summary>
        /// 行インデックス
        /// </summary>
        private int _rowIndex;
        #endregion

        #region ■ Properties

        #region ■ Indexa
        /// <summary>
        /// インデクサ
        /// </summary>
        /// <param name="colIndex">列インデックス</param>
        /// <returns>要素</returns>
        public T this[int colIndex]
        {
            get => _array[_rowIndex, colIndex];
            set => _array[_rowIndex, colIndex] = value;
        }
        #endregion

        #region - Length : 長さ
        /// <summary>
        /// Length
        /// </summary>
        public int Length => _array.GetLength(1);
        #endregion

        #endregion

        #region ■ Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="array">2次元配列</param>
        /// <param name="rowIndex">行インデックス</param>
        public SquareArrayRow(T[,] array, int rowIndex)
        {
            _array = array;
            _rowIndex = rowIndex;
        }
        #endregion

        #region ■ Methods

        #region - GetEnumerator : GetEnumerator()の実装
        /// <summary>
        /// GetEnumerator()の実装
        /// </summary>
        /// <returns>IEnumerator<T></returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < Length; i++)
                yield return this[i];
        }
        #endregion

        #region - GetEnumerator : GetEnumerator()の実装
        /// <summary>
        /// GetEnumerator()の実装
        /// </summary>
        /// <returns>IEnumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion

        #endregion
    }
    #endregion
}
