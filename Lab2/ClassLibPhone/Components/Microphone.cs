using System;

namespace ClassLibPhone.Components {

    public abstract class MicrophoneBase {

        public abstract void Record();

    }
    
    public class Microphone : MicrophoneBase {

        private int volume = 55;

        public int Volume
        {
            get { return volume; }
            set { volume = value; }
        }

        public Microphone() {}

        public Microphone(int volume) {
            this.volume = volume;
        }

        public override string ToString() {
            return "Simple microphone";
        }

        public override void Record() {
            Console.WriteLine("Microphone is on air");
        }

    }

    public class SonyMic : Microphone {

        public SonyMic() : base() {}

        public override string ToString() {
            return "Sony microphone";
        }

    }

    public class BlueYeti : SonyMic {

        public BlueYeti() : base() {}

        public override string ToString() {
            return "BlueYeti microphone";
        }

    }

}
