using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
    #endregion
}