using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibPhone.SMS_Utilities {

    internal class SMSTask : SMSProvider {

        private CancellationTokenSource _tokenCancel;
        public Task MessagesTask { get; set; }
        
        public override void Start() {
            _tokenCancel = new CancellationTokenSource();
            var token = _tokenCancel.Token;
            // task instead of timer for generating incoming messages
            MessagesTask = Task.Run(
                async () => {
                    while (AreMessagesRun) {
                        await Task.Delay(1000, token);
                        ReceiveMessage("Alex");
                        await Task.Delay(2000, token);
                        ReceiveMessage("Bill");
                        await Task.Delay(1000, token);
                        ReceiveMessage("Cynthia");
                        if (token.IsCancellationRequested) {
                            break;
                        }
                    }
                }, token);
        }

        public override void Stop() {
            _tokenCancel.Cancel();
        }

    }

}
