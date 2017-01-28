using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Classes.Tests
{
    #region 【Class : DateRangeTests】
    /// <summary>
    /// DateRangeクラスのテスト
    /// </summary>
    [TestClass()]
    public class DateRangeTests
    {
        #region - InRangeTest
        /// <summary>
        /// Test for InRange
        /// </summary>
        [TestMethod()]
        public void InRangeTest()
        {
            var fromDate = new DateTime(2017, 2, 1);
            var toDate = new DateTime(2017, 2, 10);
            var range = new DateRange(fromDate, toDate);

            // Case 1
            var trueCase = new DateTime[]
            {
                new DateTime(2017, 2, 1),
                new DateTime(2017, 2, 5),
                new DateTime(2017, 2, 10)
            };
            foreach (var dt in trueCase)
                Assert.IsTrue(range.InRange(dt));

            // Case 2
            var falseCase = new DateTime[]
            {
                new DateTime(2017, 1, 31),
                new DateTime(2017, 2, 11)
            };
            foreach (var dt in falseCase)
                Assert.IsFalse(range.InRange(dt));

        }
        #endregion
    }
    #endregion
}