﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Extensions.Tests
{
    #region 【Class : LsitExTests】
    [TestClass()]
    public class LsitExTests
    {
        #region - AddTest
        /// <summary>
        /// Test og Add
        /// </summary>
        [TestMethod()]
        public void AddTest()
        {
            var source = new List<int> { 1, 2, 3 };
            source.Add(4, 5, 6);
            var expected = new List<int> { 1, 2, 3, 4, 5, 6 };
            Assert.IsTrue(source.SequenceEqual(expected));
        }
        #endregion

        #region - GetTest
        /// <summary>
        /// Test of Get
        /// </summary>
        [TestMethod()]
        public void GetTest()
        {
            // Case 1
            Assert.AreEqual(3, (new List<int> { 1, 2, 3, 4 }).Get(2, 0));
            Assert.AreEqual(0, (new List<int> { 1, 2, 3, 4 }).Get(10, 0));
            Assert.AreEqual(0, (new List<int> { 1, 2, 3, 4 }).Get(-1, 0));

            // Case 2
            var source = new List<DateTime>
            {
                new DateTime(2017, 3, 1),
                new DateTime(2017, 3, 2),
                new DateTime(2017, 3, 3)
            };
            Assert.AreEqual(new DateTime(2017, 3, 2), source.Get(1, () => new DateTime(2017, 4, 1)));
            Assert.AreEqual(new DateTime(2017, 4, 1), source.Get(10, () => new DateTime(2017, 4, 1)));
            Assert.AreEqual(new DateTime(2017, 4, 1), source.Get(-1, () => new DateTime(2017, 4, 1)));
        }
        #endregion
    }
    #endregion
}