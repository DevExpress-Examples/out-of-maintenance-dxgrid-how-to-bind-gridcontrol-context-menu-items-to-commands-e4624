using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridCommandToPopupMenuProject {
    public class Person {
        public Person(int i) {
            FirstName = string.Format("FirstName - {0}", i);
            LastName = string.Format("LastName - {0}", i);
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
