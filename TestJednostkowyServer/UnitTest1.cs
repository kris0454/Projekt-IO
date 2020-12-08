using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System.Net;
using System.IO;
using static ClassLibrary.Server;

namespace TestJednostkowy
{
    [TestClass]
    public class FunctionTest
    {
        [TestMethod]
        public void TestMethodIfPalimdrom()
        {
            string slowotestowe = "kajak";
            Functions funkcje = new ClassLibrary.Functions();
            Assert.IsTrue(funkcje.CheckIfPalindrome(slowotestowe));
        }
        [TestMethod]
        public void TestMethodIfAnagram()
        {
            string pattern = "anagram";
            string word = "maaagrn";
            Functions funkcje = new ClassLibrary.Functions();
            Assert.IsTrue(funkcje.CheckIfAnagram(pattern, word));
        }
        [TestMethod]
        public void TestMethodThrowExceptionWrongIP()
        {
            try
            {
                Server test = new Server(IPAddress.Parse("127.0.0."), 2048);
                Assert.Fail();
            }
            catch (AssertFailedException)
            {
                Assert.Fail();
            }
            catch (Exception e)
            {               
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void TestMethodMenuCorrectStream()
        {
            try
            {
                Menu test = new Menu();
                TransmissionDataDelegate transmissionDelegate = test.BeginDataTransmission;
                //transmissionDelegate.BeginInvoke(Stream, TransmissionCallback, tcpClient);
                Assert.Fail();
            }
            catch (AssertFailedException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {              
                Assert.Fail();
            }
        }
        [TestMethod]
        public void TestMethodLogIn()
        {
            Functions test = new Functions();
            //takie haslo i login nie istnieje w pliku więc nie może zostać zdane
            string login = "logintestowy";
            string haslo = "12345";
            Assert.IsTrue(test.LogIn(login, haslo));


        }
    }
}
