using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Utilities.Tests
{
    #region 【Test Class : POCOUtilTests】
    /// <summary>
    /// POCOUtilクラスのテスト
    /// </summary>
    [TestClass()]
    public class POCOUtilTests
    {
        #region 【Class Poco】
        class Poco
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime? CreatedAt { get; set; }
            public int[] Numbers { get; set; }
        }
        #endregion

        #region - WalkthroughTest
        /// <summary>
        /// Test of Walkthrough
        /// </summary>
        [TestMethod()]
        public void WalkthroughTest()
        {
            var dt = DateTime.Now;
            var poco = new Poco { Id = 100, Name = "Poco", CreatedAt = dt, Numbers = new int[] { 1, 2, 3 } };
            var values = POCOUtil.Walkthrough(poco).ToList();

            Assert.AreEqual(values[0].Name, "Id");
            Assert.AreEqual(values[0].Value, 100);
            Assert.AreEqual(values[1].Name, "Name");
            Assert.AreEqual(values[1].Value, "Poco");
            Assert.AreEqual(values[2].Name, "CreatedAt");
            Assert.AreEqual(values[2].Value, dt);
            Assert.AreEqual(values[3].Name, "Numbers");

            var numbers = (values[3].Value as List<object>).Select(o => (int)o).ToArray();
            Assert.IsTrue(numbers.SequenceEqual(new int[] { 1, 2, 3 }));

        }
        #endregion
    }
    #endregion
}