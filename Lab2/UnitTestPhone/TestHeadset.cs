using System;
using ClassLibPhone.Peripherals;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestPhone {

    [TestClass]
    public class TestHeadset {

        private MockOutput _testoutput;

        private void Init() {
            _testoutput = new MockOutput();
        }

        [TestMethod]
        public void TestMeizuHeadset() {

            //Arrange
            Init();
            MeizuHeadset meizu = new MeizuHeadset(_testoutput);

            //Act
            meizu.Play(null);

            //Assert
            string expected = "MeizuHeadset sound";
            Assert.AreEqual(_testoutput.CapturedOutput, expected);
        }

        [TestMethod]
        public void TestSamsungHeadset() {

            //Arrange
            Init();
            SamsungHeadset samsung = new SamsungHeadset(_testoutput);

            //Act
            samsung.Play(null);

            //Assert
            string expected = "SamsungHeadset sound";
            Assert.AreEqual(_testoutput.CapturedOutput, expected);
        }

        [TestMethod]
        public void TestUnofficialiPhoneHeadset() {

            //Arrange
            Init();
            UnofficialiPhoneHeadset iPhone = new UnofficialiPhoneHeadset(_testoutput);

            //Act
            iPhone.Play(null);

            //Assert
            string expected = "UnofficialiPhoneHeadset sound";
            Assert.AreEqual(_testoutput.CapturedOutput, expected);
        }

        [TestMethod]
        public void TestPortableSpeaker() {

            //Arrange
            Init();
            PortableSpeaker speaker = new PortableSpeaker(_testoutput);

            //Act
            speaker.Play(null);

            //Assert
            string expected = "PortableSpeaker sound";
            Assert.AreEqual(_testoutput.CapturedOutput, expected);
        }

    }

}
