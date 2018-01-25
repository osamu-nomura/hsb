using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Utilities.Tests
{
    #region 【Test Class : EnumerableUtilTests】
    /// <summary>
    /// EnumerableUtilクラスのテスト
    /// </summary>
    [TestClass()]
    public class EnumerableUtilTests
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
            foreach (var s in EnumerableUtil.Enumerator("aaa", "bbb", "ccc"))
            {
                Assert.AreEqual(expected[i++], s);
            }
            Assert.AreEqual(i, 3);
        }
        #endregion

        #region - RepeatTest 
        /// <summary>
        /// Test of Repeat
        /// </summary>
        [TestMethod()]
        public void RepeatTest()
        {
            // CASE1
            var today = DateTime.Today;
            var expected = new List<DateTime>
            {
                today,
                today.AddDays(1),
                today.AddDays(2),
                today.AddDays(3),
                today.AddDays(4)
            };
            Assert.IsTrue(expected.SequenceEqual(EnumerableUtil.Repeat(n => today.AddDays(n), 5)));
        }
        #endregion
    }
    #endregion
}