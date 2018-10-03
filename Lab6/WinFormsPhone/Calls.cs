using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibPhone.Call_Utilities;

namespace WinFormsPhone {

    public partial class Calls : Form {
        
        public List<Call> CallList { get; set; } = new List<Call>();
        
        private CallTask _callTask;
        private bool _areCallsRun;

        public Calls() {
            InitializeComponent();
        }
        
        private void ShowCalls(List<Call> calls) {
            CallsListView.Items.Clear();
            calls.Sort();
            int associateCounter = 0;
            foreach (Call call in calls) {
                if (associateCounter > 0) {
                    associateCounter--;
                    continue;
                }
                associateCounter = call.AssociatedCalls.Count;
                var callTime =  call.CallTime.ToString(CultureInfo.InvariantCulture);
                if (call.AssociatedCalls.Count > 0) {
                    var item = new ListViewItem(new[] {call.Contact.Name, callTime}) {BackColor = Color.Khaki};
                    CallsListView.Items.Add(item);
                }
                else {
                    CallsListView.Items.Add(new ListViewItem(new[] { call.Contact.Name, callTime }));
                }
            }
        }
        
        private void Calls_Load(object sender, EventArgs e) {
            _callTask = new CallTask();
            _callTask.CallReceived += OnCallReceived;
        }
        
        public void OnCallReceived(Call call) {
            if (InvokeRequired) {
                Invoke(new CallTask.CallRecievedDelegate(OnCallReceived), call);
                return;
            }
            if (CallList.Count > 0) {
                if (CallList[0].Equals(call)) {
                    call.AssociatedCalls.Add(CallList[0]);
                    if (CallList[0].AssociatedCalls.Count > 0) {
                        foreach (Call associatedCall in CallList[0].AssociatedCalls) {
                            call.AssociatedCalls.Add(associatedCall);
                        }
                    }
                }
            }
            CallList.Add(call);
            ShowCalls(CallList);
        }
        
        private void CallsListView_SelectedIndexChanged(object sender, EventArgs e) {
            AssociatedListView.Items.Clear();
            if (CallsListView.SelectedItems.Count == 0) {
                return;
            }
            var selectedItem = CallsListView.SelectedItems[0];
            String text = selectedItem.SubItems[1].Text;
            var dateTime = DateTime.ParseExact(text, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            Call selectedCall = CallList.Find(x => (x.CallTime.Second == dateTime.Second) && (x.CallTime.Minute == dateTime.Minute));
            if (selectedCall == null) {
                return;
            }
            if (selectedCall.AssociatedCalls.Count == 0) {
                return;
            }
            foreach (Call message in selectedCall.AssociatedCalls) {
                string formattedText = message.CallTime.ToString(CultureInfo.InvariantCulture);
                AssociatedListView.Items.Add(new ListViewItem(new[] { message.Contact.Name, formattedText, text }));
            }
        }

        private void buttonCalls_Click(object sender, EventArgs e) {
            _areCallsRun = !_areCallsRun;
            if (_areCallsRun) {
                buttonCalls.Text = "Stop calls";
                _callTask.Start();
            } else {
                buttonCalls.Text = "Start calls";
                _callTask.Stop();
            }
        }
    }

}
