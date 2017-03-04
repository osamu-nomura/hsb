using hsb.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace hsb.Utilities.Tests
{
    #region 【Test Calass】
    [TestClass()]
    public class ConditionUtilTests
    {
        #region - AllTest
        /// <summary>
        /// Test of All
        /// </summary>
        [TestMethod()]
        public void AllTest()
        {
            Assert.IsTrue(ConditionUtil.All(true, true, true));
            Assert.IsTrue(ConditionUtil.All(true));
            Assert.IsFalse(ConditionUtil.All(true, false, true));
        }
        #endregion

        #region - NothingTest
        /// <summary>
        /// Test of Nothing
        /// </summary>
        [TestMethod()]
        public void NothingTest()
        {
            Assert.IsTrue(ConditionUtil.Nothing(false, false, false));
            Assert.IsTrue(ConditionUtil.Nothing(false));
            Assert.IsFalse(ConditionUtil.Nothing(false, true, false));
        }
        #endregion

        #region - AnyTest
        /// <summary>
        /// Test of Any
        /// </summary>
        [TestMethod()]
        public void AnyTest()
        {
            Assert.IsTrue(ConditionUtil.Any(false, false, false, true));
            Assert.IsTrue(ConditionUtil.Any(false, true, true));
            Assert.IsFalse(ConditionUtil.Any(false, false));
        }
        #endregion
    }
    #endregion
}