using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibPhone;

namespace WinFormsPhone {

    public class WinFormOutput : IOutput {

        private Phone phone;
        
        public WinFormOutput(Phone phone) {
            this.phone = phone;
        }

        public void Write(string text) {
            phone.FormOutput += text;
        }

        public void WriteLine(string text) {
            phone.FormOutput += text + "\r\n";
        }

    }

}
