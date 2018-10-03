using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibPhone.Call_Utilities {

    public class Contact {

        public string Name { get; set; }

        public List<string> PhonesList { get; set; } = new List<string>();
        
        public override bool Equals(object obj) {
            var item = obj as Contact;
            return item != null && Name.Equals(item.Name);
        }

        protected bool Equals(Contact other) {
            return string.Equals(Name, other.Name) && Equals(PhonesList, other.PhonesList);
        }

        public override int GetHashCode() {
            unchecked {
                return ((Name?.GetHashCode() ?? 0)*397) ^ (PhonesList?.GetHashCode() ?? 0);
            }
        }

    }

}
