using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystemByDeirdreLouiseGinta
{
    class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        public int phone { get; set; }

       
        public Person(string name, string surname, int phone)
        {
            this.firstName = name;
            this.lastName = surname;
            this.phone = phone;
            
        }

        public override string ToString()
        {
            return  this.firstName + " " + this.lastName + " " + this.phone;
        }
    }
}
