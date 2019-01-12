using Microsoft.VisualStudio.TestTools.UnitTesting;
using hsb.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsb.Utilities.Tests
{
    #region 【Test Class】
    [TestClass()]
    public class AddressUtilTests
    {
        #region - NormalizeTest
        /// <summary>
        /// Test of Normalize
        /// </summary>
        [TestMethod()]
        public void NormalizeTest()
        {
            // Test1
            var addr1 = "東京都新宿区西新宿２丁目８−１";
            var ret1 = AddressUtil.Normalize(addr1);
            Assert.AreEqual(ret1.Prefecture, "東京都");
            Assert.AreEqual(ret1.City, "新宿区");
            Assert.AreEqual(ret1.Address, "西新宿2-8-1");
            Assert.AreEqual(ret1.Building, "");

            // Test2
            var addr2 = "東京都東村山市本町1丁目2番地3";
            var ret2 = AddressUtil.Normalize(addr2);
            Assert.AreEqual(ret2.Prefecture, "東京都");
            Assert.AreEqual(ret2.City, "東村山市本町");
            Assert.AreEqual(ret2.Address, "1-2-3");
            Assert.AreEqual(ret2.Building, "");

            // Test3
            var addr3 = "東京都港区港南 2-16-3 品川グランドセントラルタワー 32F";
            var ret3 = AddressUtil.Normalize(addr3);
            Assert.AreEqual(ret3.Prefecture, "東京都");
            Assert.AreEqual(ret3.City, "港区");
            Assert.AreEqual(ret3.Address, "港南2-16-3");
            Assert.AreEqual(ret3.Building, "品川グランドセントラルタワー32階");

            // Test4
            var addr4 = "東京都八王子市東町3番11号プレイム八王子ビル三〇一号室";
            var ret4 = AddressUtil.Normalize(addr4);
            Assert.AreEqual(ret4.Prefecture, "東京都");
            Assert.AreEqual(ret4.City, "八王子市東町");
            Assert.AreEqual(ret4.Address, "3-11");
            Assert.AreEqual(ret4.Building, "プレイム八王子ビル301号室");
        }
        #endregion
    }
    #endregion
}