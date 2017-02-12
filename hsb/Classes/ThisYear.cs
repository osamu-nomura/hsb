using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hsb.Types;

namespace hsb.Classes
{
    #region 【Static Class : ThisYear】
    /// <summary>
    /// 今年クラス
    /// </summary>
    public static class ThisYear
    {
        #region ■ Static Methods

        #region - NewYearsDay : 元旦を返す
        /// <summary>
        /// 元旦を返す
        /// </summary>
        /// <param name="year">年（デフォルトは今年）</param>
        /// <returns>元旦</returns>
        public static DateTime NewYearsDay(int? year = null)
        {
            return new DateTime(year ?? DateTime.Today.Year, 1, 1);
        }
        #endregion

        #region - NewYearsEve : 大晦日を返す
        /// <summary>
        /// 大晦日を返す
        /// </summary>
        /// <param name="year">年（デフォルトは今年）</param>
        /// <returns>大晦日</returns>
        public static DateTime NewYearsEve(int? year = null)
        {
            return new DateTime(year ?? DateTime.Today.Year, 12, 31);
        }
        #endregion

        #region - January : 1月1日を返す
        /// <summary>
        /// 1月1日を返す
        /// </summary>
        /// <param name="year">年（デフォルトは今年）</param>
        /// <returns>1月1日</returns>
        public static DateTime January(int? year = null)
        {
            return NewYearsDay(year);
        }
        #endregion

        #region - February : 2月1日を返す
        /// <summary>
        /// 2月1日を返す
        /// </summary>
        /// <param name="year">年（デフォルトは今年）</param>
        /// <returns>2月1日</returns>
        public static DateTime February(int? year = null)
        {
            return new DateTime(year ?? DateTime.Today.Year, 2, 1);
        }
        #endregion

        #region - March : 3月1日を返す
        /// <summary>
        /// 3月1日を返す
        /// </summary>
        /// <param name="year">年（デフォルトは今年）</param>
        /// <returns>3月1日</returns>
        public static DateTime March(int? year = null)
        {
            return new DateTime(year ?? DateTime.Today.Year, 3, 1);
        }
        #endregion

        #region - April : 4月1日を返す
        /// <summary>
        /// 4月1日を返す
        /// </summary>
        /// <param name="year">年（デフォルトは今年）</param>
        /// <returns>4月1日</returns>
        public static DateTime April(int? year = null)
        {
            return new DateTime(year ?? DateTime.Today.Year, 4, 1);
        }
        #endregion

        #region - May : 5月1日を返す
        /// <summary>
        /// 5月1日を返す
        /// </summary>
        /// <param name="year">年（デフォルトは今年）</param>
        /// <returns>5月1日</returns>
        public static DateTime May(int? year = null)
        {
            return new DateTime(year ?? DateTime.Today.Year, 5, 1);
        }
        #endregion

        #region - June : 6月1日を返す
        /// <summary>
        /// 6月1日を返す
        /// </summary>
        /// <param name="year">年（デフォルトは今年）</param>
        /// <returns>6月1日</returns>
        public static DateTime June(int? year = null)
        {
            return new DateTime(year ?? DateTime.Today.Year, 6, 1);
        }
        #endregion

        #region - July : 7月1日を返す
        /// <summary>
        /// 7月1日を返す
        /// </summary>
        /// <param name="year">年（デフォルトは今年）</param>
        /// <returns>7月1日</returns>
        public static DateTime July(int? year = null)
        {
            return new DateTime(year ?? DateTime.Today.Year, 7, 1);
        }
        #endregion

        #region - August : 8月1日を返す
        /// <summary>
        /// 8月1日を返す
        /// </summary>
        /// <param name="year">年（デフォルトは今年）</param>
        /// <returns>8月1日</returns>
        public static DateTime August(int? year = null)
        {
            return new DateTime(year ?? DateTime.Today.Year, 8, 1);
        }
        #endregion

        #region - September : 9月1日を返す
        /// <summary>
        /// 9月1日を返す
        /// </summary>
        /// <param name="year">年（デフォルトは今年）</param>
        /// <returns>9月1日</returns>
        public static DateTime September(int? year = null)
        {
            return new DateTime(year ?? DateTime.Today.Year, 9, 1);
        }
        #endregion

        #region - October : 10月1日を返す
        /// <summary>
        /// 10月1日を返す
        /// </summary>
        /// <param name="year">年（デフォルトは今年）</param>
        /// <returns>10月1日</returns>
        public static DateTime October(int? year = null)
        {
            return new DateTime(year ?? DateTime.Today.Year, 10, 1);
        }
        #endregion

        #region - November : 11月1日を返す
        /// <summary>
        /// 11月1日を返す
        /// </summary>
        /// <param name="year">年（デフォルトは今年）</param>
        /// <returns>11月1日</returns>
        public static DateTime November(int? year = null)
        {
            return new DateTime(year ?? DateTime.Today.Year, 11, 1);
        }
        #endregion

        #region - December : 12月1日を返す
        /// <summary>
        /// 12月1日を返す
        /// </summary>
        /// <param name="year">年（デフォルトは今年）</param>
        /// <returns>12月1日</returns>
        public static DateTime December(int? year = null)
        {
            return new DateTime(year ?? DateTime.Today.Year, 12, 1);
        }
        #endregion

        #region - Month : 指定した月の1日を返す
        /// <summary>
        /// 指定した月の1日を返す
        /// </summary>
        /// <param name="month">月</param>
        /// <param name="year">年（デフォルトは今年）</param>
        /// <returns>指定月の1日</returns>
        public static DateTime Month(Month month, int? year = null)
        {
            return new DateTime(year ?? DateTime.Today.Year, (int)month, 1);
        }
        #endregion

        #region - Quoter : 四半期期間を取得する
        /// <summary>
        /// 四半期期間を取得する
        /// </summary>
        /// <param name="q">四半期</param>
        /// <param name="year">年度（デフォルト今年）</param>
        /// <param name="startMonth">年度開始月（デフォルト4月）</param>
        /// <returns>四半期期間</returns>
        public static DateRange Quoter(Quoter q, int? year = null, Month startMonth = Types.Month.April)
        {
            if (year == null)
            {
                var today = DateTime.Today;
                year = (today.Month < (int)startMonth) ? today.Year - 1 : today.Year;
            }
            var month = (int)startMonth + ((int)q * 3);
            var dt = new DateTime(year.Value, month, 1);
            return new DateRange(dt, dt.AddMonths(2));
        }
        #endregion

        #region - FirstQuoter : 第1四半期期間を取得する
        /// <summary>
        /// 第1四半期期間を取得する
        /// </summary>
        /// <param name="year">年度（デフォルト今年）</param>
        /// <param name="startMonth">年度開始月（デフォルト4月）</param>
        /// <returns>第1四半期期間</returns>
        public static DateRange FirstQuoter(int? year = null, Month startMonth = Types.Month.April)
        {
            return Quoter(Types.Quoter.First, year, startMonth);
        }
        #endregion

        #region - SecondQuoter : 第2四半期期間を取得する
        /// <summary>
        /// 第2四半期期間を取得する
        /// </summary>
        /// <param name="year">年度（デフォルト今年）</param>
        /// <param name="startMonth">年度開始月（デフォルト4月）</param>
        /// <returns>第2四半期期間</returns>
        public static DateRange SecondQuoter(int? year = null, Month startMonth = Types.Month.April)
        {
            return Quoter(Types.Quoter.Second, year, startMonth);
        }
        #endregion

        #region - ThirdQuoter : 第3四半期期間を取得する
        /// <summary>
        /// 第3四半期期間を取得する
        /// </summary>
        /// <param name="year">年度（デフォルト今年）</param>
        /// <param name="startMonth">年度開始月（デフォルト4月）</param>
        /// <returns>第3四半期期間</returns>
        public static DateRange ThirdQuoter(int? year = null, Month startMonth = Types.Month.April)
        {
            return Quoter(Types.Quoter.Third, year, startMonth);
        }
        #endregion

        #region - FourthQuoter : 第4四半期期間を取得する
        /// <summary>
        /// 第4四半期期間を取得する
        /// </summary>
        /// <param name="year">年度（デフォルト今年）</param>
        /// <param name="startMonth">年度開始月（デフォルト4月）</param>
        /// <returns>第4四半期期間</returns>
        public static DateRange FourthQuoter(int? year = null, Month startMonth = Types.Month.April)
        {
            return Quoter(Types.Quoter.Fourth, year, startMonth);
        }
        #endregion

        #endregion
    }
    #endregion
}
