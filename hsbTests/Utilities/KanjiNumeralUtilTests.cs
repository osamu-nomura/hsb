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
    #region 【Test Class : KanjiNumeralUtilTests】
    /// <summary>
    /// KanjiNumeralUtilクラスのテスト
    /// </summary>
    [TestClass]
    public class KanjiNumeralUtilTests
    {
        #region - ConvertTest
        /// <summary>
        /// Test of Convert
        /// </summary>
        [TestMethod()]
        public void ConvertTest()
        {
            Assert.IsTrue(KanjiNumeralUtil.Convert("五億六千万三千二百五十六") == 560003256L);
            Assert.IsTrue(KanjiNumeralUtil.Convert("５億６千万３千２５６") == 560003256L);
            Assert.IsTrue(KanjiNumeralUtil.Convert("百十") == 110L);
            Assert.IsTrue(KanjiNumeralUtil.Convert("弐拾万") == 200000L);
            Assert.IsTrue(KanjiNumeralUtil.Convert("400万") == 4000000L);
        }
        #endregion

        #region - ReplaceTest
        /// <summary>
        /// Test of Replace
        /// </summary>
        [TestMethod()]
        public void ReplaceTest()
        {
            Assert.IsTrue(KanjiNumeralUtil.Replace("九月二十二日") == "9月22日");
            Assert.IsTrue(KanjiNumeralUtil.Replace("十二人で五万六千円", "#,##0") == "12人で56,000円");
        }
        #endregion
    }
    #endregion
}
