using hsb.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Types;
using System;

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
        /// Test of SetYear
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
        /// Test of SetMonth
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

            // case 3
            dt = new DateTime(2017, 1, 28);
            expected = new DateTime(2017, 2, 28);
            Assert.AreEqual(expected, dt.SetMonth(Month.February));

            // case 4
            dt = new DateTime(2016, 1, 31);
            try
            {
                dt.SetMonth(Month.February);
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
        /// Test of SetDay
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
        /// Test of SafeSetYear
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
        /// Test of SafeSetMonth
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

            // case 3
            dt = new DateTime(2017, 1, 28);
            expected = new DateTime(2017, 2, 28);
            Assert.AreEqual(expected, dt.SafeSetMonth(Month.February));

            // case 4
            dt = new DateTime(2016, 1, 31);
            Assert.AreEqual(null, dt.SafeSetMonth(Month.February));
        }
        #endregion

        #region - SafeSetDayTest
        /// <summary>
        /// Test of SafeSetDay
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
        /// Test of IsLEapYear
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
        /// Test of BeginOfYear
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
        /// Test of EndOfYear
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
        /// Test of BeginOfMonth
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
        /// Test of EndOfMonth
        /// </summary>
        [TestMethod()]
        public void EndOfMonthTest()
        {
            var dt = new DateTime(2017, 1, 28);
            var expected = new DateTime(2017, 1, 31);
            Assert.AreEqual(expected, dt.EndOfMonth());
        }
        #endregion

        #region - SundayOfWeekTest
        /// <summary>
        /// Test of SundayOfWeek
        /// </summary>
        [TestMethod()]
        public void SundayOfWeekTest()
        {
            var dts = new DateTime[] {
                new DateTime(2017, 1, 22),
                new DateTime(2017, 1, 28)
            };
            var expected = new DateTime(2017, 1, 22);

            foreach (var dt in dts)
            {
                Assert.AreEqual(expected, dt.SundayOfWeek());
            }
        }
        #endregion

        #region - MondayOfWeekTest 
        /// <summary>
        /// Test of MondayOfWeek
        /// </summary>
        [TestMethod()]
        public void MondayOfWeekTest()
        {
            var dts = new DateTime[] {
                new DateTime(2017, 1, 22),
                new DateTime(2017, 1, 23),
                new DateTime(2017, 1, 28)
            };
            var expected = new DateTime(2017, 1, 23);

            foreach (var dt in dts)
            {
                Assert.AreEqual(expected, dt.MondayOfWeek());
            }
        }
        #endregion

        #region - TuesdayOfWeekTest
        /// <summary>
        /// Test of TuesdayOfWeek
        /// </summary>
        [TestMethod()]
        public void TuesdayOfWeekTest()
        {
            var dts = new DateTime[] {
                new DateTime(2017, 1, 22),
                new DateTime(2017, 1, 24),
                new DateTime(2017, 1, 28)
            };
            var expected = new DateTime(2017, 1, 24);

            foreach (var dt in dts)
            {
                Assert.AreEqual(expected, dt.TuesdayOfWeek());
            }
        }
        #endregion

        #region - WednesdayOfWeekTest
        /// <summary>
        /// Test of WednesdayOfWeek
        /// </summary>
        [TestMethod()]
        public void WednesdayOfWeekTest()
        {
            var dts = new DateTime[] {
                new DateTime(2017, 1, 22),
                new DateTime(2017, 1, 25),
                new DateTime(2017, 1, 28)
            };
            var expected = new DateTime(2017, 1, 25);

            foreach (var dt in dts)
            {
                Assert.AreEqual(expected, dt.WednesdayOfWeek());
            }
        }
        #endregion

        #region - ThursdayOfWeekTest
        /// <summary>
        /// Test of ThursdayOfWeek
        /// </summary>
        [TestMethod()]
        public void ThursdayOfWeekTest()
        {
            var dts = new DateTime[] {
                new DateTime(2017, 1, 22),
                new DateTime(2017, 1, 26),
                new DateTime(2017, 1, 28)
            };
            var expected = new DateTime(2017, 1, 26);

            foreach (var dt in dts)
            {
                Assert.AreEqual(expected, dt.ThursdayOfWeek());
            }
        }
        #endregion

        #region - FridayOfWeekTest
        /// <summary>
        /// Test of FridayOfWeek
        /// </summary>
        [TestMethod()]
        public void FridayOfWeekTest()
        {
            var dts = new DateTime[] {
                new DateTime(2017, 1, 22),
                new DateTime(2017, 1, 27),
                new DateTime(2017, 1, 28)
            };
            var expected = new DateTime(2017, 1, 27);

            foreach (var dt in dts)
            {
                Assert.AreEqual(expected, dt.FridayOfWeek());
            }
        }
        #endregion

        #region - SaturdayOfWeekTest 
        /// <summary>
        /// Test of SaturdayOfWeek
        /// </summary>
        [TestMethod()]
        public void SaturdayOfWeekTest()
        {
            var dts = new DateTime[] {
                new DateTime(2017, 1, 22),
                new DateTime(2017, 1, 28)
            };
            var expected = new DateTime(2017, 1, 28);

            foreach (var dt in dts)
            {
                Assert.AreEqual(expected, dt.SaturdayOfWeek());
            }
        }
        #endregion

        #region - DropTimeTest
        /// <summary>
        /// Test of DropTime
        /// </summary>
        [TestMethod()]
        public void DropTimeTest()
        {
            var dt = new DateTime(2017, 1, 28, 11, 22, 33, 44);
            var expected = new DateTime(2017, 1, 28);
            Assert.AreEqual(expected, dt.DropTime());
        }
        #endregion

        #region - DropDateTest
        /// <summary>
        /// Test of DropDate
        /// </summary>
        [TestMethod()]
        public void DropDateTest()
        {
            DateTime dt, expected;

            // Case 1
            dt = new DateTime(2017, 1, 28, 11, 22, 33, 44);
            expected = new DateTime(1, 1, 1, 11, 22, 33, 44);
            Assert.AreEqual(expected, dt.DropDate());

            // Case 2
            dt = new DateTime(2017, 1, 28, 11, 22, 33, 44);
            expected = new DateTime(2001, 1, 1, 11, 22, 33, 44);
            Assert.AreEqual(expected, dt.DropDate(new DateTime(2001, 1, 1)));
        }
        #endregion

        #region - ToTest
        /// <summary>
        /// Test of To
        /// </summary>
        [TestMethod()]
        public void ToTest()
        {
            var expecteds = new DateTime[]
            {
                new DateTime(2017, 2, 1),
                new DateTime(2017, 2, 2),
                new DateTime(2017, 2, 3),
                new DateTime(2017, 2, 4),
                new DateTime(2017, 2, 5)
            };

            // Case 1
            var i = 0;
            foreach (var dt in new DateTime(2017, 2, 1).To(new DateTime(2017, 2, 5)))
            {
                Assert.AreEqual(expecteds[i++], dt);
            }
            Assert.AreEqual(5, i);

            // Case 2
            i = 0;
            foreach (var dt in new DateTime(2017, 2, 1).To(4, DatePart.Day))
            {
                Assert.AreEqual(expecteds[i++], dt);
            }
            Assert.AreEqual(5, i);
        }
        #endregion

        #region - AddTest
        /// <summary>
        /// Test of Add
        /// </summary>
        [TestMethod()]
        public void AddTest()
        {
            Assert.AreEqual(new DateTime(2018, 2, 4), new DateTime(2017, 2, 4).Add(1, DatePart.Year));
            Assert.AreEqual(new DateTime(2017, 3, 4), new DateTime(2017, 2, 4).Add(1, DatePart.Month));
            Assert.AreEqual(new DateTime(2017, 2, 5), new DateTime(2017, 2, 4).Add(1, DatePart.Day));
            Assert.AreEqual(new DateTime(2017, 2, 4, 1, 0, 0, 0), new DateTime(2017, 2, 4).Add(1, DatePart.Hour));
            Assert.AreEqual(new DateTime(2017, 2, 4, 0, 1, 0, 0), new DateTime(2017, 2, 4).Add(1, DatePart.Minute));
            Assert.AreEqual(new DateTime(2017, 2, 4, 0, 0, 1, 0), new DateTime(2017, 2, 4).Add(1, DatePart.Second));
            Assert.AreEqual(new DateTime(2017, 2, 4, 0, 0, 0, 1), new DateTime(2017, 2, 4).Add(1, DatePart.Milisecond));
        }
        #endregion

        #region - ChangeKindTest
        /// <summary>
        /// Test of ChangeKind
        /// </summary>
        [TestMethod()]
        public void ChangeKindTest()
        {
            DateTime dt, expected;
            dt = new DateTime(2018, 2, 17, 0, 0, 0);
            expected = new DateTime(2018, 2, 17, 9, 0, 0);
            Assert.AreEqual(expected, dt.ChangeKind(DateTimeKind.Utc).ToLocalTime());
        }
        #endregion

        #region - ToUnixTimeTest
        /// <summary>
        /// Test of ToUnixTime
        /// </summary>
        [TestMethod()]
        public void ToUnixTimeTest()
        {
            var dt = new DateTime(2018, 4, 14, 12, 52, 39);
            var expected = 1523677959;
            Assert.AreEqual(expected, dt.ToUnixTime());

            var dt2 = new DateTime(2040, 4, 14, 13, 07, 20);
            var expected2 = (long)2217989240;
            Assert.AreEqual(expected2, dt2.ToUnixTime());
        }
        #endregion
    }
    #endregion
}