using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System.Net;

namespace TestJednostkowySerwer
{
    [TestClass]
    public class ServerTest
    {
        [TestMethod]
        public void TestMethodIfPalimdrom()
        {
            string slowotestowe = "kajak";
            MyTCPServer test = new MyTCPServer(IPAddress.Parse("127.0.0.1"), 2048);
            Assert.IsTrue(test.CheckIfPalindrome(slowotestowe));
        }
        [TestMethod]
        public void TestMethod2()
        {

        }
    }
}
