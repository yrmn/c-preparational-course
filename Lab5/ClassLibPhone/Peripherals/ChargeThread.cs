using System;
using System.Threading;

namespace ClassLibPhone.Peripherals {

    public class ChargeThread : ChargeProvider {
        
        public Thread ChargingThread { get; }
        public Thread DischargingThread { get; }
        
        public ChargeThread(MobilePhone phone, Action ShowBattery) {
            ChargingThread = new Thread(
                () => {
                    while (IsCharging) {
                        // for unit test only — to stop thread after certain number of iterations
                        if (IsTestCharge) {
                            Endless++;
                            if (Endless >= TestIterations)
                                IsCharging = false;
                        }
                        // end for unit test
                        Thread.Sleep(ChargeInterval);
                        lock (phone.BatteryBase) {
                            phone.Charge();
                        }
                    }
                }) { IsBackground = true };
            ChargingThread.Start();
            ChargingThread.Suspend();
            DischargingThread = new Thread(
                () => {
                    // if not in unit test — discharging process is always active
                    while (Endless < TestIterations) {
                        if (IsTestDischarge) {
                            Endless++;
                        }
                        ShowBattery();
                        Thread.Sleep(DischargeInterval);
                        lock (phone.BatteryBase) {
                            phone.Discharge();
                        }
                    }
                }) { IsBackground = true };
            DischargingThread.Start();
        }

        public override void Start() {
            ChargingThread.Resume();
        }

        public override void Stop() {
            ChargingThread.Suspend();
        }
        
    }

}
