using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibPhone;
using ClassLibPhone.Utilities;

namespace WinFormsPhone {

    public partial class SMSScreen : Form {

        private SMSProvider _sms;
        private int _msgNum;
        
        private readonly SMSFormat _format = new SMSFormat();
        
        public SMSScreen() {
            InitializeComponent();
        }
        
        private void SMSScreen_Load(object sender, EventArgs e) {
            Timer.Enabled = true;
            _sms = new SMSProvider();
            _sms.SMSReceived += OnSMSReceived;
        }
        
        private void Timer_Tick(object sender, EventArgs e) {
            _msgNum++;
            _sms.ReceiveMessage("Message #" + _msgNum + " received!");
        }
        
        private void FormatSelect_SelectedIndexChanged(object sender, EventArgs e) {
            _format.ApplyFormat(FormatSelect.SelectedIndex);
        }

        public void OnSMSReceived(string message) {
            if (InvokeRequired) {
                Invoke(new SMSProvider.SMSRecievedDelegate(OnSMSReceived), message);
                return;
            }
            string formattedMessage = _format.Formatter(message);
            formattedMessage += Environment.NewLine;
            MessageScreen.AppendText(formattedMessage);
        }
        
    }

}
