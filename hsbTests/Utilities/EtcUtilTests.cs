﻿using hsb.Utilities;
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
            Assert.IsTrue(EtcUtil.SafeExecute(() => { n = n / 0; }) is DivideByZeroException);

            var t1 = EtcUtil.SafeExecute(() => 10 / 10);
            Assert.IsTrue(t1.Value == 1 && t1.E == null);
            var t2 = EtcUtil.SafeExecute(() => n / 0);
            Assert.IsTrue(t2.Value == 0 && t2.E is DivideByZeroException);

            var t3 = EtcUtil.SafeExecute((p) => p / 10, 100);
            Assert.IsTrue(t3.Value == 10 && t3.E == null);
            var t4 = EtcUtil.SafeExecute((p) => p / 0, 100);
            Assert.IsTrue(t4.Value == 0 && t4.E is DivideByZeroException);

            var t5 = EtcUtil.SafeExecute((p1, p2) => p1 / p2, 100, 10);
            Assert.IsTrue(t5.Value == 10 && t5.E == null);
            var t6 = EtcUtil.SafeExecute((p1, p2) => p1 / p2, 100, 0);
            Assert.IsTrue(t6.Value == 0 && t6.E is DivideByZeroException);

        }
        #endregion

        #region - SafeEvaluateTest
        /// <summary>
        /// Test of SafeEvaluate
        /// </summary>
        [TestMethod()]
        public void SafeEvaluateTest()
        {
            var n = 100;            var ret = EtcUtil.SafeEvaluate(() => n / 10, () => n);
            Assert.AreEqual(10, EtcUtil.SafeEvaluate(() => n / 10, () => n));
            Assert.AreEqual(n, EtcUtil.SafeEvaluate(() => n / 0, () => n));
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
