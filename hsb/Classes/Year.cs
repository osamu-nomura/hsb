using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hsb.Types;

namespace hsb.Classes
{
    #region 【Class : Year】
    /// <summary>
    /// 年度クラス
    /// </summary>
    public class Year : DateRange
    {
        #region ■ Properties

        #region - Value : 年度
        /// <summary>
        /// 年度
        /// </summary>
        public int Value { get; private set; }
        #endregion

        #region - BeginningMonth : 期首月
        /// <summary>
        /// 期首月
        /// </summary>
        public int BeginningMonth { get; private set; }
        #endregion

        #region - BeginningDay : 期首日
        /// <summary>
        /// 期首日
        /// </summary>
        public int BeginningDay { get; private set; }
        #endregion

        #region - BeginningDate : 期首日付
        /// <summary>
        /// 期首日付
        /// </summary>
        public DateTime BeginningDate
        {
            get { return new DateTime(Value, BeginningMonth, BeginningDay); }
        }
        #endregion

        #region - ClosingDate : 期末日付
        /// <summary>
        /// 期末日付
        /// </summary>
        public DateTime ClosingDate
        {
            get { return BeginningDate.AddYears(1).AddDays(-1);  }
        }
        #endregion

        #endregion

        #region ■ Constructor
        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="beginningMonth">期首月</param>
        /// <param name="beginningDay">期首日</param>
        public Year(int year, int beginningMonth = 4, int beginningDay = 1)  : base() 
        {
            Value = year;
            BeginningMonth = beginningMonth;
            BeginningDay = beginningDay;

            RangeFrom = BeginningDate;
            RangeTo = ClosingDate;

        }
        #endregion

        #region ■ Methods

        public DateRange GetMonth(Month month)
        {
            var y = ((int)month < BeginningMonth) ? Value + 1 : Value;
            var rangeFrom = new DateTime(y, (int)month, BeginningDay);
            var rangeTo = rangeFrom.AddMonths(1).AddDays(-1);
            return new DateRange(rangeFrom, rangeTo);
        }

        #endregion
    }
    #endregion
}
