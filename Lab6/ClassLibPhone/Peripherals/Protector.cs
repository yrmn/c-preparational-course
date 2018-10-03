using ClassLibPhone.Component_Interfaces;

namespace ClassLibPhone.Peripherals {

    public class LeatherProtector : IProtector {

        private IOutput _output;

        public LeatherProtector(IOutput output) {
            _output = output;
        }

        public void Put(object data) {
            _output.WriteLine($"Phone is covered with {nameof(LeatherProtector)}");
        }

    }

    public class SteelProtector : IProtector {

        private IOutput _output;

        public SteelProtector(IOutput output) {
            _output = output;
        }

        public void Put(object data) {
            _output.WriteLine($"Phone is covered with {nameof(SteelProtector)}");
        }

    }

}
