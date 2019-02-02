using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Extensions.Tests
{
    #region 【Test Class : ArrayExTests】
    /// <summary>
    /// ArrayExクラスのテスト
    /// </summary>
    [TestClass()]
    public class ArrayExTests
    {
        #region - GetTest
        /// <summary>
        /// Test of Get
        /// </summary>
        [TestMethod()]
        public void GetTest()
        {
            // Case 1
            Assert.AreEqual(3, (new int[] { 1, 2, 3, 4 }).Get(2, 0));
            Assert.AreEqual(0, (new int[] { 1, 2, 3, 4 }).Get(10, 0));
            Assert.AreEqual(0, (new int[] { 1, 2, 3, 4 }).Get(-1, 0));

            // Case 2
            var source = new DateTime[]
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

        #region - IsWithInTest
        /// <summary>
        /// Test of IsWIthIn
        /// </summary>
        [TestMethod()]
        public void IsWithInTest()
        {
            var array = new int[] { 1, 2, 3, 4, 5 };
            Assert.IsTrue(array.IsWithin(0));
            Assert.IsTrue(array.IsWithin(3));
            Assert.IsTrue(array.IsWithin(4));
            Assert.IsFalse(array.IsWithin(-1));
            Assert.IsFalse(array.IsWithin(5));
        }
        #endregion

        #region - ChoiceTest
        /// <summary>
        /// Test of Choice
        /// </summary>
        [TestMethod()]
        public void ChoiceTest()
        {
            var array = new int[] { 1, 2, 3, 4, 5 };
            var n1 = array.Choice();
            Assert.IsTrue(array.Contains(n1));
            var n2 = array.Choice(new Random(100));
            Assert.IsTrue(array.Contains(n2));

            var array2 = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            var n3 = array2.Choice();
            Assert.IsTrue(array2.Flatten().Contains(n3));
            var n4 = array2.Choice(new Random(100));
            Assert.IsTrue(array2.Flatten().Contains(n4));
        }
        #endregion

        #region - RowsTest
        /// <summary>
        /// Test of Rows
        /// </summary>
        [TestMethod()]
        public void RowsTest()
        {
            var array = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            var row = array.Rows(1);

            Assert.AreEqual(row.Length, 3);
            Assert.AreEqual(row[0], 4);
            Assert.AreEqual(row[1], 5);
            Assert.AreEqual(row[2], 6);

            var rowArray = row.ToArray();
            Assert.AreEqual(rowArray.Length, 3);
            Assert.AreEqual(rowArray[0], 4);
            Assert.AreEqual(rowArray[1], 5);
            Assert.AreEqual(rowArray[2], 6);

            Assert.AreEqual(array.Rows().Sum(r => r.Sum()), 45);
        }
        #endregion

        #region - ColsTest
        /// <summary>
        /// Test of Cols
        /// </summary>
        [TestMethod()]
        public void ColsTest()
        {
            var array = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            var col = array.Cols(1);

            Assert.AreEqual(col.Length, 3);
            Assert.AreEqual(col[0], 2);
            Assert.AreEqual(col[1], 5);
            Assert.AreEqual(col[2], 8);

            var colArray = col.ToArray();
            Assert.AreEqual(colArray.Length, 3);
            Assert.AreEqual(colArray[0], 2);
            Assert.AreEqual(colArray[1], 5);
            Assert.AreEqual(colArray[2], 8);

            Assert.AreEqual(array.Cols().Sum(r => r.Sum()), 45);

        }
        #endregion

        #region - FlattenTest
        /// <summary>
        /// Test of Flatten
        /// </summary>
        [TestMethod()]
        public void FlattenTest()
        {
            var array = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            var array2 = array.Flatten().ToArray();
            Assert.IsTrue(array2.SequenceEqual(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
        }
        #endregion
    }
    #endregion
}