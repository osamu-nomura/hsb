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

        #region - FillTest 
        /// <summary>
        /// Test of Fill
        /// </summary>
        [TestMethod()]
        public void FillTest()
        {
            // CASE1
            var expected1 = new List<int> { 1, 1, 1, 1, 1 };
            Assert.IsTrue(expected1.SequenceEqual(EnumerableUtil.Fill(1, 5)));
            var expected2 = new List<string> { "a", "a", "a", "a", "a" };
            Assert.IsTrue(expected2.SequenceEqual(EnumerableUtil.Fill("a", 5)));

            // CASE2
            var today = DateTime.Today;
            var expected3 = new List<DateTime>
            {
                today,
                today.AddDays(1),
                today.AddDays(2),
                today.AddDays(3),
                today.AddDays(4)
            };
            Assert.IsTrue(expected3.SequenceEqual(EnumerableUtil.Fill(n => today.AddDays(n), 5)));
        }
        #endregion
    }
    #endregion
}