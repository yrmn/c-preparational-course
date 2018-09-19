using ClassLibPhone.Component_Interfaces;

namespace ClassLibPhone.Peripherals {

    public class SamsungCharger : ICharger  {
        
        private IOutput _output;

        public SamsungCharger(IOutput output) {
            _output = output;
        }
        
        public void Charge(object data) {
            _output.WriteLine($"Phone is charging with {nameof(SamsungCharger)}");
        }

    }

    public class MeizuCharger : ICharger {

        private IOutput _output;

        public MeizuCharger(IOutput output) {
            _output = output;
        }

        public void Charge(object data) {
            _output.WriteLine($"Phone is charging with {nameof(MeizuCharger)}");
        }

    }

    public class OfficialiPhoneCharger : ICharger {

        private IOutput _output;

        public OfficialiPhoneCharger(IOutput output) {
            _output = output;
        }

        public void Charge(object data) {
            _output.WriteLine($"Phone is charging with {nameof(OfficialiPhoneCharger)}");
        }

    }
    
}
