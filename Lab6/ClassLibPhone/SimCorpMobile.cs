using ClassLibPhone.Components;
using ClassLibPhone.SMS_Utilities;

namespace ClassLibPhone {
    public class SimCorpMobile : MobilePhone {

        private readonly FourthGen vFourthGen;
        private readonly CasioBattery vCasioBattery;
        private readonly HiFiDynamic vHiFiDynamic;
        private readonly TouchKeyboard vTouchKeyboard;
        private readonly BlueYeti vBlueYeti;
        private readonly MultiTouch vMultiTouch;
        private readonly NewSimCard vNewSimCard;

        public override AerialBase AerialBase { get { return vFourthGen; } }
        public override BatteryBase BatteryBase { get { return vCasioBattery; } }
        public override DynamicBase DynamicBase { get { return vHiFiDynamic; } }
        public override KeyboardBase KeyboardBase { get { return vTouchKeyboard; } }
        public override MicrophoneBase MicrophoneBase { get { return vBlueYeti; } }
        public override ScreenBase ScreenBase { get { return vMultiTouch; } }
        public override SimCardBase SimCardBase { get { return vNewSimCard; } }
        
        public SimCorpMobile(bool isTaskForMessages = false) {
            SMSProvider = isTaskForMessages
                ? (SMSProvider) new SMSTask()
                : new SMSThread();
            this.vFourthGen = new FourthGen();
            this.vCasioBattery = new CasioBattery();
            this.vHiFiDynamic = new HiFiDynamic();
            this.vTouchKeyboard = new TouchKeyboard();
            this.vBlueYeti = new BlueYeti();
            this.vMultiTouch = new MultiTouch();
            this.vNewSimCard = new NewSimCard();
        }

    }

}
