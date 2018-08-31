using System;

namespace MobilePhones.Components {
    
    public abstract class SimCardBase {

        public abstract void Eject();
        
    }

    public class SimCard : SimCardBase {

        private double size;

        public double Size
        {
            get { return size; }
            set { size = value; }
        }

        public SimCard() {}

        public SimCard(double size) {
            this.size = size;
        }

        public override string ToString() {
            return "Simple simcard";
        }

        public override void Eject()
        {
            Console.WriteLine("SimCard has been ejected");
        }
  
    }

    public class NewSimCard : SimCard {

        public NewSimCard() : base() { }

        public override string ToString() {
            return "New simcard";
        }

    }

}
