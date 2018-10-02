using System.Threading;

namespace ClassLibPhone.SMS_Utilities {

    internal class SMSThread : SMSProvider {
        
        public Thread MessagesThread { get; }
        
        public SMSThread() {
            // thread instead of timer for generating incoming messages
            MessagesThread = new Thread(
                () => {
                    while (AreMessagesRun) {
                        Thread.Sleep(1000);
                        ReceiveMessage("Alex");
                        Thread.Sleep(2000);
                        ReceiveMessage("Bill");
                        Thread.Sleep(1000);
                        ReceiveMessage("Cynthia");
                    }
                }) { IsBackground = true };
            MessagesThread.Start();
            MessagesThread.Suspend();
        }
        
        public override void Start() {
            MessagesThread.Resume();
        }

        public override void Stop() {
            MessagesThread.Suspend();
        }
        
    }

}
