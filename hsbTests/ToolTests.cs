using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using hsb.Classes;

namespace hsb.Tests
{
    // TEST用ENUM定義
    enum TestGender
    {
        [Display(Name = "不明")]
        Unknown,
        [Display(Name = "男性")]
        Male,
        [Display(Name = "女性")]
        Female,
        Unisex
    }

    #region 【Class : ToolTests】
    /// <summary>
    /// Toolクラスのテスト
    /// </summary>
    [TestClass()]
    public class ToolTests
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
            foreach (var s in Tool.Enumerator("aaa", "bbb", "ccc"))
            {
                Assert.AreEqual(expected[i++], s);
            }
            Assert.AreEqual(i, 3);
        }
        #endregion

        #region - GetFieldDisplayNameTest
        /// <summary>
        /// Test of GetFieldDisplayName
        /// </summary>
        [TestMethod()]
        public void GetFieldDisplayNameTest()
        {
            Assert.AreEqual("不明", Tool.GetFieldDisplayName(TestGender.Unknown));
            Assert.AreEqual("男性", Tool.GetFieldDisplayName(TestGender.Male));
            Assert.AreEqual("女性", Tool.GetFieldDisplayName(TestGender.Female));
            Assert.AreEqual("Unisex", Tool.GetFieldDisplayName(TestGender.Unisex));
        }
        #endregion

        #region - GetEnumListTest
        /// <summary>
        /// Test of GetEnumList
        /// </summary>
        [TestMethod()]
        public void GetEnumListTest()
        {
            var expected = new List<ValueWithName<TestGender>>
            {
                new ValueWithName<TestGender>(TestGender.Unknown, "不明"),
                new ValueWithName<TestGender>(TestGender.Male, "男性"),
                new ValueWithName<TestGender>(TestGender.Female, "女性"),
                new ValueWithName<TestGender>(TestGender.Unisex, "Unisex")
            };
            var list = Tool.GetEnumList<TestGender>();
            Assert.AreEqual(expected.Count, list?.Count ?? 0, "リストの件数が不一致");
            for (var i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Value, list[i].Value);
                Assert.AreEqual(expected[i].Name, list[i].Name);
            }
        }
        #endregion
    }
    #endregion
}