using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using hsb.Classes;

namespace hsb.Utilities.Tests
{
    #region 【Test Class : EnumUtilTests】
    /// <summary>
    /// EnumUtilクラスのテスト
    /// </summary>
    [TestClass()]
    public class EnumUtilTests
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
            var list = EnumUtil.GetEnumList<TestGender>();
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