using System;
using ClassLibPhone.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestPhone {

    [TestClass]
    public class TestFormat {

        private const string TestStr = "MiXeD CaSe";
        private SMSFormat _format;

        private void Init() {
            _format = new SMSFormat();
        }

        [TestMethod]
        public void TestNoneFormat() {
            
            //Arrange
            Init();
            
            //Act
            _format.ApplyFormat(0);
            string res = _format.Formatter(TestStr);

            //Assert
            Assert.AreEqual(res, TestStr);
        }

        [TestMethod]
        public void TestStartDateTimeFormat() {
            
            //Arrange
            Init();

            //Act
            _format.ApplyFormat(1);
            string res = _format.Formatter(TestStr);

            //Assert
            string expected = $"[{DateTime.Now}] {TestStr}";
            Assert.AreEqual(res, expected);
        }

        [TestMethod]
        public void TestEndDateTimeFormat() {

            //Arrange
            Init();

            //Act
            _format.ApplyFormat(2);
            string res = _format.Formatter(TestStr);

            //Assert
            string expected = $"{TestStr} [{DateTime.Now}]";
            Assert.AreEqual(res, expected);
        }

        [TestMethod]
        public void TestCustomFormat() {

            //Arrange
            Init();

            //Act
            _format.ApplyFormat(3);
            string res = _format.Formatter(TestStr);

            //Assert
            string expected = $"-={TestStr}=-";
            Assert.AreEqual(res, expected);
        }

        [TestMethod]
        public void TestLowercaseFormat() {

            //Arrange
            Init();

            //Act
            _format.ApplyFormat(4);
            string res = _format.Formatter(TestStr);

            //Assert
            string expected = TestStr.ToLower();
            Assert.AreEqual(res, expected);
        }

        [TestMethod]
        public void TestUppercaseFormat() {

            //Arrange
            Init();

            //Act
            _format.ApplyFormat(5);
            string res = _format.Formatter(TestStr);

            //Assert
            string expected = TestStr.ToUpper();
            Assert.AreEqual(res, expected);
        }
        
    }

}
