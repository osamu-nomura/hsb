using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Tests
{
    #region 【Class : ToolTests】
    /// <summary>
    /// Toolクラスのテスト
    /// </summary>
    [TestClass()]
    public class ToolTests
    {
        #region - EnumeratorTest
        /// <summary>
        /// Test of Enumerator
        /// </summary>
        [TestMethod()]
        public void EnumeratorTest()
        {
            var expected = new string[] { "aaa", "bbb", "ccc" };
            var i = 0;
            foreach (var s in Tool.Enumerator("aaa", "bbb", "ccc"))
            {
                Assert.AreEqual(expected[i++], s);
            }
            Assert.AreEqual(i, 3);
        }
        #endregion
    }
    #endregion
}