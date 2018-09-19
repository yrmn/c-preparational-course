namespace ClassLibPhone {

    public class SMSProvider
    {

        public delegate void SMSRecievedDelegate(string message);

        public event SMSRecievedDelegate SMSReceived;
        
        private void RaiseSMSReceivedEvent(string message) {
            var handler = SMSReceived;
            if (handler != null) {
                handler(message);
            }
        }
        
        public void ReceiveMessage(string message) {
            RaiseSMSReceivedEvent(message);
        }
        
    }

}
