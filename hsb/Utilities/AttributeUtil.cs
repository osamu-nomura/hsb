using System.ComponentModel.DataAnnotations;

namespace hsb.Utilities
{
    #region 【Static Class ; AttributeUtil】
    /// <summary>
    /// 属性関連ユーティリティ
    /// </summary>
    public static class AttributeUtil
    {
        #region ■ Static Methods

        #region - GetEnumFieldDisplayName : EnumフィールドのDisplayName属性を取得する
        /// <summary>
        /// EnumフィールドのDisplayName属性を取得する
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="field">取得対象</param>
        /// <returns>取得対象に対するDisplayName属性値</returns>
        public static string GetEnumFieldDisplayName<T>(T field)
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

        #region - GetObjectPropertyDisplayName : 指定したプロパティのDisplayName属性を取得する
        /// <summary>
        /// 指定したプロパティのDisplayName属性を取得する
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="obj">取得対象オブジェクト</param>
        /// <param name="propertyName">プロパティ名称</param>
        /// <returns>取得対象に対するDisplayName属性値</returns>
        public static string GetObjectPropertyDisplayName<T>(T obj, string propertyName)
        {
            var objType = obj.GetType();
            var propInfo = objType.GetProperty(propertyName);
            if (propInfo != null)
            {
                var descriptionAttributes = propInfo.GetCustomAttributes(
                    typeof(DisplayAttribute), false) as DisplayAttribute[];
                if (descriptionAttributes?.Length > 0)
                    return descriptionAttributes[0].Name;
            }
            else
            {
                var fieldInfo = objType.GetField(propertyName);
                if (fieldInfo != null)
                {
                    var descriptionAttributes = fieldInfo.GetCustomAttributes(
                        typeof(DisplayAttribute), false) as DisplayAttribute[];
                    if (descriptionAttributes?.Length > 0)
                        return descriptionAttributes[0].Name;
                }
            }
            return propertyName;
        }
        #endregion

        #endregion
    }
    #endregion
}
