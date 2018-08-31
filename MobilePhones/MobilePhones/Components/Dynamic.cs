using System;

namespace MobilePhones.Components {
    
    public abstract class DynamicBase {

        public abstract void Beep();

    }
    
    public class Dynamic : DynamicBase {

        private int volume;

        public int Volume
        {
            get { return volume; }
            set { volume = value; }
        }

        public Dynamic() {}

        public Dynamic(int volume) {
            this.volume = volume;
        }

        public override string ToString() {
            return "Simple dynamic";
        }

        public override void Beep() {
            Console.WriteLine("Dynamic makes beep");
        }
        
    }
    
    public class HiFiDynamic : Dynamic {

        public HiFiDynamic() : base() {}

        public override string ToString() {
            return "HiFi dynamic";
        }

    }

    public class StereoDynamic : HiFiDynamic {

        public StereoDynamic() : base() {}

        public override string ToString() {
            return "Stereo dynamic";
        }

    }
    
}
