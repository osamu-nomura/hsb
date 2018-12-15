using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Extensions.Tests
{
    #region 【Test Class : RandomExTests】
    /// <summary>
    /// RandomExのテスト絡子
    /// </summary>
    [TestClass()]
    public class RandomExTests
    {
        #region - NextBoolTest 
        /// <summary>
        /// Test of NextBool
        /// </summary>
        [TestMethod()]
        public void NextBoolTest()
        {
            var r = new Random();
            var ret = r.NextBool();
            Assert.IsTrue(ret || !ret);
        }
        #endregion

        #region - SequenceTest
        /// <summary>
        /// Test of Sequence
        /// </summary>
        [TestMethod()]
        public void SequenceTest()
        {
            var r = new Random();
            var list = r.Sequence(0, 100, 10).ToList();
            Assert.IsTrue(list.Count == 10);
            list.ForEach(n =>
            {
                Assert.IsTrue(n >= 0 && n < 100);
            });

            Assert.IsTrue(r.Sequence(0, 100).Take(5).ToList().Count == 5);
        }
        #endregion

        #region - SequenceDoubleTest
        /// <summary>
        /// Test of SequenceDouble
        /// </summary>
        [TestMethod()]
        public void SequenceDoubleTest()
        {
            var r = new Random();
            var list = r.SequenceDouble(10).ToList();
            Assert.IsTrue(list.Count == 10);
            list.ForEach(n =>
            {
                Assert.IsTrue(n >= 0.0 && n < 1.0d);
            });

            Assert.IsTrue(r.SequenceDouble().Take(5).ToList().Count == 5);
        }
        #endregion
    }
    #endregion
}