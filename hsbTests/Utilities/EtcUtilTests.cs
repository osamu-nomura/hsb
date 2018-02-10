using hsb.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace hsbTests.Utilities
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
    }
    #endregion
}
