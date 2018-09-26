using System;
using ClassLibPhone.Peripherals;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestPhone {

    [TestClass]
    public class TestProtector {

        private MockOutput _testoutput;

        private void Init() {
            _testoutput = new MockOutput();
        }

        [TestMethod]
        public void TestLeatherProtector() {

            //Arrange
            Init();
            LeatherProtector leather = new LeatherProtector(_testoutput);

            //Act
            leather.Put(null);

            //Assert
            string expected = "Phone is covered with LeatherProtector";
            Assert.AreEqual(_testoutput.CapturedOutput, expected);
        }

        [TestMethod]
        public void TestSteelProtector() {

            //Arrange
            Init();
            SteelProtector steel = new SteelProtector(_testoutput);

            //Act
            steel.Put(null);

            //Assert
            string expected = "Phone is covered with SteelProtector";
            Assert.AreEqual(_testoutput.CapturedOutput, expected);
        }
        
    }

}
