using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;//according to Microsoft had to add this bit to work with regular expressions


namespace PatientManagementSystemByDeirdreLouiseGinta
{
    public partial class FormPatientManagementSystem : Form
    {
        Regex validateStrings = new Regex("^[A-Za-z]+$"); //Add regular expressions for string input to stop program crashing
        Regex validateIntegers = new Regex("^[0-9]+$"); //Do same for integers. Have them at class level so can be used and modified in all methods
        public FormPatientManagementSystem()
        {
            InitializeComponent();
        }

        private void buttonAddPatient_Click(object sender, EventArgs e)
        {

          PatientList(); //Created seperate methods to break up the code and make it easier to read
          ClearTextBoxes();
        }

        public void PatientList()
        {
            
            if (validateStrings.IsMatch(textBoxFirstName.Text) && (validateStrings.IsMatch(textBoxSurname.Text) && (validateStrings.IsMatch(richTextBoxAddress.Text)) && (validateIntegers.IsMatch(textBoxPhone.Text)) && (validateIntegers.IsMatch(textBoxMRN.Text))))
            {//using regex class to check if fields match if they do proceed with code
                List<Patient> patient = new List<Patient>(); //save patient objects in a listbox
                patient.Add(new Patient(richTextBoxAddress.Text, int.Parse(textBoxMRN.Text), textBoxFirstName.Text, textBoxSurname.Text, int.Parse(textBoxPhone.Text)));
                //add patient information to the listbox from the fields provided in the form
                foreach (var p in patient)//use forloop to print subitems and display items neatly in listview
                {
                    ListViewItem pt = new ListViewItem(p.firstName);
                    pt.SubItems.Add(p.lastName);
                    pt.SubItems.Add(p.phone.ToString());
                    pt.SubItems.Add(p.patientAddress);
                    pt.SubItems.Add(p.patientMRN.ToString());
                    listViewPatientList.Items.Add(pt);

                    comboBoxSelectPatient.Items.Add(p.firstName); //add first name of patient to the combobox
                }

            }
            else
            {
                MessageBox.Show("Please enter all fields correctly to submit a patient!");
                //if the input does not match of that provided by regular expression display error message
            }
           

        }
        public void ClearTextBoxes()
        {
            textBoxFirstName.Clear();//just to make it neater doing the clears in seperate method
            textBoxSurname.Clear();
            textBoxPhone.Clear();
            richTextBoxAddress.Clear();
            textBoxMRN.Clear();
            textBoxRegNo.Clear();
            comboBoxClinicName.ResetText();
        }
        private void buttonAddConsultant_Click(object sender, EventArgs e)
        {
            List<Consultant> consultant = new List<Consultant>();//generally consultants are not diplayed in management systems
            consultant.Add(new Consultant(textBoxFirstName.Text, textBoxSurname.Text, int.Parse(textBoxPhone.Text), int.Parse(textBoxRegNo.Text)));
            //therefore consultant is straight added into consultant combobox
            //however it is important to mention that consultant can also become a patient therefore option to add consultant as patient was left available
            foreach (var c in consultant)
            {
                
                comboBoxSelectConsultant.Items.Add(c.firstName);
                //add consultants to combobox
            }
            ClearTextBoxes();//calling clear textboxes method to clear texboxes after each button click
        }

        private void FormPatientManagementSystem_Load(object sender, EventArgs e)
        {
            List<Clinic> clinicName = new List<Clinic>();//added new class clinic in hopes that in future can be developed further
            clinicName.Add(new Clinic("Monaghan"));//adding clinic names
            clinicName.Add(new Clinic("Cavan"));

            foreach (var clinic in clinicName)
            {
                comboBoxClinicName.Items.Add(clinic);//adding clinic names to clinic combobox
            }
        }

        private void comboBoxClinicName_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void buttonAssignPatientToConsultant_Click(object sender, EventArgs e)
        {
            var selectedPatient = this.comboBoxSelectPatient.GetItemText(this.comboBoxSelectPatient.SelectedItem);
            var selectedConsultant = this.comboBoxSelectConsultant.GetItemText(this.comboBoxSelectConsultant.SelectedItem);  
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem remove in listViewPatientList.SelectedItems)
            {
                remove.Remove();//providing user with the option to remove a patient from listview
            }
          
        }
    }
}
