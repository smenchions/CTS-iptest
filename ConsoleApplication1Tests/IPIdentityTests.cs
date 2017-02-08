using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Tests
{
    [TestClass()]
    public class IPIdentityTests
    {
        [TestMethod()]
        public void isPublicTest()
        {
            Assert.IsTrue(IPIdentity.isPublic("badipaddress") == null);
            Assert.IsTrue(IPIdentity.isPublic("123.255.255.000") == true);
            Assert.IsTrue(IPIdentity.isPublic("192.168.254.000") == false);
            Assert.IsTrue(IPIdentity.isPublic("10.789.1.255") == false);
            Assert.IsTrue(IPIdentity.isPublic("172.16.1.212") == false);
            Assert.IsTrue(IPIdentity.isPublic("172.15.1.212") == true);
            Assert.IsTrue(IPIdentity.isPublic("172.31.1.212") == false);
            Assert.IsTrue(IPIdentity.isPublic("172.32.1.212") == true);
            Assert.IsTrue(IPIdentity.isPublic("fd20:4a55:d0f1:94b7:xxxx:xxxx:xxxx:xxxx") == false);
            Assert.IsTrue(IPIdentity.isPublic("2001:db8::211:22ff:fe33:4455") == true);
            Assert.IsTrue(IPIdentity.isPublic("2001:db8:0000:211:22ff:fe33:4455:0000") == true);

        }
    }
}