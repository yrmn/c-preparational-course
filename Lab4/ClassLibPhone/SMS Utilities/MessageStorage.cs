using System.Collections.Generic;
using System.Runtime.InteropServices;
using ClassLibPhone.Utilities;

namespace ClassLibPhone.SMS_Utilities {

    public class MessageStorage {

        private static MessageStorage _instance = null;
        private static readonly object _lock = new object();
        // singleton
        public static MessageStorage Instance {
            get {
                lock (_lock) {
                    if (_instance == null) {
                        _instance = new MessageStorage();
                    }
                    return _instance;
                }
            }
        }

        public List<Message> MsgList { get; set; } = new List<Message>();

        public delegate void SMSRecievedDelegate(Message message);
        public event SMSRecievedDelegate SMSReceived;

        public delegate void SMSRemovedDelegate(Message message);
        public event SMSRemovedDelegate SMSRemoved;

        MessageStorage() { }

        private void RaiseSMSReceivedEvent(Message message) {
            var handler = SMSReceived;
            if (handler != null) {
                handler(message);
            }
        }

        private void RaiseSMSRemovedEvent(Message message) {
            var handler = SMSRemoved;
            if (handler != null) {
                handler(message);
            }
        }
        
        public void AddMessage(Message message) {
            MsgList.Insert(0, message);
        }
        
        public void DeleteMessage(Message message) {
            MsgList.Remove(message);
        }
        
        public void ReceiveMessage(Message message) {
            RaiseSMSReceivedEvent(message);
        }
        
        public void RemoveMessage(Message message) {
            RaiseSMSRemovedEvent(message);
        }
        
    }

}
