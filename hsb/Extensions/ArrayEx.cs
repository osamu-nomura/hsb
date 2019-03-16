using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hsb.Classes;
using hsb.Types;

namespace hsb.Extensions
{
    #region 【Static Class : ArrayEx】
    /// <summary>
    /// 配列の拡張メソッド
    /// </summary>
    public static class ArrayEx
    {
        #region ■ Extension Methods

        #region - Get : 配列より値を取得する(1)
        /// <summary>
        /// 配列より値を取得する（添え字が範囲外だった場合はデフォルト値を返す）
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="array">this 配列</param>
        /// <param name="i">添え字</param>
        /// <param name="defaultValue">デフォルト値</param>
        /// <returns>配列の値</returns>
        public static T Get<T>(this T[] array, int i, T defaultValue)
            => array.IsWithin(i) ? array[i] : defaultValue;
        #endregion

        #region - Get : 配列より値を取得する(2)
        /// <summary>
        /// 配列より値を取得する（添え字が範囲外の場合、デフォルト値を返す）
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="array">this 配列</param>
        /// <param name="i">インデックス</param>
        /// <param name="generator">添え字が範囲外だった場合に呼ばれるコールバック</param>
        /// <returns>リストの値</returns>
        public static T Get<T>(this T[] array, int i, Func<T> generator)
            => array.IsWithin(i) ? array[i] : generator();
        #endregion

        #region - IsWithin : インデックスが範囲内かどうかチェックする
        /// <summary>
        /// インデックスが範囲内かどうかチェックする
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="array">this 配列</param>
        /// <param name="i">インデックス</param>
        /// <returns>True : 範囲内 / False : 範囲外</returns>
        public static bool IsWithIn<T>(this T[] array, int i)
            => array.Length > i && i >= 0;
        #endregion

        #region - Choice : 配列より要素をランダムに取得する
        /// <summary>
        /// 配列より要素をランダムに取得する
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="array">this 配列</param>
        /// <param name="r">Randomクラスのインスタンス</param>
        /// <returns>ランダムに選択された配列の要素</returns>
        public static T Choice<T>(this T[] array, Random r = null)
            => array[(r ?? new Random()).Next(array.Length )];
        #endregion

        #region - Choice : 2次元配列より要素をランダムに取得する
        /// <summary>
        /// 2次元配列より要素をランダムに取得する
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="array">this 2次元配列</param>
        /// <param name="r">Randomクラスのインスタンス</param>
        /// <returns>ランダムに選択された配列の要素</returns>
        public static T Choice<T>(this T[,] array, Random r = null)
        {
            r = r ?? new Random();
            return array[r.Next(array.GetLength(0)), r.Next(array.GetLength(1))];
        }
        #endregion

        #region - Rows : 2次元配列から行を取得する
        /// <summary>
        /// 2次元配列から行を取得する
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="array">this 2次元配列</param>
        /// <param name="rowIndex">行インデックス</param>
        /// <returns>行オブジェクト</returns>
        public static SquareArrayRow<T> Rows<T>(this T[,] array, int rowIndex)
        {
            if (rowIndex < 0 || array.GetLength(0) <= rowIndex)
                throw new IndexOutOfRangeException();
            return new SquareArrayRow<T>(array, rowIndex);
        }
        #endregion

        #region - Rows : 2次元配列から行を列挙する
        /// <summary>
        /// 2次元配列から行を列挙する
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="array">this 2次元配列</param>
        /// <returns>行オブジェクトの列挙子</returns>
        public static IEnumerable<SquareArrayRow<T>> Rows<T>(this T[,] array)
        {
            for (var row = 0; row < array.GetLength(0); row++)
                yield return array.Rows(row);
        }
        #endregion

        #region - Cols : 2次元配列から列を取得する
        /// <summary>
        /// 2次元配列から列を取得する
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="array">this 2次元配列</param>
        /// <param name="colIndex">列インデックス</param>
        /// <returns>行オブジェクト</returns>
        public static SquareArrayColumn<T> Cols<T>(this T[,] array, int colIndex)
        {
            if (colIndex < 0 || array.GetLength(1) <= colIndex)
                throw new IndexOutOfRangeException();
            return new SquareArrayColumn<T>(array, colIndex);
        }
        #endregion

        #region - Cols : 2次元配列から列を列挙する
        /// <summary>
        /// 2次元配列から列を列挙する
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="array">this 2次元配列</param>
        /// <returns>行オブジェクトの列挙子</returns>
        public static IEnumerable<SquareArrayColumn<T>> Cols<T>(this T[,] array)
        {
            for (var col = 0; col < array.GetLength(1); col++)
                yield return array.Cols(col);
        }
        #endregion

        #region - Flatten : 2次元配列をまとめて列挙する
        /// <summary>
        /// 2次元配列をまとめて列挙する
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="array">2次元配列</param>
        /// <param name="direction">方向</param>
        /// <returns>列挙子</returns>
        public static IEnumerable<T> Flatten<T>(this T[,] array, SquareDirection direction = SquareDirection.Row)
        {
            IEnumerable<T> rowDirection()
            {
                for (var row = 0; row < array.GetLength(0); row++)
                {
                    for (var col = 0; col < array.GetLength(1); col++)
                    {
                        yield return array[row, col];
                    }
                }
            }

            IEnumerable<T> colDirection()
            {
                for (var col = 0; col < array.GetLength(1); col++)
                {
                    for (var row = 0; row < array.GetLength(0); row++)
                    {
                        yield return array[row, col];
                    }
                }
            }

            if (direction == SquareDirection.Row)
                return rowDirection();
            else
                return colDirection();
        }
        #endregion

        #region - Rotate : 2次元配列を回転させた配列を返す
        /// <summary>
        /// 2次元配列を回転させた配列を返す
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="array">配列</param>
        /// <param name="direction">回転方向</param>
        /// <returns>配列</returns>
        public static T[,] Rotate<T>(this T[,] array, RotateDirection direction = RotateDirection.Right) where T: new()
        {
            T[,] RightDirection()
            {
                var result = new T[array.GetLength(1), array.GetLength(0)];
                var r = 0;
                for (var row = array.GetLength(0) - 1; row >= 0; row--)
                {
                    for (var col = 0; col < array.GetLength(1); col++)
                    {
                        result[col, r] = array[row, col];
                    }
                    r++;
                }
                return result;
            }

            T[,] LeftDirection()
            {
                var result = new T[array.GetLength(1), array.GetLength(0)];
                var c = 0;
                for (var col = array.GetLength(1) - 1; col >= 0; col--)
                {
                    for (var row = 0; row < array.GetLength(0); row++)
                    {
                        result[c, row] = array[row, col];
                    }
                    c++;
                }
                return result;
            }

            if (direction == RotateDirection.Right)
                return RightDirection();
            else
                return LeftDirection();
        }
        #endregion

        #endregion
    }
    #endregion
}
