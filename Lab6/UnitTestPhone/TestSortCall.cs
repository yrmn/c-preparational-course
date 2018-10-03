using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibPhone;
using ClassLibPhone.Call_Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestPhone {

    [TestClass]
    public class TestSortCall {
        
        private List<Call> _callList;
        // year, month, day, hour, minute, second  
        private readonly DateTime _date1 = new DateTime(2011, 12, 31, 10, 30, 50);
        private readonly DateTime _date2 = new DateTime(2011, 12, 31, 10, 32, 50);
        private readonly DateTime _date3 = new DateTime(2011, 12, 31, 10, 33, 50);
        private Call _call1, _call2, _call3;
        private readonly Contact _contact1 = new Contact {
            Name = "Alex",
            PhonesList = new List<string>() { "2222", "3333" }
        };
        private readonly Contact _contact2 = new Contact {
            Name = "Bill",
            PhonesList = new List<string>() { "4444" }
        };
        
        private void Init() {
            _callList = new List<Call>();
            _call1 = new Call { Contact = _contact1, CallTime = _date1, Direction = Call.CallDirection.Incoming };
            _call2 = new Call { Contact = _contact1, CallTime = _date2, Direction = Call.CallDirection.Incoming };
            _call3 = new Call { Contact = _contact2, CallTime = _date3, Direction = Call.CallDirection.Incoming };
        }
        
        [TestMethod]
        public void TestAddSort() {

            //Arrange
            Init();
            _callList.Add(_call2);
            _callList.Add(_call3);
            _callList.Add(_call1);
            
            //Act
            _callList.Sort();

            //Assert
            List<Call> expectedCalls = new List<Call>() { _call3, _call2, _call1 };
            bool areEqual = _callList.SequenceEqual(expectedCalls);
            Assert.IsTrue(areEqual);
        }
        
        [TestMethod]
        public void TestRemoveSort() {

            //Arrange
            Init();
            _callList.Add(_call2);
            _callList.Add(_call3);
            _callList.Add(_call1);

            //Act
            _callList.Remove(_call2);
            _callList.Sort();

            //Assert
            List<Call> expectedCalls = new List<Call>() { _call3, _call1 };
            bool areEqual = _callList.SequenceEqual(expectedCalls);
            Assert.IsTrue(areEqual);
        }
        
    }

}
