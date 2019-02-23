using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Utilities.Tests
{
    #region 【Test Class : CalculatorUtil】
    /// <summary>
    /// CalculatorUtilのテスト
    /// </summary>
    [TestClass()]
    public class CalculatorUtilTests
    {
        #region - CalculateTest
        /// <summary>
        /// Test of Calculate
        /// </summary>
        [TestMethod()]
        public void CalculateTest()
        {
            Assert.AreEqual(CalculatorUtil.Calculate<int>("(3 + 4) * 2"), 14);
            Assert.AreEqual(CalculatorUtil.Calculate<int>("2 * (3 + 4) - 4"), 10);
            Assert.AreEqual(CalculatorUtil.Calculate<int>("-2 + 4") * -3, -6);
            Assert.AreEqual(CalculatorUtil.Calculate<double>("(2.5-0.1)/2.0"), 1.2d);
            Assert.AreEqual(CalculatorUtil.Calculate<decimal>("((2+3) * 4 + 5) / 2"), 12.5m);
        }
        #endregion
    }
    #endregion
}