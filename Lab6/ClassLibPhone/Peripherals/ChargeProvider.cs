using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibPhone.Peripherals {

    public abstract class ChargeProvider {

        public int ChargeInterval { get; set; } = 1000;
        public int DischargeInterval { get; set; } = 2000;
        public bool IsCharging { get; set; }

        protected int Endless; // is used for endless process of phone discharging
        public bool IsTestCharge { get; set; } = false;
        public bool IsTestDischarge { get; set; } = false;
        public int TestIterations { get; set; } = 1;

        public abstract void Start();

        public abstract void Stop();

    }

}
