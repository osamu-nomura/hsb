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
            Assert.AreEqual(Month.April, y1.BeginningMonth);
            Assert.AreEqual(1, y1.BeginningDay);
            Assert.AreEqual(new DateTime(2017, 4, 1), y1.BeginningDate);
            Assert.AreEqual(new DateTime(2018, 3, 31), y1.ClosingDate);

            // Case 2
            var y2 = new Year(2017, Month.October, 21);
            Assert.AreEqual(2017, y2.Value);
            Assert.AreEqual(Month.October, y2.BeginningMonth);
            Assert.AreEqual(21, y2.BeginningDay);
            Assert.AreEqual(new DateTime(2017, 10, 21), y2.BeginningDate);
            Assert.AreEqual(new DateTime(2018, 10, 20), y2.ClosingDate);

            // Case 3
            var y3 = new Year(2016, Month.January);
            Assert.AreEqual(new DateTime(2016, 1, 1), y3.RangeFrom);
            Assert.AreEqual(new DateTime(2016, 12, 31), y3.RangeTo);
            Assert.AreEqual(366, y3.Count());

            // Case 4
            try
            {
                var invalidYear = new Year(2017, Month.February, 29);
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
            var year2 = new Year(2017, Month.October, 21);
            var feb = year2.GetMonth(Month.February);
            Assert.AreEqual(new DateTime(2018, 2, 21), feb.RangeFrom);
            Assert.AreEqual(new DateTime(2018, 3, 20), feb.RangeTo);
        }
        #endregion

        #region - GetQuarterTest
        /// <summary>
        /// Test of GetQuarter()
        /// </summary>
        [TestMethod()]
        public void GetQuarterTest()
        {
            // Case 1
            var year1 = new Year(2017);
            var q1 = year1.GetQuarter(Quoter.First);
            Assert.AreEqual(new DateTime(2017, 4, 1), q1.RangeFrom);
            Assert.AreEqual(new DateTime(2017, 6, 30), q1.RangeTo);

            // Case 2
            var year2 = new Year(2017, Month.October, 21);
            var q4 = year2.GetQuarter(Quoter.Fourth);
            Assert.AreEqual(new DateTime(2018, 7, 21), q4.RangeFrom);
            Assert.AreEqual(new DateTime(2018, 10, 20), q4.RangeTo);
        }
        #endregion

        #region - IndexerTest
        /// <summary>
        /// Test of Indexer
        /// </summary>
        [TestMethod()]
        public void IndexerTest()
        {
            // Case 1
            var year1 = new Year(2017);
            var aug = year1[Month.August];
            Assert.AreEqual(new DateTime(2017, 8, 1), aug.RangeFrom);
            Assert.AreEqual(new DateTime(2017, 8, 31), aug.RangeTo);

            // Case 2
            var year2 = new Year(2017, Month.October, 21);
            var q4 = year2[Quoter.Fourth];
            Assert.AreEqual(new DateTime(2018, 7, 21), q4.RangeFrom);
            Assert.AreEqual(new DateTime(2018, 10, 20), q4.RangeTo);
        }
        #endregion

        #region - MonthsTest
        /// <summary>
        /// Test og Months()
        /// </summary>
        [TestMethod()]
        public void MonthsTest()
        {
            var year = new Year(2017);
            var months = year.Months().Select(r => r.RangeFrom).ToList();
            var expected = new List<DateTime?>
            {
                new DateTime(2017, 4, 1),
                new DateTime(2017, 5, 1),
                new DateTime(2017, 6, 1),
                new DateTime(2017, 7, 1),
                new DateTime(2017, 8, 1),
                new DateTime(2017, 9, 1),
                new DateTime(2017, 10, 1),
                new DateTime(2017, 11, 1),
                new DateTime(2017, 12, 1),
                new DateTime(2018, 1, 1),
                new DateTime(2018, 2, 1),
                new DateTime(2018, 3, 1)
            };
            Assert.IsTrue(expected.SequenceEqual(months));
        }
        #endregion
    }
    #endregion
}