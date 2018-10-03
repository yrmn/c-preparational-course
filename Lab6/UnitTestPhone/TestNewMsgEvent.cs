using System;
using ClassLibPhone;
using ClassLibPhone.SMS_Utilities;
using ClassLibPhone.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;

namespace UnitTestPhone {

    [TestClass]
    public class TestNewMsgEvent {
        
        private const string TestMsg = "Test message received!";
        private MessageStorage _sms;

        private void Init() {
            _sms = MessageStorage.Instance;
        }
        
        [TestMethod]
        public void TestSMSReceivedEvent() {
            
            //Arrange
            Init();
            var expected = String.Empty;
            _sms.SMSReceived += s => expected = s.Text;

            //Act
            var testMsg = new Message {User = "Test", Text = TestMsg, ReceivingTime = DateTime.Now};
            _sms.ReceiveMessage(testMsg);
            
            //Assert
            Assert.AreEqual(TestMsg, expected);
        }

    }

}
