using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hsb.Extensions;

namespace hsb.Classes.Tests
{
    #region 【Class : ProbabilityTests】
    /// <summary>
    /// Probabilityクラスのテスト
    /// </summary>
    [TestClass()]
    public class ProbabilityTests
    {
        #region - NextTest
        /// <summary>
        /// Test of Next
        /// </summary>
        [TestMethod()]
        public void NextTest()
        {
            var p = new Probability<string>(
                new (string item, int ratio)[] {
                    ("a", 50), ("b", 30), ("c", 20)
                });
            var d = new Dictionary<string, int>();
            d.Add("a", 0);
            d.Add("b", 0);
            d.Add("c", 0);
            Enumerable.Range(0, 1000).ForEach(n =>
            {
                var s = p.Next();
                d[s] += 1;
            });
            Assert.IsTrue(true);
        }
        #endregion

        #region - GetValueTest
        /// <summary>
        /// Test of GetValue
        /// </summary>
        [TestMethod()]
        public void GetValueTest()
        {
            var ret = Probability<bool>.GetValue(new (bool item, int ratio)[]
            {
                (true, 50), (false, 50)
            });
            Assert.IsTrue(true);
        }
        #endregion
    }
    #endregion
}