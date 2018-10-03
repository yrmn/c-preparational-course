using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibPhone;
using ClassLibPhone.Component_Interfaces;
using ClassLibPhone.Peripherals;

namespace WinFormsPhone {
    static class Program {

        private const int Lab = 6;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            switch (Lab) {
                case 2:
                    Phone formPhone = new Phone();
                    formPhone.FormTopLabel = "Select playback component (specify index):";
                    formPhone.FormOption1 = "1 - MeizuHeadset";
                    formPhone.FormOption2 = "2 - SamsungHeadset";
                    formPhone.FormOption3 = "3 - UnofficialiPhoneHeadset";
                    formPhone.FormOption4 = "4 - PortableSpeaker";
                    IOutput output = new WinFormOutput(formPhone);
                    formPhone.Output = output;
                    Application.Run(formPhone);
                    break;
                case 3:
                case 4:
                case 5:
                    bool isTaskForMessages, isTaskForBattery;
                    Console.WriteLine("Select approach to asynchronous message processing:");
                    Console.WriteLine("1 - Threads");
                    Console.WriteLine("2 - Tasks");
                    int value;
                    bool isBadInput;
                    do {
                        isBadInput = !int.TryParse(Console.ReadLine(), out value);
                        if (isBadInput || value > 2 || value < 1) {
                            Console.WriteLine("Wrong value, please try again: ");
                            isBadInput = true;
                        }
                    } while (isBadInput);
                    switch (value) {
                        case 1:
                            isTaskForMessages = false;
                            break;
                        case 2:
                            isTaskForMessages = true;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    Console.WriteLine("Select approach to asynchronous battery charging:");
                    Console.WriteLine("1 - Threads");
                    Console.WriteLine("2 - Tasks");
                    do {
                        isBadInput = !int.TryParse(Console.ReadLine(), out value);
                        if (isBadInput || value > 2 || value < 1) {
                            Console.WriteLine("Wrong value, please try again: ");
                            isBadInput = true;
                        }
                    } while (isBadInput);
                    switch (value) {
                        case 1:
                            isTaskForBattery = false;
                            break;
                        case 2:
                            isTaskForBattery = true;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    var formSMS = new SMSScreen(isTaskForMessages, isTaskForBattery);
                        Application.Run(formSMS);
                        break;
                case 6:
                    var formCalls = new Calls();
                    Application.Run(formCalls);
                    break;
            }
        }
    }
}
