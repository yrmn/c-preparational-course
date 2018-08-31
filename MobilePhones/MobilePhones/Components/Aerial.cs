using System;

namespace MobilePhones.Components {
    
    public abstract class AerialBase {

        public abstract void SearchFrequency();

    }
    
    public class Aerial : AerialBase {

        private double frequency = 116.1;

        public double Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }

        public Aerial() {}

        public Aerial(double frequency) {
            this.frequency = frequency;
        }

        public override string ToString() {
            return "Simple aerial";
        }

        public override void SearchFrequency() {
            Console.WriteLine("Searching for stable frequency");
        }

    }

    public class ThirdGen : Aerial {

        public ThirdGen() : base() {}

        public override string ToString() {
            return "3G aerial";
        }

    }

    public class FourthGen : Aerial {

        public FourthGen() : base() { }

        public override string ToString() {
            return "4G aerial";
        }

    }

}
