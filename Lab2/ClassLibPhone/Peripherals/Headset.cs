using ClassLibPhone.Component_Interfaces;

namespace ClassLibPhone.Peripherals {

    public class MeizuHeadset : IPlayback {

        private IOutput _output;

        public MeizuHeadset(IOutput output) {
            _output = output;
        }

        public void Play(object data) {
            _output.WriteLine($"{nameof(MeizuHeadset)} sound");
        }

    }
    
    public class SamsungHeadset : IPlayback {

        private IOutput _output;

        public SamsungHeadset(IOutput output) {
            _output = output;
        }

        public void Play(object data) {
            _output.WriteLine($"{nameof(SamsungHeadset)} sound");
        }

    }
    
    public class UnofficialiPhoneHeadset : IPlayback {

        private IOutput _output;

        public UnofficialiPhoneHeadset(IOutput output) {
            _output = output;
        }

        public void Play(object data) {
            _output.WriteLine($"{nameof(UnofficialiPhoneHeadset)} sound");
        }

    }
    
    public class PortableSpeaker : IPlayback {

        private IOutput _output;

        public PortableSpeaker(IOutput output) {
            _output = output;
        }

        public void Play(object data) {
            _output.WriteLine($"{nameof(PortableSpeaker)} sound");
        }

    }
    
}
