using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Utilities.Tests
{
    #region 【Static Class : MessageDigestTests】
    /// <summary>
    /// MessageDigestクラスのテスト
    /// </summary>
    [TestClass()]
    public class MessageDigestTests
    {
        #region - CreateDigestTest
        /// <summary>
        /// Test of CreateDigest
        /// </summary>
        [TestMethod()]
        public void CreateDigestTest()
        {
            var source = "abcdefg";
            var expected = "7ac66c0f148de9519b8bd264312c4d64";
            Assert.AreEqual(expected, MD5.CreateDigest(source, Encoding.UTF8));
            Assert.AreEqual(expected, MD5.CreateDigest(source));
        }
        #endregion

        #region - CreateDigestFromFileTest
        /// <summary>
        /// Test of CreateDigestFromFile
        /// </summary>
        [TestMethod()]
        public void CreateDigestFromFileTest()
        {
            var source = "abcdefg";
            var path = System.IO.Path.GetTempFileName();
            System.IO.File.WriteAllText(path, source);
            var expected = "7ac66c0f148de9519b8bd264312c4d64";
            Assert.AreEqual(expected, MD5.CreateDigestFromFile(path));
            System.IO.File.Delete(path);
        }
        #endregion
    }
    #endregion
}