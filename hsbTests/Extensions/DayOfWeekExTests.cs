using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace hsb.Extensions.Tests
{
    #region 【Class : DayOfWeekExTests】
    /// <summary>
    /// 曜日拡張メソッドテスト
    /// </summary>
    [TestClass()]
    public class DayOfWeekExTests
    {
        #region - ToFullStringTest
        /// <summary>
        /// Test of ToFullString
        /// </summary>
        [TestMethod()]
        public void ToFullStringTest()
        {
            Assert.AreEqual("月曜日", DayOfWeek.Monday.ToFullString());
            Assert.AreEqual("金曜日", DayOfWeek.Friday.ToFullString());

            var culture = new CultureInfo("en-US");
            Assert.AreEqual("Monday", DayOfWeek.Monday.ToFullString(culture));
            Assert.AreEqual("Friday", DayOfWeek.Friday.ToFullString(culture));
        }
        #endregion

        #region - ToShortStringTest
        /// <summary>
        /// Test of ToShortString
        /// </summary>
        [TestMethod()]
        public void ToShortStringTest()
        {
            Assert.AreEqual("月", DayOfWeek.Monday.ToShortString());
            Assert.AreEqual("金", DayOfWeek.Friday.ToShortString());

            var culture = new CultureInfo("en-US");
            Assert.AreEqual("Mon", DayOfWeek.Monday.ToShortString(culture));
            Assert.AreEqual("Fri", DayOfWeek.Friday.ToShortString(culture));
        }
        #endregion
    }
    #endregion
}