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

        #endregion
    }
    #endregion
}
