using System;

namespace MobilePhones.Components {
    
    public abstract class BatteryBase {

        public abstract void Charge();

    }
    
    public class Battery : BatteryBase {

        private double type = 3.4;
        private int capacity = 18;

        public double Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public Battery() {}

        public Battery(double type, int capacity) {
            this.type = type;
            this.capacity = capacity;
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
