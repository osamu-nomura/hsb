using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Classes
{
    #region 【Class : SquareArrayColumn】
    /// <summary>
    /// 2次元配列向け列クラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SquareArrayColumn<T> : IEnumerable<T>
    {
        #region ■ Members
        /// <summary>
        /// 2次元配列
        /// </summary>
        private T[,] _array;
        /// <summary>
        /// 列インデックス
        /// </summary>
        private int _colIndex;
        #endregion

        #region ■ Properties

        #region ■ Indexa
        /// <summary>
        /// インデクサ
        /// </summary>
        /// <param name="rowIndex">行インデックス</param>
        /// <returns>要素</returns>
        public T this[int rowIndex]
        {
            get => _array[rowIndex, _colIndex];
            set => _array[rowIndex, _colIndex] = value;
        }
        #endregion

        #region - Length : 長さ
        /// <summary>
        /// Length
        /// </summary>
        public int Length => _array.GetLength(0);
        #endregion

        #endregion

        #region ■ Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="array">2次元配列</param>
        /// <param name="rowIndex">行インデックス</param>
        public SquareArrayColumn(T[,] array, int colIndex)
        {
            _array = array;
            _colIndex = colIndex;
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
