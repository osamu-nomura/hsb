using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Extensions.Tests
{
    #region 【Class : DateTimeExTests】
    /// <summary>
    /// DateTimeExのテストクラス
    /// </summary>
    [TestClass()]
    public class DateTimeExTests
    {
        #region - SetYearTest
        /// <summary>
        /// Test for SetYear
        /// </summary>
        [TestMethod()]
        public void SetYearTest()
        {
            DateTime dt, expected;

            // case 1
            dt = new DateTime(2017, 1, 28);
            expected = new DateTime(2018, 1, 28);
            Assert.AreEqual(expected, dt.SetYear(2018));

            // case 2
            dt = new DateTime(2016, 2, 29);
            try
            {
                dt.SetYear(2018);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail("例外が発生しなかった。");
        }
        #endregion

        #region - SetMonthTest
        /// <summary>
        /// Test for SetMonth
        /// </summary>
        [TestMethod()]
        public void SetMonthTest()
        {
            DateTime dt, expected;

            // case 1
            dt = new DateTime(2017, 1, 28);
            expected = new DateTime(2017, 2, 28);
            Assert.AreEqual(expected, dt.SetMonth(2));

            // case 2
            dt = new DateTime(2016, 1, 31);
            try
            {
                dt.SetMonth(2);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail("例外が発生しなかった。");
        }
        #endregion

        #region - SetDayTest
        /// <summary>
        /// Test for SetDay
        /// </summary>
        [TestMethod()]
        public void SetDayTest()
        {
            DateTime dt, expected;

            // case 1
            dt = new DateTime(2017, 1, 28);
            expected = new DateTime(2017, 1, 10);
            Assert.AreEqual(expected, dt.SetDay(10));

            // case 2
            dt = new DateTime(2016, 2, 10);
            try
            {
                dt.SetDay(31);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail("例外が発生しなかった。");
        }
        #endregion

        #region - SafeSetYearTest
        /// <summary>
        /// Test for SafeSetYear
        /// </summary>
        [TestMethod()]
        public void SafeSetYearTest()
        {
            DateTime dt;
            DateTime? expected;

            // case 1
            dt = new DateTime(2017, 1, 28);
            expected = new DateTime(2018, 1, 28);
            Assert.AreEqual(expected, dt.SafeSetYear(2018));

            // case 2
            dt = new DateTime(2016, 2, 29);
            Assert.AreEqual(null, dt.SafeSetYear(2018));
        }
        #endregion

        #region - SafeSetMonthTest
        /// <summary>
        /// Test for SafeSetMonth
        /// </summary>
        [TestMethod()]
        public void SafeSetMonthTest()
        {
            DateTime dt;
            DateTime? expected;

            // case 1
            dt = new DateTime(2017, 1, 28);
            expected = new DateTime(2017, 2, 28);
            Assert.AreEqual(expected, dt.SafeSetMonth(2));

            // case 2
            dt = new DateTime(2016, 1, 31);
            Assert.AreEqual(null, dt.SafeSetMonth(2));
        }
        #endregion

        #region - SafeSetDayTest
        /// <summary>
        /// Test for SafeSetDay
        /// </summary>
        [TestMethod()]
        public void SafeSetDayTest()
        {
            DateTime dt;
            DateTime? expected;

            // case 1
            dt = new DateTime(2017, 1, 28);
            expected = new DateTime(2017, 1, 31);
            Assert.AreEqual(expected, dt.SafeSetDay(31));

            // case 2
            dt = new DateTime(2016, 2, 10);
            Assert.AreEqual(null, dt.SafeSetDay(31));
        }
        #endregion

        #region - IsLeapYearTest
        /// <summary>
        /// Test for IsLEapYear
        /// </summary>
        [TestMethod()]
        public void IsLeapYearTest()
        {
            // Case 1
            Assert.IsTrue(new DateTime(2016, 1, 1).IsLeapYear());
            // Case 2
            Assert.IsTrue(new DateTime(2000, 1, 1).IsLeapYear());
            // Case 3
            Assert.IsFalse(new DateTime(2100, 1, 1).IsLeapYear());
            // Case 4
            Assert.IsFalse(new DateTime(2017, 1, 1).IsLeapYear());
        }
        #endregion

        #region - BeginOfYearTest
        /// <summary>
        /// Test for BeginOfYear
        /// </summary>
        [TestMethod()]
        public void BeginOfYearTest()
        {
            var dt = new DateTime(2017, 1, 28);
            var expected = new DateTime(2017, 1, 1);
            Assert.AreEqual(expected, dt.BeginOfYear());
        }
        #endregion

        #region - EndOfYearTest
        /// <summary>
        /// Test for EndOfYear
        /// </summary>
        [TestMethod()]
        public void EndOfYearTest()
        {
            var dt = new DateTime(2017, 1, 28);
            var expected = new DateTime(2017, 12, 31);
            Assert.AreEqual(expected, dt.EndOfYear());
        }
        #endregion

        #region - BeginOfMonthTest
        /// <summary>
        /// Test for BeginOfMonth
        /// </summary>
        [TestMethod()]
        public void BeginOfMonthTest()
        {
            var dt = new DateTime(2017, 2, 28);
            var expected = new DateTime(2017, 2, 1);
            Assert.AreEqual(expected, dt.BeginOfMonth());
        }
        #endregion

        #region - EndOfMonthTest
        /// <summary>
        /// Test for EndOfMonth
        /// </summary>
        [TestMethod()]
        public void EndOfMonthTest()
        {
            var dt = new DateTime(2017, 1, 28);
            var expected = new DateTime(2017, 1, 31);
            Assert.AreEqual(expected, dt.EndOfMonth());
        }
        #endregion
    }
    #endregion
}