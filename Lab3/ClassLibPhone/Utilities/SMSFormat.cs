using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibPhone.Utilities {

    public class SMSFormat {

        public delegate string FormatDelegate(string text);

        public FormatDelegate Formatter { get; private set; } = s => s;
        
        public void ApplyFormat(int index) {
            switch (index) {
                case 0:
                Formatter = new FormatDelegate(s => s);
                break;
                case 1:
                Formatter = new FormatDelegate(s => $"[{DateTime.Now}] {s}");
                break;
                case 2:
                Formatter = new FormatDelegate(s => $"{s} [{DateTime.Now}]");
                break;
                case 3:
                Formatter = new FormatDelegate(s => $"-={s}=-");
                break;
                case 4:
                Formatter = new FormatDelegate(s => s.ToLower());
                break;
                case 5:
                Formatter = new FormatDelegate(s => s.ToUpper());
                break;
                default:
                Formatter = new FormatDelegate(s => s);
                break;
            }
        }
        
    }

}
