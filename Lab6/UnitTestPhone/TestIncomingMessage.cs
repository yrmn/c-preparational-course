using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibPhone;
using ClassLibPhone.SMS_Utilities;
using ClassLibPhone.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestPhone {

    [TestClass]
    public class TestIncomingMessage {

        private MessageStorage _sms;
        // year, month, day, hour, minute, second  
        private readonly DateTime _date = new DateTime(2011, 12, 31, 10, 30, 50);
        private Message _msg1, _msg2;
        private const string Txt1 = "Message #1 from Alex received!";
        private const string Txt2 = "Message #2 from Alex received!";
        private readonly MobilePhone _phone = new SimCorpMobile();

        private void Init() {
            _sms = MessageStorage.Instance;
            _sms.SMSReceived += MockOnSMSReceived;
            _sms.MsgList = new List<Message>();
            _msg1 = new Message { User = "Alex", Text = Txt1, ReceivingTime = _date };
            _msg2 = new Message { User = "Alex", Text = Txt2, ReceivingTime = _date };
        }

        private void TearDown() {
            _sms.SMSReceived -= MockOnSMSReceived;
        }

        private void MockOnSMSReceived(Message message) {
            _phone.IncomingMessage(message);
        }

        [TestMethod]
        public void TestReceiveMessage() {

            //Arrange
            Init();

            //Act
            _sms.ReceiveMessage(_msg1);

            //Assert
            List<Message> expectedMessages = new List<Message>() { _msg1 };
            bool areEqual = _sms.MsgList.SequenceEqual(expectedMessages);
            Assert.IsTrue(areEqual);

            //TearDown
            TearDown();
        }
        
        [TestMethod]
        public void TestAddMessage() {

            //Arrange
            Init();
            
            //Act
            _sms.AddMessage(_msg2);

            //Assert
            List<Message> expectedMessages = new List<Message>() { _msg2 };
            bool areEqual = _sms.MsgList.SequenceEqual(expectedMessages);
            Assert.IsTrue(areEqual);

            //TearDown
            TearDown();
        }

        [TestMethod]
        public void TestDeleteMessage() {
            
            //Arrange
            Init();
            _sms.AddMessage(_msg1);
            _sms.AddMessage(_msg2);

            //Act
            _sms.DeleteMessage(_msg2);

            //Assert
            List<Message> expectedMessages = new List<Message>() { _msg1 };
            bool areEqual = _sms.MsgList.SequenceEqual(expectedMessages);
            Assert.IsTrue(areEqual);

            //TearDown
            TearDown();
        }
        
    }

}
