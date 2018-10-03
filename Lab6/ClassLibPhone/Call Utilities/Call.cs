using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibPhone.Call_Utilities {

    public class Call : IComparable<Call> {

        public Contact Contact { get; set; }
        public CallDirection Direction { get; set; }
        public DateTime CallTime { get; set; }
        
        public List<Call> AssociatedCalls { get; set; } = new List<Call>();
        
        public int CompareTo(Call that) {
            if (CallTime > that.CallTime)
                return -1;
            return CallTime == that.CallTime ? 0 : 1;
        }
        
        public override bool Equals(object obj) {
            var item = obj as Call;
            return item != null && Contact.Equals(item.Contact) && Direction.Equals(item.Direction);
        }

        protected bool Equals(Call other) {
            return Equals(Contact, other.Contact) && Direction == other.Direction;
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = Contact?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (int) Direction;
                hashCode = (hashCode*397) ^ CallTime.GetHashCode();
                return hashCode;
            }
        }
        
        public enum CallDirection {
            Incoming,
            Outgoing
        }

    }

}
