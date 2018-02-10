using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using hsb.Extensions;

namespace hsb.Classes
{
    #region 【Static Class : DateTimeManager】
    /// <summary>
    /// 日時管理クラス
    /// </summary>
    public static class DateTimeManager
    {

        #region ■ Static Delegate

        #region - Generator : 現在日時となる値を返すデリゲート
        /// <summary>
        /// 現在日時となる値を返すデリゲート
        /// </summary>
        public static Func<DateTime> Generator = null;
        #endregion

        #endregion

        #region ■ Static Properties

        #region - Now : 現在日時を返す
        /// <summary>
        /// 現在日時を返す
        /// </summary>
        public static DateTime Now
        {
            get
            {
                if (Generator != null)
                    return Generator();
                return DateTime.Now;
            }
        }
        #endregion

        #region - UtcNow : 現在日時をUTCで返す
        /// <summary>
        /// 現在日時をUTCで返す
        /// </summary>
        public static DateTime UtcNow
        {
            get
            {
                if (Generator != null)
                    return Generator().ToUniversalTime();
                return DateTime.UtcNow;
            }
        }
        #endregion

        #region - Today : 現在の日付を返す
        /// <summary>
        /// 現在の日付を返す
        /// </summary>
        public static DateTime Today
        {
            get
            {
                if (Generator != null)
                    return Generator().DropTime();
                return DateTime.Today;
            }
        }
        #endregion

        #endregion
    }
    #endregion
}