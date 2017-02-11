using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Extensions.Tests
{
    #region 【Class : LsitExTests】
    [TestClass()]
    public class LsitExTests
    {
        #region - AddTest
        /// <summary>
        /// Test og Add
        /// </summary>
        [TestMethod()]
        public void AddTest()
        {
            var source = new List<int> { 1, 2, 3 };
            source.Add(4, 5, 6);
            var expected = new List<int> { 1, 2, 3, 4, 5, 6 };
            Assert.IsTrue(source.SequenceEqual(expected));
        }
        #endregion
    }
    #endregion
}