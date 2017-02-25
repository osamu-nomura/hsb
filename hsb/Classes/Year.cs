using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hsb.Types;
using hsb.Extensions;

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
        public Month BeginningMonth { get; private set; }
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
            get { return new DateTime(Value, (int)BeginningMonth, BeginningDay); }
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

        #region ■ Indexer

        #region - Indexer : 月インデクサ
        /// <summary>
        /// 月インデクサ
        /// </summary>
        /// <param name="month">対象月</param>
        /// <returns>対象月の日付範囲</returns>
        public DateRange this[Month month]
        {
            get { return GetMonth(month);  }
        }
        #endregion

        #region - Indexer : 四半期インデクサ
        /// <summary>
        /// 四半期インデクサ
        /// </summary>
        /// <param name="q">対象四半期</param>
        /// <returns>対象四半期の日付範囲</returns>
        public DateRange this[Quoter q]
        {
            get { return GetQuarter(q);  }
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
        public Year(int year, Month beginningMonth = Month.April, int beginningDay = 1)  : base() 
        {
            Value = year;
            BeginningMonth = beginningMonth;
            BeginningDay = beginningDay;

            RangeFrom = BeginningDate;
            RangeTo = ClosingDate;

        }
        #endregion

        #region ■ Methods

        #region - GetMonth : 対象月度の日付範囲を取得
        /// <summary>
        /// 月度期間を取得
        /// </summary>
        /// <param name="month">対象月</param>
        /// <returns>対象月度の日付範囲</returns>
        public DateRange GetMonth(Month month)
        {
            var y = ((int)month < (int)BeginningMonth) ? Value + 1 : Value;
            var rangeFrom = new DateTime(y, (int)month, BeginningDay);
            var rangeTo = rangeFrom.AddMonths(1).AddDays(-1);
            return new DateRange(rangeFrom, rangeTo);
        }
        #endregion

        #region - GetQuarter : 対象四半期の日付範囲を取得
        /// <summary>
        /// 対象四半期の日付範囲を取得
        /// </summary>
        /// <param name="q">対象四半期</param>
        /// <returns>対象四半期の日付範囲を取得</returns>
        public DateRange GetQuarter(Quoter q)
        {
            var rangeFrom = BeginningDate.AddMonths(3 * ((int)q - 1));
            var rangeTo = rangeFrom.AddMonths(3).AddDays(-1);
            return new DateRange(rangeFrom, rangeTo);
        }
        #endregion

        #region - Months : 月度の列挙子を取得する
        /// <summary>
        /// 月度の列挙子を取得する
        /// </summary>
        /// <returns>リスト</returns>
        public IEnumerable<DateRange> Months()
        {
            return Enumerable.Range(0, 12).Select(n => GetMonth(BeginningMonth.Add(n)));
        }
        #endregion

        #endregion
    }
    #endregion
}
