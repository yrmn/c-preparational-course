using System;

namespace ClassLibPhone.Components {
    
    public abstract class BatteryBase {

        public abstract void ChargeNotification();

        public abstract int Charge { get; set; }
        
    }
    
    public class Battery : BatteryBase {

        private double _type = 3.4;
        private int _capacity = 90;
        
        public double Type {
            get { return _type; }
            set { _type = value; }
        }
        
        public override int Charge {
            get { return _capacity; }
            set { _capacity = value; }
        }
        
        public Battery() {}

        public Battery(double type, int capacity) {
            _type = type;
            _capacity = capacity;
        }

        public override string ToString() {
            return "Simple battery";
        }

        public override void ChargeNotification() {
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
