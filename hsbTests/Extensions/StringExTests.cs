using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Extensions.Tests
{
    #region 【Class : StringExTests】
    [TestClass()]
    public class StringExTests
    {
        #region - ToIntTest
        /// <summary>
        /// Test of ToInt
        /// </summary>
        [TestMethod()]
        public void ToIntTest()
        {
            Assert.AreEqual(1, "1".ToInt());
            Assert.AreEqual(0, "0".ToInt());
            Assert.AreEqual(-1, "-1".ToInt());
            Assert.AreEqual(null, "a".ToInt());
        }
        #endregion

        #region - ToDoubleTest
        /// <summary>
        /// Test of ToDouble
        /// </summary>
        [TestMethod()]
        public void ToDoubleTest()
        {
            Assert.AreEqual(1.2d, "1.2".ToDouble());
            Assert.AreEqual(0.0d, "0".ToDouble());
            Assert.AreEqual(-1.2d, "-1.2".ToDouble());
            Assert.AreEqual(null, "a".ToDouble());
        }
        #endregion

        #region - ToDecimalTest
        /// <summary>
        /// Test of ToDecimal
        /// </summary>
        [TestMethod()]
        public void ToDecimalTest()
        {
            Assert.AreEqual(1.2m, "1.2".ToDecimal());
            Assert.AreEqual(0m, "0".ToDecimal());
            Assert.AreEqual(-1.2m, "-1.2".ToDecimal());
            Assert.AreEqual(null, "s".ToDecimal());
        }
        #endregion

        #region - ToDateTimeTest
        /// <summary>
        /// Test of ToDateTime
        /// </summary>
        [TestMethod()]
        public void ToDateTimeTest()
        {
            Assert.AreEqual(new DateTime(2017, 2, 4), "2017/02/04".ToDateTime());
            Assert.AreEqual(new DateTime(2017, 2, 4), "2017-02-04".ToDateTime());
            Assert.AreEqual(new DateTime(2017, 2, 4), "2017年02月04日".ToDateTime());
            Assert.AreEqual(new DateTime(2017, 2, 4), "2017/2/4".ToDateTime());
            Assert.AreEqual(new DateTime(2017, 2, 4), "2017-2-4".ToDateTime());
            Assert.AreEqual(new DateTime(2017, 2, 4), "2017年2月4日".ToDateTime());
            Assert.AreEqual(new DateTime(2017, 2, 4, 11, 20, 30), "2017/02/04 11:20:30".ToDateTime());
            Assert.AreEqual(null, "2017/02/29".ToDateTime());
        }
        #endregion

        #region - MapStringTest
        /// <summary>
        /// Test of MapString
        /// </summary>
        [TestMethod()]
        public void MapStringTest()
        {
            Assert.AreEqual("アイウエオ", "あいうえお".MapString(Types.MapStringFlags.LCMAP_KATAKANA));
            Assert.AreEqual("ABCDEF", "ＡＢＣＤＥＦ".MapString(Types.MapStringFlags.LCMAP_HALFWIDTH));
        }
        #endregion

        #region - ToFullWidthTest
        /// <summary>
        /// Test of ToFullWidth
        /// </summary>
        [TestMethod()]
        public void ToFullWidthTest()
        {
            Assert.AreEqual("ＡＢＣｄｅｆ", "ABCdef".ToFullWidth());
            Assert.AreEqual("アイウ０１２", "ｱｲｳ012".ToFullWidth());
        }
        #endregion

        #region - ToHalfWidthTest
        /// <summary>
        /// Test of ToHalfWidth
        /// </summary>
        [TestMethod()]
        public void ToHalfWidthTest()
        {
            Assert.AreEqual("ABCdef", "ＡＢＣｄｅｆ".ToHalfWidth());
            Assert.AreEqual("ｱｲｳあいう012", "アイウあいう０１２".ToHalfWidth());
        }
        #endregion
    }
    #endregion
}