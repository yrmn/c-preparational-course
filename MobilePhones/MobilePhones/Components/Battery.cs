using System;

namespace MobilePhones.Components {
    
    public abstract class BatteryBase {

        public abstract void Charge();

    }
    
    public class Battery : BatteryBase {

        private double size;
        private int volume;

        public double Size
        {
            get { return size; }
            set { size = value; }
        }

        public int Volume
        {
            get { return volume; }
            set { volume = value; }
        }

        public Battery() {}

        public Battery(double size, int volume) {
            this.size = size;
            this.volume = volume;
        }

        public override string ToString() {
            return "Simple battery";
        }

        public override void Charge() {
            Console.WriteLine("Battery is charging");
        }

    }

    public class AlcatelBattery : Battery {

        public AlcatelBattery() : base() {}

        public override string ToString() {
            return "Alcatel battery";
        }

    }

    public class CasioBattery : Battery {

        public CasioBattery() : base() {}

        public override string ToString() {
            return "Casio battery";
        }

    }

}
