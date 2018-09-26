using ClassLibPhone.Utilities;

namespace ClassLibPhone.SMS_Utilities {

    internal class SMSProvider {

        private readonly MessageStorage _messageStorage = MessageStorage.Instance;
        
        public void AddMessage(Message message) {
            _messageStorage.AddMessage(message);
        }

        public void DeleteMessage(Message message) {
            _messageStorage.DeleteMessage(message);
        }
        
    }

}
