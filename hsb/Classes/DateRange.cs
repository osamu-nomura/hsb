using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hsb.Extensions;
using hsb.Types;

namespace hsb.Classes
{
    #region 【Class : DateRange】
    /// <summary>
    /// 日付範囲クラス
    /// </summary>
    public class DateRange : IEnumerable<DateTime>
    {
        #region ■ Properties

        #region - RangeFrom : 範囲開始日
        /// <summary>
        /// 範囲開始日 - Set private only
        /// </summary>
        public DateTime? RangeFrom { get; private set; }
        #endregion

        #region - RangeTo : 範囲終了日
        /// <summary>
        /// 範囲終了日 - Set private only
        /// </summary>
        public DateTime? RangeTo { get; private set; }
        #endregion

        #region - Step : 列挙時のステップ数
        /// <summary>
        /// 列挙時のステップ数
        /// </summary>
        public int Step { get; set; }
        #endregion

        #region - StepUnit : 列挙時のステップ単位
        /// <summary>
        /// 列挙時のステップ単位
        /// </summary>
        public DatePart StepUnit { get; set; }
        #endregion

        #region - DisplayFormat : ToString() 時の書式設定
        /// <summary>
        /// ToString() 時の書式設定
        /// </summary>
        public string DisplayFormat { get; set; }
        #endregion

        #region - IsEmpty : 範囲が空？
        /// <summary>
        /// 範囲が空？ - Calculate
        /// </summary>
        public bool IsEmpty
        {
            get { return (RangeTo ?? DateTime.MaxValue) < (RangeFrom ?? DateTime.MinValue); }
        }
        #endregion

        #region - Span : 範囲の TimeSpan を返す
        /// <summary>
        /// 範囲の TimeSpan を返す - Calculate
        /// </summary>
        public TimeSpan Span
        {
            get
            {
                return (RangeTo ?? DateTime.MaxValue) - (RangeFrom ?? DateTime.MinValue);
            }
        }
        #endregion

        #endregion

        #region ■ Constructor

        #region - Constructor(1)
        /// <summary>
        /// コンストラクタ(1)
        /// </summary>
        public DateRange()
        {
            RangeFrom = null;
            RangeTo = null;
            Step = 1;
            StepUnit = DatePart.Day;
            DisplayFormat = @"{0}～{1}";
        }
        #endregion

        #region **** Constructor(2)
        /// <summary>
        /// コンストラクタ(2)
        /// </summary>
        /// <param name="from">開始日</param>
        /// <param name="to">終了日</param>
        /// <param name="step">ステップ数</param>
        /// <param name="stepUnit">ステップ単位</param>
        public DateRange(DateTime? from, DateTime? to, int step = 1, DatePart stepUnit = DatePart.Day) : this()
        {
            RangeFrom = from;
            RangeTo = to;
            Step = step;
            StepUnit = stepUnit;
        }
        #endregion

        #endregion

        #region ■ Private Methods

        #endregion

        #region ■ Methods

        #region - GetEnumerator : IEnumerable.GetEnumerator の実装(Generics版)
        /// <summary>
        /// IEnumerable.GetEnumerator の実装(Generics版)
        /// </summary>
        /// <returns>IEnumerator of DateTime</returns>
        IEnumerator<DateTime> IEnumerable<DateTime>.GetEnumerator()
        {
            if (!IsEmpty)
            {
                var i = 1;
                var rangeFrom = RangeFrom ?? DateTime.MinValue;
                var rangeTo = RangeTo ?? DateTime.MaxValue;
                for (var dt = rangeFrom; dt <= rangeTo; dt = rangeFrom.Add(Step * i++, StepUnit))
                    yield return dt;
            }
        }
        #endregion

        #region - GetEnumerator : IEnumerable.GetEnumerator の実装
        /// <summary>
        /// IEnumerable.GetEnumerator の実装
        /// </summary>
        /// <returns>IEnumerator of DateTime</returns>
        /// 
        IEnumerator IEnumerable.GetEnumerator()
        {
            if (!IsEmpty)
            {
                var i = 1;
                var rangeFrom = RangeFrom ?? DateTime.MinValue;
                var rangeTo = RangeTo ?? DateTime.MaxValue;
                for (var dt = rangeFrom; dt <= rangeTo; dt = rangeFrom.Add(Step * i++, StepUnit))
                    yield return dt;
            }
        }
        #endregion

        #region - InRange : 指定した日時が範囲内
        /// <summary>
        /// 指定した日時が範囲内
        /// </summary>
        /// <param name="dt">検査日</param>
        /// <returns>True : 範囲内 / False : 範囲外</returns>
        public bool InRange(DateTime dt)
        {
            if (!IsEmpty)
                return (RangeFrom ?? DateTime.MinValue) <= dt && dt <= (RangeTo ?? DateTime.MaxValue);
            else
                return false;
        }
        #endregion

        #region - OutOfRange : 指定した日時が範囲外
        /// <summary>
        /// 指定した日時が範囲外
        /// </summary>
        /// <param name="dt">DateTime : 検査日</param>
        /// <returns>True : 範囲外 / False : 範囲内</returns>
        public bool OutOfRange(DateTime dt)
        {
            return !InRange(dt);
        }
        #endregion

        #region - ToString : 文字列化(1)
        /// <summary>
        /// 文字列化(1)
        /// </summary>
        /// <param name="displayFormat">表示書式</param>
        /// <returns>日時の文字列</returns>
        public string ToString(string displayFormat)
        {
            return string.Format(displayFormat, (RangeFrom ?? DateTime.MinValue), (RangeTo ?? DateTime.MaxValue));
        }
        #endregion

        #region - ToString : 文字列化(2)
        /// <summary>
        /// 文字列化(2)
        /// </summary>
        /// <returns>日時の文字列</returns>
        public override string ToString()
        {
            return ToString(DisplayFormat);
        }
        #endregion

        #endregion
    }
    #endregion
}
