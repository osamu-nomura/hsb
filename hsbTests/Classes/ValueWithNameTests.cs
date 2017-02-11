using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Utils.Tests
{
    #region 【Class : ValueWithNameTests】
    /// <summary>
    /// ValueWithNameクラスのテスト
    /// </summary>
    [TestClass()]
    public class ValueWithNameTests
    {
        #region - EqualsTest
        /// <summary>
        /// Test of Equals
        /// </summary>
        [TestMethod()]
        public void EqualsTest()
        {
            Assert.IsTrue(new ValueWithName<int>(1, "one1").Equals(new ValueWithName<int>(1, "one2")));
            Assert.IsTrue(new ValueWithName<int>(1, "one").Equals(1));
            Assert.IsFalse(new ValueWithName<int>(1, "one").Equals(new ValueWithName<int>(2, "two")));
            Assert.IsFalse(new ValueWithName<int>(1, "one").Equals(2));
            Assert.IsFalse(new ValueWithName<int>(1, "one").Equals(null));
        }
        #endregion

        #region - GetHashCodeTest
        /// <summary>
        /// Test of GetHashCode
        /// </summary>
        [TestMethod()]
        public void GetHashCodeTest()
        {
            Assert.IsTrue(new ValueWithName<int>(1, "one").GetHashCode() == 1.GetHashCode());
        }
        #endregion

        #region - CompareToTest
        /// <summary>
        /// Test of CompareTo
        /// </summary>
        [TestMethod()]
        public void CompareToTest()
        {
            Assert.AreEqual(-1, new ValueWithName<int>(1, "one").CompareTo(new ValueWithName<int>(2, "two")));
            Assert.AreEqual(0, new ValueWithName<int>(1, "one1").CompareTo(new ValueWithName<int>(1, "one2")));
            Assert.AreEqual(1, new ValueWithName<int>(3, "three").CompareTo(new ValueWithName<int>(2, "two")));
            try
            {
                new ValueWithName<int>(3, "three").CompareTo(null);
            }
            catch (ArgumentNullException)
            {
                return;
            }
            Assert.Fail("例外が発生しなかった。");
        }
        #endregion

        #region - ToStringTest
        /// <summary>
        /// Test of ToString
        /// </summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("one", new ValueWithName<int>(1, "one").ToString());
            Assert.AreEqual("1", new ValueWithName<int>(1, null).ToString());
        }
        #endregion

        #region - OpEqTest
        /// <summary>
        /// Test of op equal
        /// </summary>
        [TestMethod()]
        public void OpEqTest()
        {
            Assert.IsTrue(new ValueWithName<int>(1, "one1") == new ValueWithName<int>(1, "one2"));
            Assert.IsTrue(new ValueWithName<int>(1, "one") == 1);
            Assert.IsTrue(1 == new ValueWithName<int>(1, "one"));
            Assert.IsFalse(new ValueWithName<int>(1, "one") == new ValueWithName<int>(2, "two"));
            Assert.IsFalse(new ValueWithName<int>(1, "one") == 2);
            Assert.IsFalse(1 == new ValueWithName<int>(2, "two"));
            Assert.IsFalse(new ValueWithName<int>(1, "one") == null);
            Assert.IsFalse(null == new ValueWithName<int>(2, "two"));
        }
        #endregion

        #region - OpNeqTest
        /// <summary>
        /// Test of op Not equal
        /// </summary>
        [TestMethod()]
        public void OpNeqTest()
        {
            Assert.IsFalse(new ValueWithName<int>(1, "one1") != new ValueWithName<int>(1, "one2"));
            Assert.IsFalse(new ValueWithName<int>(1, "one") != 1);
            Assert.IsFalse(1 != new ValueWithName<int>(1, "one"));
            Assert.IsTrue(new ValueWithName<int>(1, "one") != new ValueWithName<int>(2, "two"));
            Assert.IsTrue(new ValueWithName<int>(1, "one") != 2);
            Assert.IsTrue(1 != new ValueWithName<int>(2, "two"));
            Assert.IsTrue(new ValueWithName<int>(1, "one") != null);
            Assert.IsTrue(null != new ValueWithName<int>(2, "two"));
        }
        #endregion

        #region - OpGtTest
        /// <summary>
        /// Test of Op Grrater than
        /// </summary>
        [TestMethod()]
        public void OpGtTest()
        {
            Assert.IsTrue(new ValueWithName<int>(2, "two") > new ValueWithName<int>(1, "one"));
            Assert.IsTrue(new ValueWithName<int>(2, "two") > 1);
            Assert.IsTrue(2 > new ValueWithName<int>(1, "one"));
            Assert.IsFalse(new ValueWithName<int>(2, "two") > null);
            Assert.IsFalse(null > new ValueWithName<int>(1, "one"));
        }
        #endregion

        #region - OpGteTest
        /// <summary>
        /// Test of Op Greater than equal
        /// </summary>
        [TestMethod()]
        public void OpGteTest()
        {
            Assert.IsTrue(new ValueWithName<int>(1, "one1") >= new ValueWithName<int>(1, "one2"));
            Assert.IsTrue(new ValueWithName<int>(2, "two") >= new ValueWithName<int>(1, "one"));
            Assert.IsTrue(new ValueWithName<int>(1, "one") >= 1);
            Assert.IsTrue(new ValueWithName<int>(2, "two") >= 1);
            Assert.IsTrue(1 >= new ValueWithName<int>(1, "one"));
            Assert.IsTrue(2 >= new ValueWithName<int>(1, "one"));
            Assert.IsFalse(new ValueWithName<int>(1, "one") >= new ValueWithName<int>(2, "two"));
            Assert.IsFalse(new ValueWithName<int>(1, "one") >= 2);
            Assert.IsFalse(1 >= new ValueWithName<int>(2, "two"));
        }
        #endregion

        #region - OpLtTest
        /// <summary>
        /// Test of Op Less than
        /// </summary>
        [TestMethod()]
        public void OpLtTest()
        {
            Assert.IsTrue(new ValueWithName<int>(1, "one") < new ValueWithName<int>(2, "two"));
            Assert.IsTrue(new ValueWithName<int>(1, "one") < 2);
            Assert.IsTrue(1 < new ValueWithName<int>(2, "two"));
            Assert.IsFalse(new ValueWithName<int>(1, "one1") < new ValueWithName<int>(1, "one2"));
            Assert.IsFalse(new ValueWithName<int>(1, "one") < 1);
            Assert.IsFalse(1 < new ValueWithName<int>(1, "one"));
        }
        #endregion

        #region - OpLteTest
        /// <summary>
        /// Test of op Less than equal
        /// </summary>
        [TestMethod()]
        public void OpLteTest()
        {
            Assert.IsTrue(new ValueWithName<int>(1, "one1") <= new ValueWithName<int>(1, "one2"));
            Assert.IsTrue(new ValueWithName<int>(1, "one") <= new ValueWithName<int>(2, "two"));
            Assert.IsTrue(new ValueWithName<int>(1, "one") <= 1);
            Assert.IsTrue(new ValueWithName<int>(1, "one") <= 2);
            Assert.IsTrue(1 <= new ValueWithName<int>(2, "two"));
            Assert.IsTrue(2 <= new ValueWithName<int>(2, "two"));
            Assert.IsFalse(new ValueWithName<int>(2, "two") <= new ValueWithName<int>(1, "one"));
            Assert.IsFalse(new ValueWithName<int>(2, "tow") <= 1);
            Assert.IsFalse(2 <= new ValueWithName<int>(1, "one"));
        }
        #endregion
    }
    #endregion
}