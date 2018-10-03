using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibPhone;
using ClassLibPhone.Component_Interfaces;
using ClassLibPhone.Peripherals;

namespace MobilePhones {

    class Program {

        static void Main(string[] args) {
            IOutput output = new ConsoleOutput();

            MobilePhone phone;
            phone = new SimCorpMobile();
            output.WriteLine(phone.GetDescription());

            output.WriteLine("");
            output.WriteLine("Select playback component (specify index):");
            output.WriteLine("1 - MeizuHeadset");
            output.WriteLine("2 - SamsungHeadset");
            output.WriteLine("3 - UnofficialiPhoneHeadset");
            output.WriteLine("4 - PortableSpeaker");
            
            int value;
            bool isBadInput;

            do
            {
                isBadInput = !int.TryParse(Console.ReadLine(), out value);
                if (isBadInput || value > 4 || value < 1)
                {
                    output.WriteLine("Wrong value, please try again: ");
                    isBadInput = true;
                }
            } while (isBadInput);

            IPlayback playback;
            switch (value) {
                case 1:
                    playback = new MeizuHeadset(output);
                    break;
                case 2:
                    playback = new SamsungHeadset(output);
                    break;
                case 3:
                    playback = new UnofficialiPhoneHeadset(output);
                    break;
                case 4:
                    playback = new PortableSpeaker(output);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            phone.PlaybackComponent = playback;
            output.WriteLine($"{playback.GetType().Name} playback selected");
            output.WriteLine("Set playback to Mobile...");
            output.WriteLine("Play sound in Mobile:");
            phone.Play("Song");

            //next

            output.WriteLine("");
            output.WriteLine("Select charger component (specify index):");
            output.WriteLine("1 - SamsungCharger");
            output.WriteLine("2 - MeizuCharger");
            output.WriteLine("3 - OfficialiPhoneCharger");
            
            do {
                isBadInput = !int.TryParse(Console.ReadLine(), out value);
                if (isBadInput || value > 3 || value < 1) {
                    output.WriteLine("Wrong value, please try again: ");
                    isBadInput = true;
                }
            } while (isBadInput);

            ICharger charger;
            switch (value) {
                case 1:
                    charger = new SamsungCharger(output);
                    break;
                case 2:
                    charger = new MeizuCharger(output);
                    break;
                case 3:
                    charger = new OfficialiPhoneCharger(output);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            phone.ChargerComponent = charger;
            output.WriteLine($"{charger.GetType().Name} selected");
            output.WriteLine("Plug in charger to Mobile:");
            phone.InnerCharge(null);

            //next

            output.WriteLine("");
            output.WriteLine("Select protector component (specify index):");
            output.WriteLine("1 - LeatherProtector");
            output.WriteLine("2 - SteelProtector");

            do {
                isBadInput = !int.TryParse(Console.ReadLine(), out value);
                if (isBadInput || value > 2 || value < 1) {
                    output.WriteLine("Wrong value, please try again: ");
                    isBadInput = true;
                }
            } while (isBadInput);

            IProtector protector;
            switch (value) {
                case 1:
                    protector = new LeatherProtector(output);
                    break;
                case 2:
                    protector = new SteelProtector(output);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            phone.ProtectorComponent = protector;
            output.WriteLine($"{protector.GetType().Name} selected");
            output.WriteLine("Put protector on Mobile:");
            phone.Put(protector);
            
            Console.ReadLine();
        }

    }
    
}
