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
    #region 【Test Class ; AttributeUtilTests】
    /// <summary>
    /// ttributeUtilクラスのテスト
    /// </summary>
    [TestClass()]
    public class AttributeUtilTests
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

        class TestClass
        {
            [Display(Name = "フィールド1")]
            public int Field1 = 0;
            [Display(Name = "プロパティ1")]
            public int Property1 { get; set; }
        }

        #region - GetEnumFieldDisplayNameTest
        /// <summary>
        /// Test of GetEnumFieldDisplayName
        /// </summary>
        [TestMethod()]
        public void GetEnumFieldDisplayNameTest()
        {
            Assert.AreEqual("不明", AttributeUtil.GetEnumFieldDisplayName(TestGender.Unknown));
            Assert.AreEqual("男性", AttributeUtil.GetEnumFieldDisplayName(TestGender.Male));
            Assert.AreEqual("女性", AttributeUtil.GetEnumFieldDisplayName(TestGender.Female));
            Assert.AreEqual("Unisex", AttributeUtil.GetEnumFieldDisplayName(TestGender.Unisex));
        }
        #endregion

        #region - GetObjectPropertyDisplayNameTest
        /// <summary>
        /// Test of GetObjectPropertyDisplayName
        /// </summary>
        [TestMethod()]
        public void GetObjectPropertyDisplayNameTest()
        {
            var obj = new TestClass();
            Assert.AreEqual("フィールド1", AttributeUtil.GetObjectPropertyDisplayName(obj, nameof(obj.Field1)));
            Assert.AreEqual("プロパティ1", AttributeUtil.GetObjectPropertyDisplayName(obj, nameof(obj.Property1)));
        }
        #endregion
    }
    #endregion
}