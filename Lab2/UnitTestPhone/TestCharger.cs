using System;
using ClassLibPhone;
using ClassLibPhone.Peripherals;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestPhone {

    [TestClass]
    public class TestCharger {

        private MockOutput _testoutput;

        private void Init() {
            _testoutput = new MockOutput();
        }

        [TestMethod]
        public void TestSamsungCharger() {
            
            //Arrange
            Init();
            SamsungCharger samsung = new SamsungCharger(_testoutput);

            //Act
            samsung.Charge(null);

            //Assert
            string expected = "Phone is charging with SamsungCharger";
            Assert.AreEqual(_testoutput.CapturedOutput, expected);
        }
        
        [TestMethod]
        public void TestMeizuCharger() {

            //Arrange
            Init();
            MeizuCharger meizu = new MeizuCharger(_testoutput);

            //Act
            meizu.Charge(null);

            //Assert
            string expected = "Phone is charging with MeizuCharger";
            Assert.AreEqual(_testoutput.CapturedOutput, expected);
        }
        
        [TestMethod]
        public void TestOfficialiPhoneCharger() {

            //Arrange
            Init();
            OfficialiPhoneCharger iPhone = new OfficialiPhoneCharger(_testoutput);

            //Act
            iPhone.Charge(null);

            //Assert
            string expected = "Phone is charging with OfficialiPhoneCharger";
            Assert.AreEqual(_testoutput.CapturedOutput, expected);
        }

    }

}
