using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibPhone.Peripherals {

    public class ChargeTaskFactory : ChargeFactory {

        private readonly MobilePhone _phone;
        private readonly Action ShowBattery;

        public ChargeTaskFactory(MobilePhone phone, Action ShowBattery) {
            _phone = phone;
            this.ShowBattery = ShowBattery;
        }

        public override ChargeProvider GetCharger() {
            return new ChargeTask(_phone, ShowBattery);
        }
        
    }

}
