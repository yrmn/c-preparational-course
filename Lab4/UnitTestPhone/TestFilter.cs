using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibPhone.SMS_Utilities;
using ClassLibPhone.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestPhone {

    [TestClass]
    public class TestFilter {

        private const string UserName1 = "Alex";
        private const string UserName2 = "Bill";
        private const string UserName3 = "Cynthia";
        private const string Txt1 = "Message #1 from Alex received!";
        private const string Txt2 = "Message #2 from Bill received!";
        private const string Txt3 = "Message #3 from Cynthia received!";
        // year, month, day, hour, minute, second  
        private readonly DateTime _date1 = new DateTime(2011, 12, 31, 10, 30, 50);
        private readonly DateTime _date2 = new DateTime(2011, 12, 31, 10, 30, 51);
        private readonly DateTime _date3 = new DateTime(2011, 12, 31, 10, 30, 52);
        private Message _msg1;
        private Message _msg2;
        private Message _msg3;
        private List<Message> _msgList;

        private void Init() {
        _msg1 = new Message { User = UserName1, Text = Txt1, ReceivingTime = _date1 };
        _msg2 = new Message { User = UserName2, Text = Txt2, ReceivingTime = _date2 };
        _msg3 = new Message { User = UserName3, Text = Txt3, ReceivingTime = _date3 };
        _msgList = new List<Message>();
        }

        [TestMethod]
        public void TestGetUniqueUsers() {

            //Arrange
            Init();
            _msg2.User = UserName1;
            _msgList.Insert(0, _msg1);
            _msgList.Insert(0, _msg2);
            _msgList.Insert(0, _msg3);

            //Act
            string[] uniqueUsers = Filter.GetUniqueUsers(_msgList);
            
            //Assert
            string[] expectedUniqueUsers = { UserName3, UserName1 };
            bool areEqual = uniqueUsers.SequenceEqual(expectedUniqueUsers);
            Assert.IsTrue(areEqual);
        }
        
        [TestMethod]
        public void TestFilterByUser() {

            //Arrange
            Init();
            _msg2.User = UserName1;
            _msgList.Insert(0, _msg1);
            _msgList.Insert(0, _msg2);
            _msgList.Insert(0, _msg3);

            //Act
            var messages = Filter.FilterByUser(_msgList, UserName1);

            //Assert
            List<Message> expectedMessages = new List<Message>() { _msg2, _msg1 };
            bool areEqual = messages.SequenceEqual(expectedMessages);
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void TestFilterByText() {

            //Arrange
            Init();
            _msg2.Text += UserName1;
            _msgList.Insert(0, _msg1);
            _msgList.Insert(0, _msg2);
            _msgList.Insert(0, _msg3);

            //Act
            var messages = Filter.FilterByText(_msgList, UserName1);

            //Assert
            List<Message> expectedMessages = new List<Message>() { _msg2, _msg1 };
            bool areEqual = messages.SequenceEqual(expectedMessages);
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void TestFilterByDate() {

            //Arrange
            Init();
            _msgList.Insert(0, _msg1);
            _msgList.Insert(0, _msg2);
            _msgList.Insert(0, _msg3);

            //Act
            var messages = Filter.FilterByDate(_msgList, _date2, _date3);

            //Assert
            List<Message> expectedMessages = new List<Message>() { _msg3, _msg2 };
            bool areEqual = messages.SequenceEqual(expectedMessages);
            Assert.IsTrue(areEqual);
        }
        
        [TestMethod]
        public void TestFilterAND() {
            
            //Arrange
            Init();
            _msg2.Text += UserName1;
            _msg3.User = UserName1;
            _msgList.Insert(0, _msg1);
            _msgList.Insert(0, _msg2);
            _msgList.Insert(0, _msg3);

            //Act
            var messagesAll = Filter.FilterAND(_msgList, true, true, true, UserName1, UserName1, _date1, _date3);
            var messagesNoUser = Filter.FilterAND(_msgList, false, true, true, UserName3, UserName1, _date1, _date3);
            var messagesNoText = Filter.FilterAND(_msgList, true, false, true, UserName2, "test text", _date2, _date3);
            var messagesNoDate = Filter.FilterAND(_msgList, true, true, false, UserName1, "3", _date2, _date1);

            //Assert
            List<Message> expectedMessagesAll = new List<Message>() { _msg1 };
            List<Message> expectedMessagesNoUser = new List<Message>() { _msg2, _msg1 };
            List<Message> expectedMessagesNoText = new List<Message>() { _msg2 };
            List<Message> expectedMessagesNoDate = new List<Message>() { _msg3 };
            bool areEqualAll = messagesAll.SequenceEqual(expectedMessagesAll);
            bool areEqualNoUser = messagesNoUser.SequenceEqual(expectedMessagesNoUser);
            bool areEqualNoText = messagesNoText.SequenceEqual(expectedMessagesNoText);
            bool areEqualNoDate = messagesNoDate.SequenceEqual(expectedMessagesNoDate);
            Assert.IsTrue(areEqualAll);
            Assert.IsTrue(areEqualNoUser);
            Assert.IsTrue(areEqualNoText);
            Assert.IsTrue(areEqualNoDate);
        }
        
        [TestMethod]
        public void TestFilterOR() {
            
            //Arrange
            Init();
            _msg2.Text += UserName1;
            _msg3.User = UserName1;
            _msgList.Insert(0, _msg1);
            _msgList.Insert(0, _msg2);
            _msgList.Insert(0, _msg3);

            //Act
            var messagesAll = Filter.FilterOR(_msgList, true, true, true, UserName1, Txt1, _date1, _date1);
            var messagesNoUser = Filter.FilterOR(_msgList, false, true, true, UserName3, UserName1, _date1, _date3);
            var messagesNoText = Filter.FilterOR(_msgList, true, false, true, UserName1, UserName1, _date3, _date2);
            var messagesNoDate = Filter.FilterOR(_msgList, true, true, false, UserName2, UserName1, _date1, _date3);

            //Assert
            List<Message> expectedMessagesAll = new List<Message>() { _msg3, _msg1 };
            List<Message> expectedMessagesNoUser = new List<Message>() { _msg2, _msg1, _msg3 };
            List<Message> expectedMessagesNoText = new List<Message>() { _msg3, _msg1 };
            List<Message> expectedMessagesNoDate = new List<Message>() { _msg2, _msg1 };
            bool areEqualAll = messagesAll.SequenceEqual(expectedMessagesAll);
            bool areEqualNoUser = messagesNoUser.SequenceEqual(expectedMessagesNoUser);
            bool areEqualNoText = messagesNoText.SequenceEqual(expectedMessagesNoText);
            bool areEqualNoDate = messagesNoDate.SequenceEqual(expectedMessagesNoDate);
            Assert.IsTrue(areEqualAll);
            Assert.IsTrue(areEqualNoUser);
            Assert.IsTrue(areEqualNoText);
            Assert.IsTrue(areEqualNoDate);
        }
        
    }

}
