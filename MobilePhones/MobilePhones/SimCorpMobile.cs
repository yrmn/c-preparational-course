using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhones.Components;

namespace MobilePhones {
    public class SimCorpMobile : MobilePhone {

        private readonly FourthGen vFourthGen = new FourthGen();
        private readonly CasioBattery vCasioBattery = new CasioBattery();
        private readonly StereoDynamic vStereoDynamic = new StereoDynamic();
        private readonly TouchKeyboard vTouchKeyboard = new TouchKeyboard();
        private readonly BlueYeti vBlueYeti = new BlueYeti();
        private readonly MultiTouch vMultiTouch = new MultiTouch();
        private readonly NewSimCard vNewSimCard = new NewSimCard();

        public override AerialBase AerialBase { get { return vFourthGen; } }
        public override BatteryBase BatteryBase { get { return vCasioBattery; } }
        public override DynamicBase DynamicBase { get { return vStereoDynamic; } }
        public override KeyboardBase KeyboardBase { get { return vTouchKeyboard; } }
        public override MicrophoneBase MicrophoneBase { get { return vBlueYeti; } }
        public override ScreenBase ScreenBase { get { return vMultiTouch; } }
        public override SimCardBase SimCardBase { get { return vNewSimCard; } }
        
    }

}
