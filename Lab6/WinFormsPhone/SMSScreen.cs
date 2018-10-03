using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ClassLibPhone;
using ClassLibPhone.Peripherals;
using ClassLibPhone.SMS_Utilities;
using ClassLibPhone.Utilities;
using Message = ClassLibPhone.Utilities.Message;

namespace WinFormsPhone {

    public partial class SMSScreen : Form {
        
        private MessageStorage _sms;
        private bool _isFilterUser, _isFilterText, _isFilterDate, _isOR, _areMessagesRun, _isCharging;
        private readonly bool _isTaskForBattery;
        private ChargeProvider _chargeProvider;
        private readonly SMSFormat _format = new SMSFormat();
        private static MobilePhone _phone;
        
        public SMSScreen(bool isTaskForMessages, bool isTaskForBattery) {
            _isTaskForBattery = isTaskForBattery;
            _phone = new SimCorpMobile(isTaskForMessages);
            InitializeComponent();
        }
        
        private void SMSScreen_Load(object sender, EventArgs e) {
            _sms = MessageStorage.Instance;
            _sms.SMSReceived += OnSMSReceived;
            // display progress bar animation on form
            Action ShowBattery = () => {
                chargeProgress.BeginInvoke(
                    new Action(() => {
                        chargeProgress.Value = _phone.BatteryBase.Charge;
                    }));
            };
            // using Factory Method pattern for determination what class should be used – with Thread or with Tasks
            ChargeFactory factory = null;
            factory = _isTaskForBattery
                ? (ChargeFactory) new ChargeTaskFactory(_phone, ShowBattery)
                : new ChargeThreadFactory(_phone, ShowBattery);
            _chargeProvider = factory.GetCharger();
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
        
        private void buttonGoMessages_Click(object sender, EventArgs e) {
            _areMessagesRun = !_areMessagesRun;
            _phone.Set_AreMessagesRun(_areMessagesRun);
            if (_areMessagesRun) {
                buttonGoMessages.Text = "Stop messages";
                _phone.ResumeMessagesRun();
            } else {
                buttonGoMessages.Text = "Start messages";
                _phone.SuspendMessagesRun();
            }
        }

        private void buttonCharge_Click(object sender, EventArgs e) {
            _isCharging = !_isCharging;
            _chargeProvider.IsCharging = _isCharging;
            if (_isCharging) {
                Text = "Charging";
                buttonCharge.Text = "Discharge";
                _chargeProvider.Start();
            } else {
                Text = "Discharging";
                buttonCharge.Text = "Charge";
                _chargeProvider.Stop();
            }
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
