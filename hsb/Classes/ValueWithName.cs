using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Classes
{
    #region 【Class : ValueWithName】
    /// <summary>
    /// 名前付き値クラス
    /// </summary>
    /// <typeparam name="T">型パラメーター</typeparam>
    public class ValueWithName<T> : IComparable<ValueWithName<T>> where T : IComparable
    {
        #region ■ Properties

        #region - Value : 値
        /// <summary>
        /// 値
        /// </summary>
        public T Value { get; private set; }
        #endregion

        #region - Name
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; private set; }
        #endregion

        #endregion

        #region ■ Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="name">名称</param>
        public ValueWithName(T value, string name)
        {
            Value = value;
            Name = name;
        }
        #endregion

        #region ■ Methods 

        #region - Equals : 同値判定(1)
        /// <summary>
        /// 同値判定(1)
        /// </summary>
        /// <param name="obj">比較対象</param>
        /// <returns>True : 一致 / False : 不一致</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else
            {
                var o = obj as ValueWithName<T>;
                if ((object)o != null)
                    return Value.Equals(o.Value);
                else
                    return Value.Equals(obj);
            }
        }
        #endregion

        #region - Equals : 同値判定(2)
        /// <summary>
        /// 同値判定(2)
        /// </summary>
        /// <param name="val">比較対象</param>
        /// <returns>True : 一致 / False : 不一致</returns>
        public bool Equals(ValueWithName<T> val)
        {
            if ((object)val != null)
                return Value.Equals(val.Value);
            else
                return false;
        }
        #endregion

        #region - GetHashCode : ハッシュ値を取得する
        /// <summary>
        /// ハッシュ値を取得する
        /// </summary>
        /// <returns>ハッシュ値</returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        #endregion

        #region - CompareTo : 大小比較メソッド
        /// <summary>
        /// 大小比較メソッド
        /// 　※ IComparableの実装
        /// </summary>
        /// <param name="val">比較対象</param>
        /// <returns>負:比較対象より小さい / 0:比較対象と同値 / 正:比較対象より大きい</returns>
        public int CompareTo(ValueWithName<T> val)
        {
            if (val == null)
                throw new ArgumentNullException();
            return Value.CompareTo(val.Value);
        }
        #endregion

        #region - ToString : 文字列化
        /// <summary>
        /// 文字列化
        /// </summary>
        /// <returns>名称、名称がNULLであれば値を文字列化したもの</returns>
        public override string ToString()
        {
            return Name ?? Value.ToString();
        }
        #endregion

        #endregion

        #region ■ Operators

        #region - Operator == : 等号演算子(1)
        /// <summary>
        /// 等号演算子(1)
        /// </summary>
        /// <param name="v1">値1</param>
        /// <param name="v2">値2</param>
        /// <returns>TRUE:等しい / FALSE:等しくない</returns>
        public static bool operator ==(ValueWithName<T> v1, ValueWithName<T> v2)
        {
            if (ReferenceEquals(v1, v2))
                return true;
            return ((object)v1 != null && (object)v2 != null) ? v1.Value.Equals(v2.Value) : false;
        }
        #endregion

        #region - Operator == : 等号演算子(2)
        /// <summary>
        /// 等号演算子(2)
        /// </summary>
        /// <param name="val">値1</param>
        /// <param name="rawVal">値2</param>
        /// <returns>TRUE:等しい / FALSE:等しくない</returns>
        public static bool operator ==(ValueWithName<T> val, T rawVal)
        {
            if ((object)val == null)
                return rawVal == null;
            else
                return val.Value.Equals(rawVal);
        }
        #endregion

        #region - Operator == : 等号演算子(3)
        /// <summary>
        /// 等号演算子(3)
        /// </summary>
        /// <param name="rawVal">値1</param>
        /// <param name="val">値2</param>
        /// <returns>TRUE:等しい / FALSE:等しくない</returns>
        public static bool operator ==(T rawVal, ValueWithName<T> val)
        {
            return val == rawVal;
        }
        #endregion

        #region - Operator != : 不等号演算子(1)
        /// <summary>
        /// 不等号演算子(1)
        /// </summary>
        /// <param name="val1">値1</param>
        /// <param name="val2">値2</param>
        /// <returns>TRUE:等しくない / FALSE:等しくない</returns>
        public static bool operator !=(ValueWithName<T> val1, ValueWithName<T> val2)
        {
            return !(val1 == val2);
        }
        #endregion

        #region - Operator != : 不等号演算子(2)
        /// <summary>
        /// 不等号演算子(2)
        /// </summary>
        /// <param name="val">値1</param>
        /// <param name="rawVal">値2</param>
        /// <returns>TRUE:等しくない / FALSE:等しい</returns>
        public static bool operator !=(ValueWithName<T> val, T rawVal)
        {
            return !(val == rawVal);
        }
        #endregion

        #region - Operator != : 不等号演算子(3)
        /// <summary>
        /// 不等号演算子(3)
        /// </summary>
        /// <param name="rawVal">値1</param>
        /// <param name="val">値2</param>
        /// <returns>TRUE:等しくない / FALSE:等しい</returns>
        public static bool operator !=(T rawVal, ValueWithName<T> val)
        {
            return !(val == rawVal);
        }
        #endregion

        #region - Operater() :  Tへのキャスト演算子
        /// <summary>
        /// 値の型へのキャスト演算子
        /// </summary>
        /// <param name="val">値</param>
        /// <returns>Tへのキャスト演算子</returns>
        public static explicit operator T(ValueWithName<T> val)
        {
            return val.Value;
        }
        #endregion

        #region - Operater > : ＞演算子
        /// <summary>
        /// ＞演算子
        /// </summary>
        /// <param name="val1">値1</param>
        /// <param name="val2">値2</param>
        /// <returns>TRUE:左辺が右辺より大きい / FALSE:左辺が右辺より大きくない</returns>
        public static bool operator >(ValueWithName<T> val1, ValueWithName<T> val2)
        {
            return (val1 != null && val2 != null) ? val1.Value.CompareTo(val2.Value) > 0 : false;
        }
        #endregion

        #region - Operater > : ＞演算子
        /// <summary>
        /// ＞演算子
        /// </summary>
        /// <param name="val">値1</param>
        /// <param name="rawVal">値2</param>
        /// <returns>TRUE:左辺が右辺より大きい / FALSE:左辺が右辺より大きくない</returns>
        public static bool operator >(ValueWithName<T> val, T rawVal)
        {
            return (val != null) ? val.Value.CompareTo(rawVal) > 0 : false;
        }
        #endregion

        #region - Operater > : ＞演算子
        /// <summary>
        /// ＞演算子
        /// </summary>
        /// <param name="rawVal">値1</param>
        /// <param name="val">値2</param>
        /// <returns>TRUE:左辺が右辺より大きい / FALSE:左辺が右辺より大きくない</returns>
        public static bool operator >(T rawVal, ValueWithName<T> val)
        {
            return (val != null) ? val.Value.CompareTo(rawVal) <= 0 : false;
        }
        #endregion

        #region - Operater >= : ≧演算子(1)
        /// <summary>
        /// ≧演算子(1)
        /// </summary>
        /// <param name="val1">値1</param>
        /// <param name="val2">値2</param>
        /// <returns>TRUE:左辺が右辺以上 / FALSE:左辺が右辺以上でない</returns>
        public static bool operator >=(ValueWithName<T> val1, ValueWithName<T> val2)
        {
            return val1 == val2 || val1 > val2;
        }
        #endregion

        #region - Operater >= : ≧演算子(2)
        /// <summary>
        /// ≧演算子(2)
        /// </summary>
        /// <param name="val">値1</param>
        /// <param name="rawVal">値2</param>
        /// <returns>c</returns>
        public static bool operator >=(ValueWithName<T> val, T rawVal)
        {
            return val == rawVal || val > rawVal;
        }
        #endregion

        #region - Operater >= : ≧演算子(3
        /// <summary>
        /// ≧演算子(3)
        /// </summary>
        /// <param name="rawVal">値1</param>
        /// <param name="id">値2</param>
        /// <returns>≧演算子(3</returns>
        public static bool operator >=(T rawVal, ValueWithName<T> val)
        {
            return val == rawVal || rawVal > val;
        }
        #endregion

        #region - Operater < : ＜演算子(1)
        /// <summary>
        /// ＜演算子(1)
        /// </summary>
        /// <param name="val1">値1</param>
        /// <param name="val2">値2</param>
        /// <returns>TRUE:左辺が右辺より小さい / FALSE:左辺が右辺より小さくない</returns>
        public static bool operator <(ValueWithName<T> val1, ValueWithName<T> val2)
        {
            return (val1 != null && val2 != null) ? val1.Value.CompareTo(val2.Value) < 0 : false;
        }
        #endregion

        #region - Operater < : ＜演算子(2)
        /// <summary>
        /// ＜演算子(2)
        /// </summary>
        /// <param name="val">値1</param>
        /// <param name="rawVal">値2</param>
        /// <returns>TRUE:左辺が右辺より小さい / FALSE:左辺が右辺より小さくない</returns>
        public static bool operator <(ValueWithName<T> val, T rawVal)
        {
            return (val != null) ? val.Value.CompareTo(rawVal) < 0 : false;
        }
        #endregion

        #region - Operater < : ＜演算子(3)
        /// <summary>
        /// ＜演算子(3)
        /// </summary>
        /// <param name="rawVal">T</param>
        /// <param name="val">IdWithDisplayName</param>
        /// <returns>TRUE:左辺が右辺より小さい / FALSE:左辺が右辺より小さくない</returns>
        public static bool operator <(T rawVal, ValueWithName<T> val)
        {
            return (val != null) ? val.Value.CompareTo(rawVal) > 0 : false;
        }
        #endregion

        #region - Operater <= : ≦演算子(1)
        /// <summary>
        /// ≦演算子(1)
        /// </summary>
        /// <param name="val1">値1</param>
        /// <param name="val2">値2</param>
        /// <returns>TRUE:左辺が右辺以下 / FALSE:左辺が右辺以下でない</returns>
        public static bool operator <=(ValueWithName<T> val1, ValueWithName<T> val2)
        {
            return val1 == val2 || val1 < val2;
        }
        #endregion

        #region - Operater <= : ≦演算子(2)
        /// <summary>
        /// ≦演算子(2)
        /// </summary>
        /// <param name="val">値1</param>
        /// <param name="rawVal">値2</param>
        /// <returns>TRUE:左辺が右辺以下 / FALSE:左辺が右辺以下でない</returns>
        public static bool operator <=(ValueWithName<T> val, T rawVal)
        {
            return val == rawVal || val < rawVal;
        }
        #endregion

        #region - Operater <= : ≦演算子(3)
        /// <summary>
        /// ≦演算子(3)
        /// </summary>
        /// <param name="rawVal">値1</param>
        /// <param name="val">値2</param>
        /// <returns>TRUE:左辺が右辺以下 / FALSE:左辺が右辺以下でない</returns>
        public static bool operator <=(T rawVal, ValueWithName<T> val)
        {
            return rawVal == val || rawVal < val;
        }
        #endregion

        #endregion
    }
    #endregion
}
