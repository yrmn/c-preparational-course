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
using ClassLibPhone.Component_Interfaces;
using ClassLibPhone.Peripherals;

namespace WinFormsPhone {

    public partial class Phone : Form {

        private int _clickNum = 0;
        private MobilePhone phone = new SimCorpMobile();
        private IOutput output;
        
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            _clickNum++;
            switch (_clickNum) {
                case 1:
                    IPlayback playback;
                    if (Option1.Checked) {
                        playback = new MeizuHeadset(output);
                    } else if (Option2.Checked) {
                        playback = new SamsungHeadset(output);
                    } else if (Option3.Checked) {
                        playback = new UnofficialiPhoneHeadset(output);
                    } else if (Option4.Checked) {
                        playback = new PortableSpeaker(output);
                    } else {
                        throw new ArgumentOutOfRangeException();
                    }
                    phone.PlaybackComponent = playback;
                    output.WriteLine($"{playback.GetType().Name} playback selected");
                    output.WriteLine("Set playback to Mobile...");
                    output.WriteLine("Play sound in Mobile:");
                    phone.Play("Song");
                    FormTopLabel = "Select charger component (specify index):";
                    FormOption1 = "1 - SamsungCharger";
                    FormOption2 = "2 - MeizuCharger";
                    FormOption3 = "3 - OfficialiPhoneCharger";
                    FormOption4 = "";
                    Option1.Checked = true;
                    break;
                case 2:
                    output.WriteLine("");
                    ICharger charger;
                    if (Option1.Checked) {
                        charger = new SamsungCharger(output);
                    } else if (Option2.Checked) {
                        charger = new MeizuCharger(output);
                    } else if (Option3.Checked) {
                        charger = new OfficialiPhoneCharger(output);
                    } else {
                        throw new ArgumentOutOfRangeException();
                    }
                    phone.ChargerComponent = charger;
                    output.WriteLine($"{charger.GetType().Name} selected");
                    output.WriteLine("Plug in charger to Mobile:");
                    phone.Charge(null);
                    FormTopLabel = "Select protector component (specify index):";
                    FormOption1 = "1 - LeatherProtector";
                    FormOption2 = "2 - SteelProtector";
                    FormOption3 = "";
                    FormOption4 = "";
                    Option1.Checked = true;
                    break;
                case 3:
                    output.WriteLine("");
                    IProtector protector;
                    if (Option1.Checked) {
                        protector = new LeatherProtector(output);
                    } else if (Option2.Checked) {
                        protector = new SteelProtector(output);
                    } else {
                        throw new ArgumentOutOfRangeException();
                    }
                    phone.ProtectorComponent = protector;
                    output.WriteLine($"{protector.GetType().Name} selected");
                    output.WriteLine("Put protector on Mobile:");
                    phone.Put(protector);
                    break;
            }
        }
        
        public Phone() {
            InitializeComponent();
        }
        
        public IOutput Output {
            set {
                output = value;
            }
        }

        public string FormOutput {
            get {
                return OutText.Text;
            }
            set {
                OutText.Text = value;
            }
        }

        public string FormTopLabel {
            set {
                TopLabel.Text = value;
            }
        }

        public string FormOption1 {
            set {
                Option1.Text = value;
                Option1.Visible = !String.IsNullOrEmpty(value);
            }
        }

        public string FormOption2 {
            set {
                Option2.Text = value;
                Option2.Visible = !String.IsNullOrEmpty(value);
            }
        }

        public string FormOption3 {
            set {
                Option3.Text = value;
                Option3.Visible = !String.IsNullOrEmpty(value);
            }
        }
        
        public string FormOption4 {
            set {
                Option4.Text = value;
                Option4.Visible = !String.IsNullOrEmpty(value);
            }
        }

    }
}
