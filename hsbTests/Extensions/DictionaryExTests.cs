using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Extensions.Tests
{
    #region 【Test Class : DictionaryExTests】
    /// <summary>
    /// DictionaryExクラスのテスト
    /// </summary>
    [TestClass()]
    public class DictionaryExTests
    {
        #region - GetTest
        /// <summary>
        /// Test of Get
        /// </summary>
        [TestMethod()]
        public void GetTest()
        {
            // Case 1
            var source1 = new Dictionary<string, int>
            {
                { "key1", 100 },
                { "key2", 200 },
                { "key3", 300 }
            };
            Assert.AreEqual(200, source1.Get("key2", 900));
            Assert.AreEqual(900, source1.Get("key9", 900));
            Assert.AreEqual(900, source1.Get("", 900));

            // Case 2
            var source2 = new Dictionary<string, DateTime>
            {
                { "key1", new DateTime(2017, 3, 1) },
                { "key2", new DateTime(2017, 3, 2) },
                { "key3", new DateTime(2017, 3, 3) }
            };
            Assert.AreEqual(new DateTime(2017, 3, 2), source2.Get("key2", () => new DateTime(2017, 4, 1)));
            Assert.AreEqual(new DateTime(2017, 4, 1), source2.Get("key9", () => new DateTime(2017, 4, 1)));
            Assert.AreEqual(new DateTime(2017, 4, 1), source2.Get("", () => new DateTime(2017, 4, 1)));
        }
        #endregion

        #region - GetOrAddTest
        /// <summary>
        /// Test of GetOrAdd
        /// </summary>
        [TestMethod()]
        public void GetOrAddTest()
        {
            var source = new Dictionary<string, int>
            {
                { "key1", 100 },
                { "key2", 200 },
                { "key3", 300 }
            };
            Assert.AreEqual(200, source.GetOrAdd("key2", () => 900));
            Assert.AreEqual(900, source.GetOrAdd("key9", () => 900));
            Assert.IsTrue(source.ContainsKey("key9"));
        }
        #endregion
    }
    #endregion
}