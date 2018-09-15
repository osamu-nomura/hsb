using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Utilities.Tests
{
    #region 【Test Class : MapStringTests】
    [TestClass()]
    public class MapStringTests
    {
        #region - ConvertTest 
        /// <summary>
        /// Test of Convert
        /// </summary>
        [TestMethod()]
        public void ConvertTest()
        {
            Assert.AreEqual("あいうえお", MapString.Convert("アイウエオ", MapString.MapFlags.LCMAP_HIRAGANA));
            Assert.AreEqual("アイウエオ", MapString.Convert("あいうえお", MapString.MapFlags.LCMAP_KATAKANA));
        }
        #endregion

        #region - Han2ZenTest
        /// <summary>
        /// Test of Han2Zen
        /// </summary>
        [TestMethod()]
        public void Han2ZenTest()
        {
            Assert.AreEqual("アイウエオ", MapString.Han2Zen("ｱｲｳｴｵ"));
            Assert.AreEqual("ＡＢＣＤＥ", MapString.Han2Zen("ABCDE"));
        }
        #endregion

        #region - Zen2HanTest
        /// <summary>
        /// Test of Zen2Han
        /// </summary>
        [TestMethod()]
        public void Zen2HanTest()
        {
            Assert.AreEqual("ｱｲｳｴｵ", MapString.Zen2Han("アイウエオ"));
            Assert.AreEqual("あいうえお", MapString.Zen2Han("あいうえお"));
            Assert.AreEqual("ABCDE", MapString.Zen2Han("ＡＢＣＤＥ"));
        }
        #endregion

        #region - ZenHirakana2ZenKatakana
        /// <summary>
        /// Test of ZenHirakana2ZenKatakana
        /// </summary>
        [TestMethod()]
        public void ZenHirakana2ZenKatakanaTest()
        {
            Assert.AreEqual("アイウエオ", MapString.ZenHirakana2ZenKatakana("アイウエオ"));
            Assert.AreEqual("アイウエオ", MapString.ZenHirakana2ZenKatakana("あいうえお"));
            Assert.AreEqual("ABCDE", MapString.ZenHirakana2ZenKatakana("ABCDE"));
            Assert.AreEqual("ｱｲｳｴｵ", MapString.ZenHirakana2ZenKatakana("ｱｲｳｴｵ"));
        }
        #endregion

    }
    #endregion
}