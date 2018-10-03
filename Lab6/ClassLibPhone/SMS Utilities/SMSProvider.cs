using System;
using System.Threading;
using ClassLibPhone.Utilities;

namespace ClassLibPhone.SMS_Utilities {

    internal abstract class SMSProvider {

        private int _msgNum;
        private readonly MessageStorage _messageStorage = MessageStorage.Instance;
        public bool AreMessagesRun { get; set; }

        public abstract void Start();

        public abstract void Stop();
        
        public void AddMessage(Message message) {
            _messageStorage.AddMessage(message);
        }

        public void DeleteMessage(Message message) {
            _messageStorage.DeleteMessage(message);
        }
        
        public void ReceiveMessage(string userName) {
            _msgNum++;
            var txt = "Message #" + _msgNum + " from " + userName + " received!";
            var msg = new Message { User = userName, Text = txt, ReceivingTime = DateTime.Now };
            _messageStorage.ReceiveMessage(msg);
        }
        
    }

}
