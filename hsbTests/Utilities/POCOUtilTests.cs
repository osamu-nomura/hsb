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

        #region 【Class Poco2】
        class Poco2
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime? CreatedAt { get; set; }
            public Poco2 Child { get; set; }
            public Poco2[] Children { get; set; }
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

        #region - ToDictionaryTest
        /// <summary>
        /// Test of ToDictionary
        /// </summary>
        [TestMethod()]
        public void ToDictionaryTest()
        {
            var dt = DateTime.Now;
            var poco = new Poco2 { Id = 100, Name = "Poco", CreatedAt = dt };
            poco.Child = new Poco2 { Id = 1001, Name = "Poco Child", CreatedAt = dt };
            poco.Children = new Poco2[]
            {
                new Poco2 { Id = 1002, Name = "Poco Children(1)", CreatedAt = dt },
                new Poco2 { Id = 1003, Name = "Poco Children(2)", CreatedAt = dt },
                null
            };

            var dict = POCOUtil.ToDictionary(poco);
            Assert.AreEqual(dict["Id"].Value, 100);
            Assert.AreEqual(dict["Name"].Value, "Poco");
            Assert.AreEqual(dict["CreatedAt"].Value, dt);

            var child = dict["Child"].Value as Dictionary<string, POCOUtil.ValueData>;
            Assert.AreEqual(child["Id"].Value, 1001);
            Assert.AreEqual(child["Name"].Value, "Poco Child");
            Assert.AreEqual(child["CreatedAt"].Value, dt);
            Assert.AreEqual(child["Child"].Value, null);
            Assert.AreEqual((child["Children"].Value as List<object>).Count, 0);

            var children = dict["Children"].Value as List<object>;
            var children1 = children[0] as Dictionary<string, POCOUtil.ValueData>;
            Assert.AreEqual(children1["Id"].Value, 1002);
            Assert.AreEqual(children1["Name"].Value, "Poco Children(1)");
            Assert.AreEqual(children1["CreatedAt"].Value, dt);
            Assert.AreEqual(children1["Child"].Value, null);
            Assert.AreEqual((children1["Children"].Value as List<object>).Count, 0);
            var children2 = children[1] as Dictionary<string, POCOUtil.ValueData>;
            Assert.AreEqual(children2["Id"].Value, 1003);
            Assert.AreEqual(children2["Name"].Value, "Poco Children(2)");
            Assert.AreEqual(children2["CreatedAt"].Value, dt);
            Assert.AreEqual(children2["Child"].Value, null);
            Assert.AreEqual((children2["Children"].Value as List<object>).Count, 0);
            Assert.AreEqual(children[2], null);
        }
        #endregion

    }
    #endregion
}