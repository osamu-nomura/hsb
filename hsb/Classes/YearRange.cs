using System;
using System.Collections.Generic;
using System.Linq;
using hsb.Types;
using hsb.Extensions;

namespace hsb.Classes
{
    #region 【Class : YearRange】
    /// <summary>
    /// 年度クラス
    /// </summary>
    public class YearRange : DateRange
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

        #endregion

        #region ■ Indexer

        #region - Indexer : 月インデクサ
        /// <summary>
        /// 月インデクサ
        /// </summary>
        /// <param name="month">対象月</param>
        /// <returns>対象月の日付範囲</returns>
        public MonthRange this[Month month]
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
        public QuarterRange this[Quarter q]
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
        public YearRange(int year, Month beginningMonth = Month.April, int beginningDay = 1)  : base() 
        {
            Value = year;
            BeginningMonth = beginningMonth;
            BeginningDay = beginningDay;

            RangeFrom = new DateTime(Value, (int)BeginningMonth, BeginningDay);
            RangeTo = RangeFrom.Value.AddYears(1).AddDays(-1);
        }
        #endregion

        #region ■ Methods

        #region - GetMonth : 対象月度の日付範囲を取得
        /// <summary>
        /// 月度期間を取得
        /// </summary>
        /// <param name="month">対象月</param>
        /// <returns>対象月度の日付範囲</returns>
        public MonthRange GetMonth(Month month)
        {
            var y = ((int)month < (int)BeginningMonth) ? Value + 1 : Value;
            return new MonthRange(month, BeginningDay, y);
        }
        #endregion

        #region - GetQuarter : 対象四半期の日付範囲を取得
        /// <summary>
        /// 対象四半期の日付範囲を取得
        /// </summary>
        /// <param name="q">対象四半期</param>
        /// <returns>対象四半期の日付範囲を取得</returns>
        public QuarterRange GetQuarter(Quarter q)
        {
            return new QuarterRange(q, RangeFrom.Value);
        }
        #endregion

        #region - Months : 月度の列挙子を取得する
        /// <summary>
        /// 月度の列挙子を取得する
        /// </summary>
        /// <returns>列挙子</returns>
        public IEnumerable<MonthRange> Months()
        {
            return Enumerable.Range(0, 12).Select(n => GetMonth(BeginningMonth.Add(n)));
        }
        #endregion

        #region - Quarters : 四半期の列挙子を取得する
        /// <summary>
        /// 四半期の列挙子を取得する
        /// </summary>
        /// <returns>列挙子</returns>
        public IEnumerable<QuarterRange> Quarters()
        {
            return Enumerable.Range(1, 4).Select(n => GetQuarter((Quarter)n));
        }
        #endregion

        #endregion
    }
    #endregion
}
