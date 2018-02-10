using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Classes.Tests
{
    #region 【Class ; DateTimeManagerTests】
    /// <summary>
    /// DateTimeManagerクラスのテスト
    /// </summary>
    [TestClass()]
    public class DateTimeManagerTests
    {
        #region - NowTest
        /// <summary>
        /// Test of Now
        /// </summary>
        [TestMethod()]
        public void NowTest()
        {
            // 常に現在日時を 2018年01月01日12;00;00を返すよう設定
            DateTimeManager.Generator = () => { return new DateTime(2018, 01, 01, 12, 0, 0); };
            Assert.AreEqual(new DateTime(2018, 01, 01, 12, 0, 0), DateTimeManager.Now);
        }
        #endregion

        #region - UtcNowTest
        /// <summary>
        /// UtcTest of Now
        /// </summary>
        [TestMethod()]
        public void UtcNowTest()
        {
            // 常に現在日時を 2018年01月01日12;00;00を返すよう設定
            DateTimeManager.Generator = () => { return new DateTime(2018, 01, 01, 12, 0, 0); };
            Assert.AreEqual(new DateTime(2018, 01, 01, 3, 0, 0, DateTimeKind.Utc), DateTimeManager.UtcNow);
        }
        #endregion

        #region - TodayTest
        /// <summary>
        /// Today of Now
        /// </summary>
        [TestMethod()]
        public void TodayTest()
        {
            // 常に現在日時を 2018年01月01日12;00;00を返すよう設定
            DateTimeManager.Generator = () => { return new DateTime(2018, 01, 01, 12, 0, 0); };
            Assert.AreEqual(new DateTime(2018, 01, 01), DateTimeManager.Today);
        }
        #endregion
    }
    #endregion
}
