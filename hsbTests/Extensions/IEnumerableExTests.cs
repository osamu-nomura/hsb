using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Extensions.Tests
{
    #region 【Class : IEnumerableExTests】
    [TestClass()]
    public class IEnumerableExTests
    {
        #region - ToStringTest
        /// <summary>
        /// Test of ToString
        /// </summary>
        [TestMethod()]
        public void ToStringTest()
        {
            // Case1
            var source1 = new string[] { "aaa", "bbb", "ccc" };
            Assert.AreEqual("aaa,bbb,ccc", source1.ToString(","));

            // Case2
            var source2 = new int[] { 1000, 2000, 3000 };
            Assert.AreEqual(@"1,000 2,000 3,000", source2.ToString(" ", s => s.ToString("N0")));
        }
        #endregion

        #region - ForEachTest
        /// <summary>
        /// Test of ForEach
        /// </summary>
        [TestMethod()]
        public void ForEachTest()
        {
            var source = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var v = 0;
            source.ForEach(n => v += n);
            Assert.AreEqual(55, v);
        }
        #endregion
    }
    #endregion
}