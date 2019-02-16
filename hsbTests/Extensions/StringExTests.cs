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

        #region - IsValidMailAddressTest
        /// <summary>
        /// Test of IsValidMailAddressTest
        /// </summary>
        [TestMethod()]
        public void IsValidMailAddressTest()
        {
            Assert.IsTrue("foo@bar.com".IsValidMailAddress());
            Assert.IsFalse("aaaaa".IsValidMailAddress());
            Assert.IsFalse("foo@@bar.com".IsValidMailAddress());
            Assert.IsFalse("@bar".IsValidMailAddress());
        }
        #endregion

        #region - TextElementsTest
        /// <summary>
        /// Test of ToTextElements
        /// </summary>
        [TestMethod()]
        public void TextElementsTest()
        {
            var s = "あ𠀋い";
            var elements = s.TextElements().ToList();
            Assert.IsTrue(elements?.Count == 3);
            Assert.IsTrue(elements[1] == "𠀋");
        }
        #endregion

        #region - TranslateTest
        /// <summary>
        /// Test of Translate
        /// </summary>
        [TestMethod()]
        public void TranslateTest()
        {
            // Test1
            var s = "あ𠀋い";
            var inTable = new string[] { "あ", "𠀋" };
            var outTable = new string[] { "ア", "丈" };
            Assert.IsTrue(s.Translate(inTable, outTable) == "ア丈い");

            // Test2
            Assert.IsTrue(s.Translate(inTable) == "い");

            // Test3
            Assert.IsTrue(s.Translate("あ𠀋", "ア丈") == "ア丈い");

            // Test4
            Assert.IsTrue(s.Translate("あ𠀋") == "い");
        }
        #endregion

        #region - ReplaceCrLfTest
        /// <summary>
        /// Test of ReplaceCrLf
        /// </summary>
        [TestMethod()]
        public void ReplaceCrLfTest()
        {
            var s = "AAA\r\nBBB\rCCC\n";
            Assert.AreEqual("AAA<br>BBB<br>CCC<br>", s.ReplaceCrLf("<br>"));
            Assert.AreEqual("AAABBBCCC", s.ReplaceCrLf());
            Assert.AreEqual(null, ((string)null).ReplaceCrLf("<br>"));
            Assert.AreEqual("", "".ReplaceCrLf("<br>"));
        }
        #endregion

        #region - OmissionTest
        /// <summary>
        /// Test of Omission
        /// </summary>
        [TestMethod()]
        public void OmissionTest()
        {
            Assert.AreEqual("12345", "12345".Omission(5));
            Assert.AreEqual("123", "123".Omission(5));
            Assert.AreEqual("1234…", "123456".Omission(5));
            Assert.AreEqual("12345", "123456".Omission(5, ""));
        }
        #endregion

        #region - ToBase64StringTest
        /// <summary>
        /// Test of ToBase64String
        /// </summary>
        [TestMethod()]
        public void ToBase64StringTest()
        {
            Assert.AreEqual("HOGE FUGA".ToBase64String(), "SE9HRSBGVUdB");
        }
        #endregion

        #region - ToDecodeBase64StringTest
        /// <summary>
        /// Test of ToDecodeBase64String
        /// </summary>
        [TestMethod()]
        public void ToDecodeBase64StringTest()
        {
            var decoded = Encoding.UTF8.GetString("SE9HRSBGVUdB".DecodeBase64String());
            Assert.AreEqual("HOGE FUGA", decoded);
        }
        #endregion

        #region - ToBase64UrlStringTest
        /// <summary>
        /// Test of ToBase64UrlString
        /// </summary>
        [TestMethod()]
        public void ToBase64UrlStringTest()
        {
            Assert.AreEqual("HOGE FUGA AAA".ToBase64UrlString(), "SE9HRSBGVUdBIEFBQQ");
        }
        #endregion

        #region - ToDecodeBase64UrlStringTest
        /// <summary>
        /// Test of ToDecodeBase64UrlString
        /// </summary>
        [TestMethod()]
        public void ToDecodeBase64UrlStringTest()
        {
            var decoded = Encoding.UTF8.GetString("SE9HRSBGVUdBIEFBQQ".DecodeBase64UrlString());
            Assert.AreEqual("HOGE FUGA AAA", decoded);
        }
        #endregion

        #region - ToZenkakuKatakanaTest
        /// <summary>
        /// Test of ToZenkakuKatakana
        /// </summary>
        [TestMethod]
        public void ToZenkakuKatakanaTest()
        {
            Assert.AreEqual("ｳﾞｪﾙｻｲﾕ宮殿".ToZenkakuKatakana(), "ヴェルサイユ宮殿");
            Assert.AreEqual("｢ﾊﾝｶｸ｣､".ToZenkakuKatakana(), "「ハンカク」、");
        }
        #endregion

        #region - ToHankakuAlphaNumTest
        /// <summary>
        /// Test of ToHankakuAlphaNum
        /// </summary>
        [TestMethod]
        public void ToHankakuAlphaNumTest()
        {
            Assert.AreEqual("０１２３４５６７８９アアア．：".ToHankakuAlphaNum(), "0123456789アアア．：");
            Assert.AreEqual("ＡＢＣＤＥＦＧ　ｈｉｊｋｌｍｎ".ToHankakuAlphaNum(), "ABCDEFG　hijklmn");
        }
        #endregion

        #region - ToHankakuAlphaNumSymbolTest
        /// <summary>
        /// Test of ToHankakuAlphaNumSymbol
        /// </summary>
        [TestMethod]
        public void ToHankakuAlphaNumSymbolTest()
        {
            Assert.AreEqual("０１２３４５６７８９アアア．：".ToHankakuAlphaNumSymbol(), "0123456789アアア.:");
            Assert.AreEqual("ＡＢＣＤＥＦＧ　ｈｉｊｋｌｍｎ".ToHankakuAlphaNumSymbol(), "ABCDEFG hijklmn");
        }
        #endregion
    }
    #endregion
}