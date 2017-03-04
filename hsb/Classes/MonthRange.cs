using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hsb.Types;

namespace hsb.Classes
{
    #region 【Class : MonthRange】
    /// <summary>
    /// 月度クラス
    /// </summary>
    public class MonthRange : DateRange
    {
        #region ■ Properties

        #region - Value : 月度
        /// <summary>
        /// 月度
        /// </summary>
        public Month Value { get; private set; }
        #endregion

        #endregion

        #region ■ Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="month">対象月</param>
        /// <param name="beginningDay">開始日</param>
        /// <param name="year">対象年</param>
        public MonthRange(Month month, int beginningDay = 1, int? year = null) : base()
        {
            Value = month;
            RangeFrom = new DateTime(year ?? DateTime.Today.Year, (int)Value, beginningDay);
            RangeTo = RangeFrom.Value.AddMonths(1).AddDays(-1);
        }
        #endregion

    }
    #endregion
}
