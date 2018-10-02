using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibPhone.Peripherals {

    public class ChargeTask : ChargeProvider {
        
        private readonly MobilePhone _phone;
        private readonly Action ShowBattery;
        private CancellationTokenSource _tokenCancelCharge, _tokenCancelDischarge;
        public Task ChargingTask { get; set; }
        public Task DischargingTask { get; set; }
        
        public ChargeTask(MobilePhone phone, Action ShowBattery) {
            _phone = phone;
            this.ShowBattery = ShowBattery;
            _tokenCancelDischarge = new CancellationTokenSource();
            var token = _tokenCancelDischarge.Token;
            DischargingTask = Task.Run(
                async () => {
                    // if not in unit test — discharging process is always active
                    while (Endless < TestIterations) {
                        if (IsTestDischarge) {
                            Endless++;
                        }
                        ShowBattery();
                        await Task.Delay(DischargeInterval, token);
                        lock (_phone.BatteryBase) {
                            _phone.Discharge();
                        }
                        if (token.IsCancellationRequested) {
                            break;
                        }
                    }
                }, token);
        }
        
        public override void Start() {
            _tokenCancelCharge = new CancellationTokenSource();
            var token = _tokenCancelCharge.Token;
            ChargingTask = Task.Run(
                async () => {
                    while (IsCharging) {
                        // for unit test only — to stop task after certain number of iterations
                        if (IsTestCharge) {
                            Endless++;
                            if (Endless >= TestIterations)
                                IsCharging = false;
                        }
                        // end for unit test
                        await Task.Delay(ChargeInterval, token);
                        lock (_phone.BatteryBase) {
                            _phone.Charge();
                        }
                        if (token.IsCancellationRequested) {
                            break;
                        }
                    }
                }, token);
        }

        public override void Stop() {
            _tokenCancelCharge.Cancel();
        }

        // for test only
        public void StopDischarge() {
            _tokenCancelDischarge.Cancel();
        }

    }

}
