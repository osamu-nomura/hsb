using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace hsb.Extensions.Tests
{
    #region 【Test Class : RegexExTests】
    /// <summary>
    /// RegexExクラスのテスト
    /// </summary>
    [TestClass()]
    public class RegexExTests
    {
        #region -  GetGenericEnumeratorTest
        /// <summary>
        /// Test of ToEnumerator
        /// </summary>
        [TestMethod()]
        public void GetGenericEnumeratorTest()
        {
            var reg = new Regex(@"(\d+)");
            var list = reg.Matches("123-456-789").GetGenericEnumerator().Select(m => m.Value).ToList();
            Assert.IsTrue(list.Count == 3);
            Assert.IsTrue(list[0] == "123");
            Assert.IsTrue(list[1] == "456");
            Assert.IsTrue(list[2] == "789");
        }
        #endregion

        #region - ToListTest
        /// <summary>
        /// Test of ToList()
        /// </summary>
        [TestMethod()]
        public void ToListTest()
        {
            var reg = new Regex(@"(\d+)");
            var list = reg.Matches("123-456-789").ToList();
            Assert.IsTrue(list.Count == 3);
            Assert.IsTrue(list[0].Value == "123");
            Assert.IsTrue(list[1].Value == "456");
            Assert.IsTrue(list[2].Value == "789");
        }
        #endregion

        #region - ToListTest
        /// <summary>
        /// Test of ToArray()
        /// </summary>
        [TestMethod()]
        public void ToArrayTest()
        {
            var reg = new Regex(@"(\d+)");
            var array = reg.Matches("123-456-789").ToArray();
            Assert.IsTrue(array.Length == 3);
            Assert.IsTrue(array[0].Value == "123");
            Assert.IsTrue(array[1].Value == "456");
            Assert.IsTrue(array[2].Value == "789");
        }
        #endregion
    }
    #endregion
}