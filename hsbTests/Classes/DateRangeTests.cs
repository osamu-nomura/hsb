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
        /// Test of InRange
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

        #region - OutOfRangeTest
        /// <summary>
        /// Test of OutOfRange
        /// </summary>
        [TestMethod()]
        public void OutOfRangeTest()
        {
            var fromDate = new DateTime(2017, 2, 1);
            var toDate = new DateTime(2017, 2, 10);
            var range = new DateRange(fromDate, toDate);

            // Case 1
            var trueCase = new DateTime[]
            {
                new DateTime(2017, 1, 31),
                new DateTime(2017, 2, 11)
            };
            foreach (var dt in trueCase)
                Assert.IsTrue(range.OutOfRange(dt));

            // Case 2
            var falseCase = new DateTime[]
            {
                new DateTime(2017, 2, 1),
                new DateTime(2017, 2, 5),
                new DateTime(2017, 2, 10)
            };
            foreach (var dt in falseCase)
                Assert.IsFalse(range.OutOfRange(dt));

        }
        #endregion

        #region - ToStringTest
        /// <summary>
        /// Test of ToString
        /// </summary>
        [TestMethod()]
        public void ToStringTest()
        {
            var fromDate = new DateTime(2017, 2, 1);
            var toDate = new DateTime(2017, 2, 10);
            var range = new DateRange(fromDate, toDate);

            // Case1
            Assert.AreEqual(@"2017/02/01 0:00:00～2017/02/10 0:00:00", range.ToString());
            // Case2
            Assert.AreEqual(@"2017/02/01 to 2017/02/10", range.ToString(@"{0:yyyy/MM/dd} to {1:yyyy/MM/dd}"));
            // Case 3
            range.DisplayFormat = @"{0:yyyy/MM/dd} to {1:yyyy/MM/dd}";
            Assert.AreEqual(@"2017/02/01 to 2017/02/10", range.ToString());
        }
        #endregion

        #region - GetEnumeratorTest
        /// <summary>
        /// Test of GetEnumerator
        /// </summary>
        [TestMethod()]
        public void GetEnumeratorTest()
        {
            // Case 1
            var range1 = new DateRange(new DateTime(2017, 2, 1), new DateTime(2017, 2, 5));
            var expecteds1 = new DateTime[]
            {
                new DateTime(2017, 2, 1),
                new DateTime(2017, 2, 2),
                new DateTime(2017, 2, 3),
                new DateTime(2017, 2, 4),
                new DateTime(2017, 2, 5)
            };
            var i = 0;
            foreach (var dt in range1)
            {
                Assert.AreEqual(expecteds1[i++], dt);
            }
            Assert.AreEqual(5, i);

            // Case 2
            var range2 = new DateRange(new DateTime(2017, 2, 5), new DateTime(2017, 2, 28), 5);
            var expecteds2 = new DateTime[]
            {
                new DateTime(2017, 2, 5),
                new DateTime(2017, 2, 10),
                new DateTime(2017, 2, 15),
                new DateTime(2017, 2, 20),
                new DateTime(2017, 2, 25)
            };
            i = 0;
            foreach (var dt in range2)
            {
                Assert.AreEqual(expecteds2[i++], dt);
            }
            Assert.AreEqual(5, i);

            // Case 3
            var range3 = new DateRange(new DateTime(2017, 1, 1), new DateTime(2021, 1, 1), 1, Types.DatePart.Year);
            var expecteds3 = new DateTime[]
            {
                new DateTime(2017, 1, 1),
                new DateTime(2018, 1, 1),
                new DateTime(2019, 1, 1),
                new DateTime(2020, 1, 1),
                new DateTime(2021, 1, 1)
            };
            i = 0;
            foreach (var dt in range3)
            {
                Assert.AreEqual(expecteds3[i++], dt);
            }
            Assert.AreEqual(5, i);

            // Case 4
            var range4 = new DateRange(new DateTime(2017, 1, 31), new DateTime(2017, 5, 31), 1, Types.DatePart.Month);
            var expecteds4 = new DateTime[]
            {
                new DateTime(2017, 1, 31),
                new DateTime(2017, 2, 28),
                new DateTime(2017, 3, 31),
                new DateTime(2017, 4, 30),
                new DateTime(2017, 5, 31)
            };
            i = 0;
            foreach (var dt in range4)
            {
                Assert.AreEqual(expecteds4[i++], dt);
            }
            Assert.AreEqual(5, i);

            // Case 5
            var range5 = new DateRange(new DateTime(2017, 2, 1), new DateTime(2017, 2, 1, 4, 0, 0, 0), 1, Types.DatePart.Hour);
            var expecteds5 = new DateTime[]
            {
                new DateTime(2017, 2, 1, 0, 0, 0, 0),
                new DateTime(2017, 2, 1, 1, 0, 0, 0),
                new DateTime(2017, 2, 1, 2, 0, 0, 0),
                new DateTime(2017, 2, 1, 3, 0, 0, 0),
                new DateTime(2017, 2, 1, 4, 0, 0, 0)
            };
            i = 0;
            foreach (var dt in range5)
            {
                Assert.AreEqual(expecteds5[i++], dt);
            }
            Assert.AreEqual(5, i);

            // Case 6
            var range6 = new DateRange(new DateTime(2017, 2, 1), new DateTime(2017, 2, 1, 0, 40, 0, 0), 10, Types.DatePart.Minute);
            var expecteds6 = new DateTime[]
            {
                new DateTime(2017, 2, 1, 0, 0, 0, 0),
                new DateTime(2017, 2, 1, 0, 10, 0, 0),
                new DateTime(2017, 2, 1, 0, 20, 0, 0),
                new DateTime(2017, 2, 1, 0, 30, 0, 0),
                new DateTime(2017, 2, 1, 0, 40, 0, 0)
            };
            i = 0;
            foreach (var dt in range6)
            {
                Assert.AreEqual(expecteds6[i++], dt);
            }
            Assert.AreEqual(5, i);

            // Case 7
            var range7 = new DateRange(new DateTime(2017, 2, 1), new DateTime(2017, 2, 1, 0, 2, 00, 0), 30, Types.DatePart.Second);
            var expecteds7 = new DateTime[]
            {
                new DateTime(2017, 2, 1, 0, 0, 0, 0),
                new DateTime(2017, 2, 1, 0, 0, 30, 0),
                new DateTime(2017, 2, 1, 0, 1, 0, 0),
                new DateTime(2017, 2, 1, 0, 1, 30, 0),
                new DateTime(2017, 2, 1, 0, 2, 0, 0)
            };
            i = 0;
            foreach (var dt in range7)
            {
                Assert.AreEqual(expecteds7[i++], dt);
            }
            Assert.AreEqual(5, i);

            // Case 8
            var range8 = new DateRange(new DateTime(2017, 2, 1), new DateTime(2017, 2, 1, 0, 0, 0, 400), 100, Types.DatePart.Milisecond);
            var expecteds8 = new DateTime[]
            {
                new DateTime(2017, 2, 1, 0, 0, 0, 0),
                new DateTime(2017, 2, 1, 0, 0, 0, 100),
                new DateTime(2017, 2, 1, 0, 0, 0, 200),
                new DateTime(2017, 2, 1, 0, 0, 0, 300),
                new DateTime(2017, 2, 1, 0, 0, 0, 400)
            };
            i = 0;
            foreach (var dt in range8)
            {
                Assert.AreEqual(expecteds8[i++], dt);
            }
            Assert.AreEqual(5, i);

            // Case 9
            var range9 = new DateRange(DateTime.Today, DateTime.Today.AddDays(-1));
            i = 0;
            foreach (var dt in range9)
                i++;
            Assert.AreEqual(0, i);
        }
        #endregion

        #region - IsEmptyTest
        /// <summary>
        /// Test of IsEmpty
        /// </summary>
        [TestMethod()]
        public void IsEmptyTest()
        {
            // Case 1
            Assert.IsTrue(new DateRange(DateTime.Today, DateTime.Today.AddDays(-1)).IsEmpty);
            // Case 2
            Assert.IsFalse(new DateRange(DateTime.Today, DateTime.Today).IsEmpty);
        }
        #endregion

        #region - SpanTest
        /// <summary>
        /// Test of Span
        /// </summary>
        [TestMethod()]
        public void SpanTest()
        {
            var range = new DateRange(DateTime.Today, DateTime.Today.AddDays(1));
            var span = new TimeSpan(1, 0, 0, 0);
            Assert.AreEqual(span, range.Span);
        }
        #endregion

    }
    #endregion
}