using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibPhone;

namespace UnitTestPhone {

    public class MockOutput : IOutput {

        public string CapturedOutput { get; set; }

        public void Write(string text) {
            CapturedOutput = text;
        }

        public void WriteLine(string text) {
            CapturedOutput = text;
        }
        
    }

}
