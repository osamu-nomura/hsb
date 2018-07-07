using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Extensions.Tests
{
    #region 【Class : NumericExTests】
    [TestClass()]
    public class NumericExTests
    {
        #region - IsEvenTest
        /// <summary>
        /// Test of IsEven
        /// </summary>
        [TestMethod()]
        public void IsEvenTest()
        {
            Assert.IsTrue(((Int16)2).IsEven());
            Assert.IsTrue(2.IsEven());
            Assert.IsTrue(((Int64)2).IsEven());
            Assert.IsTrue(2m.IsEven());

            Assert.IsFalse(((Int16)5).IsEven());
            Assert.IsFalse(5.IsEven());
            Assert.IsFalse(((Int64)5).IsEven());
            Assert.IsFalse(5m.IsEven());
        }
        #endregion

        #region - IsOddTest
        /// <summary>
        /// Test of IsOdd
        /// </summary>
        [TestMethod()]
        public void IsOddTest()
        {
            Assert.IsTrue(((Int16)5).IsOdd());
            Assert.IsTrue(5.IsOdd());
            Assert.IsTrue(((Int64)5).IsOdd());
            Assert.IsTrue(5m.IsOdd());

            Assert.IsFalse(((Int16)6).IsOdd());
            Assert.IsFalse(6.IsOdd());
            Assert.IsFalse(((Int64)6).IsOdd());
            Assert.IsFalse(6m.IsOdd());
        }
        #endregion

        #region - IsPrimeTest
        /// <summary>
        /// Test of IsPrime
        /// </summary>
        [TestMethod()]
        public void IsPrimeTest()
        {
            Assert.IsTrue(((Int16)11).IsPrime());
            Assert.IsTrue(53.IsPrime());
            Assert.IsTrue(((Int64)307).IsPrime());
            Assert.IsTrue((619m).IsPrime());

            Assert.IsFalse(((Int16)32).IsPrime());
            Assert.IsFalse((51).IsPrime());
            Assert.IsFalse(((Int64)309).IsPrime());
            Assert.IsFalse((623m).IsPrime());
        }
        #endregion

        #region - UnixTimeToDateTimeTest
        /// <summary>
        /// Test of UnitTimeToDateTime
        /// </summary>
        [TestMethod()]
        public void UnixTimeToDateTimeTest()
        {
            Assert.AreEqual(new DateTime(2018, 4, 14, 12, 52, 39), 1523677959.UnixTimeToDateTime());
            Assert.AreEqual(new DateTime(2040, 4, 14, 13, 07, 20), 2217989240.UnixTimeToDateTime());
        }
        #endregion
    }
    #endregion
}