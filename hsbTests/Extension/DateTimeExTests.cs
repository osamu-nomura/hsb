using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Extension.Tests
{
    #region 【Class : DateTimeExTests】
    /// <summary>
    /// DateTimeExのテストクラス
    /// </summary>
    [TestClass()]
    public class DateTimeExTests
    {
        #region - BeginOfMonthTest
        /// <summary>
        /// Test for BeginOfMonth
        /// </summary>
        [TestMethod()]
        public void BeginOfMonthTest()
        {
            var dt = new DateTime(2017, 1, 28);
            var expected = new DateTime(2017, 1, 1);
            Assert.AreEqual(expected, dt.BeginOfMonth());
        }
        #endregion
    }
    #endregion
}