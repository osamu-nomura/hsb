using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hsb.Types;

namespace hsb.Extensions.Tests
{
    #region 【Class : MonthExTests】
    /// <summary>
    /// MonthExのテストクラス
    /// </summary>
    [TestClass()]
    public class MonthExTests
    {
        #region - AddTest
        /// <summary>
        /// Test of Add()
        /// </summary>
        [TestMethod()]
        public void AddTest()
        {
            Assert.AreEqual(Month.March, Month.January.Add(2));
            Assert.AreEqual(Month.January, Month.October.Add(3));
            Assert.AreEqual(Month.January, Month.January.Add(0));
            Assert.AreEqual(Month.November, Month.January.Add(-2));
        }
        #endregion
    }
    #endregion
}