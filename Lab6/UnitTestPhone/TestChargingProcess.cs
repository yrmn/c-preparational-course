using System;
using System.Threading;
using System.Threading.Tasks;
using ClassLibPhone;
using ClassLibPhone.Peripherals;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestPhone {
    
    [TestClass]
    public class TestChargingProcess {
        
        private MobilePhone _phone;
        private Action StubShowBattery = () => { };

        private void Init() {
            _phone = new SimCorpMobile(true);
        }
        
        [TestMethod]
        public void TestCharge() {

            //Arrange
            Init();
            
            //Act
            for (var i = 0; i < 102; i++) {
                _phone.Charge();
            }
            
            //Assert
            Assert.AreEqual(_phone.BatteryBase.Charge, 101);
        }

        [TestMethod]
        public void TestDischarge() {

            //Arrange
            Init();

            //Act
            for (var i = 0; i < 102; i++) {
                _phone.Discharge();
            }

            //Assert
            Assert.AreEqual(_phone.BatteryBase.Charge, 0);
        }
        
        [TestMethod]
        public void   TestDischargeThread() {

            //Arrange
            Init();
            var chargeThread = new ChargeThread(_phone, StubShowBattery) {
                IsTestDischarge = true,
                TestIterations = 40,
                DischargeInterval = 0
            };
            
            //Act
            chargeThread.DischargingThread.Join();

            //TearDown
            chargeThread.DischargingThread.Abort();
            chargeThread.ChargingThread.Resume();
            chargeThread.ChargingThread.Abort();

            //Assert
            Assert.AreEqual(_phone.BatteryBase.Charge, 50);
        }
        
        [TestMethod]
        public void TestChargeThread() {

            //Arrange
            Init();
            var chargeThread = new ChargeThread(_phone, StubShowBattery) {
                IsTestCharge = true,
                IsCharging = true,
                TestIterations = 6,
                ChargeInterval = 0
            };

            //Act
            chargeThread.ChargingThread.Resume();
            chargeThread.ChargingThread.Join();

            //TearDown
            chargeThread.DischargingThread.Join();
            chargeThread.DischargingThread.Abort();
            chargeThread.ChargingThread.Abort();

            //Assert
            Assert.AreEqual(_phone.BatteryBase.Charge, 95);
        }
        
        [TestMethod]
        public void TestDischargeTask() {

            //Arrange
            Init();
            var chargeTask = new ChargeTask(_phone, StubShowBattery) {
                IsTestDischarge = true,
                TestIterations = 40,
                DischargeInterval = 0
            };

            //Act
            chargeTask.DischargingTask.Wait();

            //TearDown
            chargeTask.StopDischarge();
          
            //Assert
            Assert.AreEqual(_phone.BatteryBase.Charge, 50);
        }
        
        [TestMethod]
        public void TestChargeTask() {

            //Arrange
            Init();
            var chargeTask = new ChargeTask(_phone, StubShowBattery) {
                IsTestCharge = true,
                IsCharging = true,
                TestIterations = 5,
                ChargeInterval = 0
            };
            
            //Act
            chargeTask.Start();
            chargeTask.ChargingTask.Wait();

            //TearDown
            chargeTask.StopDischarge();
            chargeTask.Stop();

            //Assert
            Assert.AreEqual(_phone.BatteryBase.Charge, 95);
        }
        
    }

}
