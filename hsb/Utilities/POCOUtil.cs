using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using hsb.Extensions;

namespace hsb.Utilities
{
    #region 【Static Class : POCOUtil】
    public static class POCOUtil
    {
        #region 【Inner Class : ValueData】
        /// <summary>
        /// 値データクラス
        /// </summary>
        public class ValueData
        {
            #region ■ Properties

            #region - Name : 名称
            /// <summary>
            /// 名称
            /// </summary>
            public string Name { get; set; }
            #endregion

            #region - KeyType : Key値型情報
            /// <summary>
            /// Key値型情報
            /// </summary>
            public Type KeyType { get; set; }
            #endregion

            #region - ValueType : 値型情報 
            /// <summary>
            /// 値型情報
            /// </summary>
            public Type ValueType { get; set; }
            #endregion

            #region - IsNullable : NULL許容型?
            /// <summary>
            /// NULL許容型?
            /// </summary>
            public bool IsNullable { get; set; }
            #endregion

            #region - IsCollection : コレクション型?
            /// <summary>
            /// コレクション型?
            /// </summary>
            public bool IsCollection { get; set; }
            #endregion

            #region - Value : 値
            /// <summary>
            /// 値
            /// </summary>
            public Object Value { get; set; }
            #endregion

            #endregion

            #region ■ Constructor
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="name">名称</param>
            /// <param name="valueType">値型情報</param>
            /// <param name="value">値</param>
            public ValueData(string name, Type valueType, object value)
            {
                Name = name;
                KeyType = null;
                ValueType = valueType;
                IsNullable = false;
                IsCollection = false;
                Value = value;

                if (valueType.IsValueType)
                {
                    if (valueType.IsNullable())
                    {
                        ValueType = valueType.GetGenericArguments()[0];
                        IsNullable = true;
                    }
                }
                else
                {
                    if (valueType.IsArray || valueType.IsList())
                    {
                        ValueType = (valueType.IsArray) ? valueType.GetElementType() : valueType.GetGenericArguments()[0];
                        IsCollection = true;
                        var values = new List<object>();
                        foreach (var obj in value as IEnumerable)
                        {
                            values.Add(obj);
                        }
                        Value = values;
                    }
                    else if (valueType.IsDictionary())
                    {
                        ValueType = valueType.GetGenericArguments()[0];
                        IsCollection = true;
                        var values = new List<object>();
                        foreach (var key in (value as IDictionary).Keys)
                        {
                            values.Add(new KeyValuePair<object,object>(key, (value as IDictionary)[key]));
                        }
                        Value = values;
                    }
                }
            }
            #endregion
        }
        #endregion

        #region ■ Static Methods

        #region - Walkthrough : 指定したオブジェクトのフィールド値とプロパティ値を列挙する
        /// <summary>
        /// 指定したオブジェクトのフィールド値とプロパティ値を列挙する
        /// </summary>
        /// <param name="o">Object</param>
        /// <returns>フィールド・プロパティ値の列挙子</returns>
        public static IEnumerable<ValueData> Walkthrough(Object o)
        {
            var objectType = o.GetType();
            if (objectType.IsValueType || objectType.IsArray || objectType.IsList() || objectType.IsDictionary())
            {
                yield return new ValueData(null, objectType, o);
            }
            else
            {
                foreach (var field in objectType.GetFields())
                {
                    yield return new ValueData(field.Name, field.FieldType, field.GetValue(o));
                }
                foreach (var prop in objectType.GetProperties())
                {
                    yield return new ValueData(prop.Name, prop.PropertyType, prop.GetValue(o));
                }
            }
        }
        #endregion

        #endregion
    }
    #endregion
}