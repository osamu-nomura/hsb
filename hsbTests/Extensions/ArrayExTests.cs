using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Extensions.Tests
{
    #region 【Test Class : ArrayExTests】
    /// <summary>
    /// ArrayExクラスのテスト
    /// </summary>
    [TestClass()]
    public class ArrayExTests
    {
        #region - GetTest
        /// <summary>
        /// Test of Get
        /// </summary>
        [TestMethod()]
        public void GetTest()
        {
            // Case 1
            Assert.AreEqual(3, (new int[] { 1, 2, 3, 4 }).Get(2, 0));
            Assert.AreEqual(0, (new int[] { 1, 2, 3, 4 }).Get(10, 0));
            Assert.AreEqual(0, (new int[] { 1, 2, 3, 4 }).Get(-1, 0));

            // Case 2
            var source = new DateTime[]
            {
                new DateTime(2017, 3, 1),
                new DateTime(2017, 3, 2),
                new DateTime(2017, 3, 3)
            };
            Assert.AreEqual(new DateTime(2017, 3, 2), source.Get(1, () => new DateTime(2017, 4, 1)));
            Assert.AreEqual(new DateTime(2017, 4, 1), source.Get(10, () => new DateTime(2017, 4, 1)));
            Assert.AreEqual(new DateTime(2017, 4, 1), source.Get(-1, () => new DateTime(2017, 4, 1)));
        }
        #endregion
    }
    #endregion
}