using System;
using ClassLibPhone;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestPhone {

    [TestClass]
    public class TestNewMsgEvent {
        
        private const string TestMsg = "Test message received!";
        private SMSProvider _sms;

        private void Init() {
            _sms = new SMSProvider();
        }
        
        [TestMethod]
        public void TestSMSReceivedEvent() {
            
            //Arrange
            Init();
            var expected = String.Empty;
            _sms.SMSReceived += s => expected = s;

            //Act
            _sms.ReceiveMessage(TestMsg);
            
            //Assert
            Assert.AreEqual(TestMsg, expected);
        }

    }

}
