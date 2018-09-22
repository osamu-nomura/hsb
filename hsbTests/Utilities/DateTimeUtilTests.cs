using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace hsb.Utilities.Tests
{
    #region 【Class : DateTimeUtilTests】
    /// <summary>
    /// DateTimeUtil Test Class
    /// </summary>
    [TestClass()]
    public class DateTimeUtilTests
    {
        #region - YYYYMMDD2DateTimeTest
        /// <summary>
        /// Test of YYYYMMDD2DateTime
        /// </summary>
        [TestMethod()]
        public void YYYYMMDD2DateTimeTest()
        {
            Assert.AreEqual(new DateTime(2018, 7, 21), DateTimeUtil.YYYYMMDD2DateTime("20180721"));
            Assert.AreEqual(null, DateTimeUtil.YYYYMMDD2DateTime("20180631"));
            Assert.AreEqual(null, DateTimeUtil.YYYYMMDD2DateTime("20180722 "));
            Assert.AreEqual(null, DateTimeUtil.YYYYMMDD2DateTime("201806"));
            Assert.AreEqual(null, DateTimeUtil.YYYYMMDD2DateTime("aaaa"));
        }
        #endregion
        #region - YYYYMMDDHHII2DateTimeTest
        /// <summary>
        /// Test of YYYYMMDDHHII2DateTime
        /// </summary>
        [TestMethod()]
        public void YYYYMMDDHHII2DateTimeTest()
        {
            Assert.AreEqual(new DateTime(2018, 7, 21, 17, 30, 0), DateTimeUtil.YYYYMMDDHHII2DateTime("201807211730"));
            Assert.AreEqual(null, DateTimeUtil.YYYYMMDDHHII2DateTime("201807211799"));
        }
        #endregion
        #region - YYYYMMDDHHIISS2DateTimeTest
        /// <summary>
        /// Test of YYYYMMDDHHIISS2DateTime
        /// </summary>
        [TestMethod()]
        public void YYYYMMDDHHIISS2DateTimeTest()
        {
            Assert.AreEqual(new DateTime(2018, 7, 21, 17, 30, 20), DateTimeUtil.YYYYMMDDHHIISS2DateTime("20180721173020"));
            Assert.AreEqual(null, DateTimeUtil.YYYYMMDDHHIISS2DateTime("20180721173065"));
        }
        #endregion

        #region - CreateTest
        /// <summary>
        /// Test of Create
        /// </summary>
        [TestMethod()]
        public void CreateTest()
        {
            Assert.AreEqual(new DateTime(2018, 9, 1), DateTimeUtil.Create(2018, 9, 1));
            Assert.IsNull(DateTimeUtil.Create(2018, 13, 1));
            Assert.AreEqual(new DateTime(2018, 9, 1, new JapaneseCalendar()), DateTimeUtil.Create(2018, 9, 1, new JapaneseCalendar()));
            Assert.IsNull(DateTimeUtil.Create(2018, 13, 1, new JapaneseCalendar()));
            Assert.AreEqual(new DateTime(2018, 9, 1, 10, 11, 12), DateTimeUtil.Create(2018, 9, 1, 10, 11, 12));
            Assert.IsNull(DateTimeUtil.Create(2018, 9, 1, 10, 99, 12));
            Assert.AreEqual(new DateTime(2018, 9, 1, 10, 11, 12, new JapaneseCalendar()), DateTimeUtil.Create(2018, 9, 1, 10, 11, 12, new JapaneseCalendar()));
            Assert.IsNull(DateTimeUtil.Create(2018, 9, 1, 10, 99, 12, new JapaneseCalendar()));
            Assert.AreEqual(new DateTime(2018, 9, 1, 10, 11, 12, DateTimeKind.Local), DateTimeUtil.Create(2018, 9, 1, 10, 11, 12, DateTimeKind.Local));
            Assert.IsNull(DateTimeUtil.Create(2018, 9, 1, 10, 99, 12, DateTimeKind.Local));
            Assert.AreEqual(new DateTime(2018, 9, 1, 10, 11, 12, 13), DateTimeUtil.Create(2018, 9, 1, 10, 11, 12, 13));
            Assert.IsNull(DateTimeUtil.Create(2018, 9, 1, 10, 99, 12, 13));
            Assert.AreEqual(new DateTime(2018, 9, 1, 10, 11, 12, 13, DateTimeKind.Local), DateTimeUtil.Create(2018, 9, 1, 10, 11, 12, 13, DateTimeKind.Local));
            Assert.IsNull(DateTimeUtil.Create(2018, 9, 1, 10, 99, 12, 13, DateTimeKind.Local));
            Assert.AreEqual(new DateTime(2018, 9, 1, 10, 11, 12, 13, new JapaneseCalendar()), DateTimeUtil.Create(2018, 9, 1, 10, 11, 12, 13, new JapaneseCalendar()));
            Assert.IsNull(DateTimeUtil.Create(2018, 9, 1, 10, 99, 12, 13, new JapaneseCalendar()));
            Assert.AreEqual(new DateTime(2018, 9, 1, 10, 11, 12, 13, new JapaneseCalendar(), DateTimeKind.Local), DateTimeUtil.Create(2018, 9, 1, 10, 11, 12, 13, new JapaneseCalendar(), DateTimeKind.Local));
            Assert.IsNull(DateTimeUtil.Create(2018, 9, 1, 10, 99, 12, 13, new JapaneseCalendar(), DateTimeKind.Local));
        }
        #endregion

        #region - String2DayOfWeekTest 
        /// <summary>
        /// Test of String2DayOfWeek
        /// </summary>
        [TestMethod()]
        public void String2DayOfWeekTest()
        {
            Assert.AreEqual(DayOfWeek.Monday, DateTimeUtil.String2DayOfWeek("月"));
            Assert.AreEqual(DayOfWeek.Tuesday, DateTimeUtil.String2DayOfWeek("火"));
            Assert.AreEqual(DayOfWeek.Wednesday, DateTimeUtil.String2DayOfWeek("水"));
            Assert.AreEqual(DayOfWeek.Thursday, DateTimeUtil.String2DayOfWeek("木"));
            Assert.AreEqual(DayOfWeek.Friday, DateTimeUtil.String2DayOfWeek("金"));
            Assert.AreEqual(DayOfWeek.Saturday, DateTimeUtil.String2DayOfWeek("土"));
            Assert.AreEqual(DayOfWeek.Sunday, DateTimeUtil.String2DayOfWeek("日"));
            Assert.AreEqual(DayOfWeek.Monday, DateTimeUtil.String2DayOfWeek("月曜日"));
            Assert.AreEqual(null, DateTimeUtil.String2DayOfWeek(""));
            Assert.AreEqual(null, DateTimeUtil.String2DayOfWeek("ああああ"));
        }
        #endregion
    }
    #endregion
}