using System;

namespace MobilePhones.Components {
    
    public abstract class SimCardBase {

        public abstract string Pin { get; }
        public abstract string Puk { get; }
        public abstract string UserNumber { get; }

    }

    public class SimCard : SimCardBase {

        private double vSize = 3.5;
        private string vPin = "1111";
        private string vPuk = "1097";
        private string vUserNumber = "1234567";

        public double Size
        {
            get { return vSize; }
        }

        public override string Pin
        {
            get { return vPin; }
        }

        public override string Puk
        {
            get { return vPuk; }
        }

        public override string UserNumber
        {
            get { return vUserNumber; }
        }
        
        public SimCard() {}

        public SimCard(double vSize) {
            this.vSize = vSize;
        }

        public override string ToString() {
            return "Simple simcard";
        }
        
    }

    public class NewSimCard : SimCard {

        public NewSimCard() : base() { }

        public override string ToString() {
            return "New simcard";
        }

    }

}
