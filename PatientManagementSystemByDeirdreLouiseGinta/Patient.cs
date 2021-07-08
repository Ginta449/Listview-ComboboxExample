using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystemByDeirdreLouiseGinta
{
    class Patient:Person
    {
        public string patientAddress { get; set; }
        public int patientMRN { get; set; }

        public Patient(string address, int mrn, string name, string surname, int phone) : base(name, surname, phone)
        {
            this.patientAddress = address;
            this.patientMRN = mrn;
        }

        public override string ToString()
        {
            return base.firstName + " " + base.lastName + " " + base.phone + " " + this.patientAddress + " " + this.patientMRN;
        }
    }
}
