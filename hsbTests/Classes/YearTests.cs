using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hsb.Types;

namespace hsb.Classes.Tests
{
    #region 【Class ; YearTests】
    /// <summary>
    /// Yearクラスのテスト
    /// </summary>
    [TestClass()]
    public class YearTests
    {
        #region - YearTest
        /// <summary>
        /// Test of Year Class Constructor
        /// </summary>
        [TestMethod()]
        public void YearTest()
        {
            // Case 1
            var y1 = new Year(2017);
            Assert.AreEqual(2017, y1.Value);
            Assert.AreEqual(4, y1.BeginningMonth);
            Assert.AreEqual(1, y1.BeginningDay);
            Assert.AreEqual(new DateTime(2017, 4, 1), y1.BeginningDate);
            Assert.AreEqual(new DateTime(2018, 3, 31), y1.ClosingDate);

            // Case 2
            var y2 = new Year(2017, 10, 21);
            Assert.AreEqual(2017, y2.Value);
            Assert.AreEqual(10, y2.BeginningMonth);
            Assert.AreEqual(21, y2.BeginningDay);
            Assert.AreEqual(new DateTime(2017, 10, 21), y2.BeginningDate);
            Assert.AreEqual(new DateTime(2018, 10, 20), y2.ClosingDate);

            // Case 3
            var y3 = new Year(2016, 1);
            Assert.AreEqual(new DateTime(2016, 1, 1), y3.RangeFrom);
            Assert.AreEqual(new DateTime(2016, 12, 31), y3.RangeTo);
            Assert.AreEqual(366, y3.Count());

            // Case 4
            try
            {
                var invalidYear = new Year(2017, 2, 29);
                Assert.Fail("例外が発生しななかった。");
            }
            catch { }
        }

        #endregion

        #region - GetMonthTest
        /// <summary>
        /// Test of GetMonth()
        /// </summary>
        [TestMethod()]
        public void GetMonthTest()
        {
            // Case 1
            var year1 = new Year(2017);
            var aug = year1.GetMonth(Month.August);
            Assert.AreEqual(new DateTime(2017, 8, 1), aug.RangeFrom);
            Assert.AreEqual(new DateTime(2017, 8, 31), aug.RangeTo);

            // Case 2
            var year2 = new Year(2017, 10, 21);
            var feb = year2.GetMonth(Month.February);
            Assert.AreEqual(new DateTime(2018, 2, 21), feb.RangeFrom);
            Assert.AreEqual(new DateTime(2018, 3, 20), feb.RangeTo);
        }
        #endregion
    }
    #endregion
}