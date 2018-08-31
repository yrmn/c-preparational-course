using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhones {

    class Program {

        static void Main(string[] args) {
            MobilePhone phone;
            phone = new SimCorpMobile();
            Console.WriteLine(phone.GetDescription());
            Console.ReadLine();
        }

    }
    
}
