using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hsb.Types;

namespace hsb.Classes
{
    #region 【Class ; QuarterRange】
    /// <summary>
    /// 四半期クラス
    /// </summary>
    public class QuarterRange : DateRange
    {
        #region ■ Properties

        #region - Value : 四半期
        /// <summary>
        /// 四半期
        /// </summary>
        public Quarter Value { get; private set; }
        #endregion

        #endregion

        #region ■ Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public QuarterRange(Quarter quoter, DateTime beginningDate) : base()
        {
            Value = quoter;
            RangeFrom = beginningDate.AddMonths(3 * ((int)quoter - 1));
            RangeTo = RangeFrom.Value.AddMonths(3).AddDays(-1);
        }
        #endregion
    }
    #endregion
}
