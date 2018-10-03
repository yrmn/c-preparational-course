using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibPhone.Peripherals {

    public class ChargeThreadFactory : ChargeFactory {

        private readonly MobilePhone _phone;
        private readonly Action ShowBattery;

        public ChargeThreadFactory(MobilePhone phone, Action ShowBattery) {
            _phone = phone;
            this.ShowBattery = ShowBattery;
        }

        public override ChargeProvider GetCharger() {
            return new ChargeThread(_phone, ShowBattery);
        }

    }

}
