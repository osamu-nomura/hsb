using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Types
{
    #region 【Enum : DatePart】
    /// <summary>
    /// 日時部位
    /// </summary>
    public enum DatePart { Year, Month, Day, Hour, Minute, Second, Milisecond }
    #endregion

    #region 【Enum : Month】
    /// <summary>
    /// 月
    /// </summary>
    public enum Month
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }
    #endregion

    #region 【Enum : Quoter】
    /// <summary>
    /// 四半期
    /// </summary>
    public enum Quarter { First = 1, Second = 2, Third = 3, Fourth =  4 }
    #endregion

    #region - Sex : 性別
    /// <summary>
    /// 性別
    /// </summary>
    public enum Sex { Unkown = 0, Male = 1, Female = 2, Other = 9 }
    #endregion
}
