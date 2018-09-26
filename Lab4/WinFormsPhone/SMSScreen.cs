using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ClassLibPhone;
using ClassLibPhone.SMS_Utilities;
using ClassLibPhone.Utilities;
using Message = ClassLibPhone.Utilities.Message;

namespace WinFormsPhone {

    public partial class SMSScreen : Form {
        
        private MessageStorage _sms;
        private int _msgNum;
        private bool _isFilterUser, _isFilterText, _isFilterDate, _isOR;
        private readonly SMSFormat _format = new SMSFormat();
        private readonly MobilePhone _phone = new SimCorpMobile();

        public SMSScreen() {
            InitializeComponent();
        }
        
        private void SMSScreen_Load(object sender, EventArgs e) {
            TimerAlex.Enabled = TimerBill.Enabled = TimerCynthia.Enabled = true;
            _sms = MessageStorage.Instance;
            _sms.SMSReceived += OnSMSReceived;
        }
        
        private void TimerAlex_Tick(object sender, EventArgs e) {
            ReceiveMessage("Alex");
        }
        
        private void TimerBill_Tick(object sender, EventArgs e) {
            ReceiveMessage("Bill");
        }

        private void TimerCynthia_Tick(object sender, EventArgs e) {
            ReceiveMessage("Cynthia");
        }
        
        private void FormatSelect_SelectedIndexChanged(object sender, EventArgs e) {
            _format.ApplyFormat(FormatSelect.SelectedIndex);
        }

        private void comboBoxUser_SelectedIndexChanged(object sender, EventArgs e) {
            _isFilterUser = true;
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e) {
            _isFilterText = true;
        }

        private void dateTimeFrom_ValueChanged(object sender, EventArgs e) {
            _isFilterDate = true;
        }

        private void dateTimeTo_ValueChanged(object sender, EventArgs e) {
            _isFilterDate = true;
        }

        private void checkBoxFilter_CheckedChanged(object sender, EventArgs e) {
            _isOR = checkBoxFilter.Checked;
        }

        private void ReceiveMessage(string userName) {
            _msgNum++;
            var txt = "Message #" + _msgNum + " from " + userName + " received!";
            var msg = new Message { User = userName, Text = txt, ReceivingTime = DateTime.Now };
            _sms.ReceiveMessage(msg);
        }

        private void ShowMessages(List<Message> messages) {
            MessageListView.Items.Clear();
            foreach (Message message in messages) {
                string formattedText = _format.Formatter(message.Text, message.ReceivingTime);
                MessageListView.Items.Add(new ListViewItem(new[] { message.User, formattedText }));
            }
        }
        
        private List<Message> ApplyFilters() {
            var userName = Convert.ToString(comboBoxUser.SelectedItem);
            var res = _sms.MsgList;
            if (!_isOR) {
                res = Filter.FilterAND(res, _isFilterUser, _isFilterText, _isFilterDate, userName, textBoxFilter.Text,
                    dateTimeFrom.Value, dateTimeTo.Value);
                return res;
            }
            res = Filter.FilterOR(res, _isFilterUser, _isFilterText, _isFilterDate, userName, textBoxFilter.Text,
                dateTimeFrom.Value, dateTimeTo.Value);
            return res;
        }
        
        public void OnSMSReceived(Message message) {
            if (InvokeRequired) {
                Invoke(new MessageStorage.SMSRecievedDelegate(OnSMSReceived), message);
                return;
            }
            _phone.IncomingMessage(message);
            // fill users for ComboBox
            string[] uniqueUsers = Filter.GetUniqueUsers(_sms.MsgList);
            foreach (string value in uniqueUsers) {
                if (!comboBoxUser.Items.Contains(value)) {
                    comboBoxUser.Items.Add(value);
                }
            }
            List<Message> filteredList = ApplyFilters();
            ShowMessages(filteredList);
        }

    }

}
