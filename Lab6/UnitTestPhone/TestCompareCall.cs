using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibPhone.Call_Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestPhone {

    [TestClass]
    public class TestCompareCall {
        
        // year, month, day, hour, minute, second  
        private readonly DateTime _date1 = new DateTime(2011, 12, 31, 10, 30, 50);
        private readonly DateTime _date2 = new DateTime(2011, 12, 31, 10, 32, 50);
        private readonly DateTime _date3 = new DateTime(2011, 12, 31, 10, 33, 50);
        private readonly DateTime _date4 = new DateTime(2011, 12, 31, 10, 34, 50);
        private readonly DateTime _date5 = new DateTime(2011, 12, 31, 10, 35, 50);
        private readonly DateTime _date6 = new DateTime(2011, 12, 31, 10, 36, 50);
        private Call _call1, _call2, _call3, _call4, _call5;
        private readonly Contact _contact1 = new Contact {
            Name = "Alex",
            PhonesList = new List<string>() { "2222", "3333" }
        };
        private readonly Contact _contact2 = new Contact {
            Name = "Bill",
            PhonesList = new List<string>() { "4444" }
        };

        private void Init() {
            _call1 = new Call { Contact = _contact1, CallTime = _date1, Direction = Call.CallDirection.Incoming };
            _call2 = new Call { Contact = _contact1, CallTime = _date2, Direction = Call.CallDirection.Incoming };
            _call3 = new Call { Contact = _contact2, CallTime = _date3, Direction = Call.CallDirection.Outgoing };
            _call4 = new Call { Contact = _contact1, CallTime = _date4, Direction = Call.CallDirection.Outgoing };
            _call5 = new Call { Contact = _contact1, CallTime = _date5, Direction = Call.CallDirection.Incoming };
        }

        [TestMethod]
        public void TestCompareCall_EqualDirection() {

            //Arrange
            Init();
            
            //Act
            bool areEqual = _call1.Equals(_call2);

            //Assert
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void TestCompareCall_DifferentDirection() {

            //Arrange
            Init();

            //Act
            bool areEqual = _call4.Equals(_call5);

            //Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void TestCompareCall_DifferentContacts_Smaller() {

            //Arrange
            Init();

            //Act
            int smaller = _call3.CompareTo(_call4);

            //Assert
            Assert.AreEqual(1,smaller);
        }

        [TestMethod]
        public void TestCompareCall_DifferentContacts_Greater() {

            //Arrange
            Init();

            //Act
            int greater = _call3.CompareTo(_call2);

            //Assert
            Assert.AreEqual(-1, greater);
        }

    }

}
