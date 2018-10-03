using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibPhone.Call_Utilities {

    public class CallTask {

        private int _counterBill;
        private CancellationTokenSource _tokenCancel;
        public Task CallingTask { get; set; }
        
        public delegate void CallRecievedDelegate(Call call);
        public event CallRecievedDelegate CallReceived;

        private void RaiseCallReceivedEvent(Call call) {
            var handler = CallReceived;
            if (handler != null) {
                handler(call);
            }
        }

        public void ReceiveCall(Call call) {
            RaiseCallReceivedEvent(call);
        }
        
        public void Start() {
            _tokenCancel = new CancellationTokenSource();
            var token = _tokenCancel.Token;
            CallingTask = Task.Run(
                async () => {
                    while (true) {
                        _counterBill++;
                        if (_counterBill % 3 == 0) {
                            DoCall("Bill");
                            await Task.Delay(2000, token);
                        }
                        DoCall("Alex");
                        await Task.Delay(3000, token);
                        if (token.IsCancellationRequested) {
                            break;
                        }
                    }
                }, token);
        }

        public  void Stop() {
            _tokenCancel.Cancel();
        }
        
        private void DoCall(string name) {
            var cc = new Contact {
                Name = name,
                PhonesList = new List<string>() {"2222", "222223"}
            };
            var call = new Call {
                Contact = cc,
                CallTime = DateTime.Now,
                Direction = Call.CallDirection.Incoming
            };
            ReceiveCall(call);
        }
        
    }

}
