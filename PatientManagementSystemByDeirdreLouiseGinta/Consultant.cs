using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystemByDeirdreLouiseGinta
{
    class Consultant:Person
    {
       
        public int regNo { get; set; }

        public Consultant(string name, string surname, int phone, int reg) : base(name, surname, phone)
        {
            this.regNo = reg;
        }

        public override string ToString()
        {
            return base.firstName + " " + base.lastName + " " + base.phone + " " + this.regNo;
        }
    }
}
