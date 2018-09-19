using System;

namespace ClassLibPhone.Components {
    
    public abstract class DynamicBase {

        public abstract void Beep();

    }
    
    public class Dynamic : DynamicBase {

        private int volume = 22;

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
    
    public class StereoDynamic : Dynamic {

        public StereoDynamic() : base() {}

        public override string ToString() {
            return "Stereo dynamic";
        }

    }

    public class HiFiDynamic : StereoDynamic {

        public HiFiDynamic() : base() {}

        public override string ToString() {
            return "HiFi dynamic";
        }

    }
    
}
