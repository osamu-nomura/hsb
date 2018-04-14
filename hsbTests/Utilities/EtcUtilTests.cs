using hsb.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace hsbTests.Utilities.Tests
{
    #region 【class : EtcUtilTests】
    /// <summary>
    /// EtcUtil Test Class
    /// </summary>
    [TestClass()]
    public class EtcUtilTests
    {
        #region - SafeExecuteTest
        /// <summary>
        /// Test of SafeExecuteTest
        /// </summary>
        [TestMethod()]
        public void SafeExecuteTest()
        {
            int n = 0;
            Assert.IsTrue(EtcUtil.SafeExecute(() => { n = (int)10.0; }) == null);
            Assert.IsTrue(EtcUtil.SafeExecute(() => { n = n / 0; }) is Exception);
        }
        #endregion

        #region - ValueIfTest
        /// <summary>
        /// Test of ValueIf
        /// </summary>
        [TestMethod()]
        public void ValueIfTest()
        {
            Assert.AreEqual(100, EtcUtil.ValueIf(100, n => n >= 100, 10));
            Assert.AreEqual(100, EtcUtil.ValueIf(10, n => n >= 100, 100));
        }
        #endregion
    }
    #endregion
}
