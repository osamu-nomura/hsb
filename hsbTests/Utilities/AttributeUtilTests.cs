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

        #region - GetFieldDisplayNameTest
        /// <summary>
        /// Test of GetFieldDisplayName
        /// </summary>
        [TestMethod()]
        public void GetFieldDisplayNameTest()
        {
            Assert.AreEqual("不明", AttributeUtil.GetFieldDisplayName(TestGender.Unknown));
            Assert.AreEqual("男性", AttributeUtil.GetFieldDisplayName(TestGender.Male));
            Assert.AreEqual("女性", AttributeUtil.GetFieldDisplayName(TestGender.Female));
            Assert.AreEqual("Unisex", AttributeUtil.GetFieldDisplayName(TestGender.Unisex));
        }
        #endregion

    }
    #endregion
}