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
        #region 【Enum】
        /// <summary>
        /// データ種別
        /// </summary>
        public enum DataType { Scalar, List, Dictionary }
        #endregion

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

            #region - DataType : データ種別
            /// <summary>
            /// データ種別
            /// </summary>
            public DataType DataType { get; set; }
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
                DataType = DataType.Scalar;
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
                        DataType = DataType.List;
                        var values = new List<object>();
                        if (value != null && value is IEnumerable)
                        {
                            foreach (var obj in value as IEnumerable)
                            {
                                values.Add(obj);
                            }
                        }
                        Value = values;
                    }
                    else if (valueType.IsDictionary())
                    {
                        ValueType = valueType.GetGenericArguments()[0];
                        DataType = DataType.Dictionary;
                        var values = new Dictionary<object, object>();
                        if (value != null && value is IDictionary)
                        {
                            foreach (KeyValuePair<object, object> kv in (value as IDictionary))
                            {
                                values.Add(kv.Key, kv.Value);
                            }
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

        public static Dictionary<string, ValueData> ToDictionary(object o)
        {
            var result = new Dictionary<string, ValueData>();

            var objectType = o.GetType();
            if (objectType.IsValueType || objectType.IsArray || objectType.IsList() || objectType.IsDictionary())
            {
                result.Add("", new ValueData(null, objectType, o));
            }
            else
            {
                foreach (var field in objectType.GetFields())
                {
                    result.Add(field.Name, new ValueData(field.Name, field.FieldType, field.GetValue(o)));
                }
                foreach (var prop in objectType.GetProperties())
                {
                    var value = new ValueData(prop.Name, prop.PropertyType, prop.GetValue(o));
                    if (value.DataType == DataType.List)
                    {
                        var values = new List<object>();
                        if (value.Value != null && value.Value is IEnumerable)
                        {
                            foreach (var obj in value.Value as IEnumerable)
                            {
                                if (obj != null)
                                    values.Add(ToDictionary(obj));
                                else
                                    values.Add(null);
                            }
                        }
                        value.Value = values;
                    }
                    else if (value.ValueType.IsClass && value.ValueType != typeof(string) && value.Value != null)
                    {
                        value.Value = ToDictionary(value.Value);
                    }
                    result.Add(prop.Name, value);
                }
            }
            return result;
        }

        #endregion
    }
    #endregion
}