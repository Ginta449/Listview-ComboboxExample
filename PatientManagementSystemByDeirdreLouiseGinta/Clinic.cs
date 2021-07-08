using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystemByDeirdreLouiseGinta
{
    class Clinic
    {
        public string clinicName { get; set; }

        public Clinic(string cname)
        {
            this.clinicName = cname;
        }

        public override string ToString()
        {
            return this.clinicName;
        }
    }

   

}
