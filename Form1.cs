using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace PatientManagementSystemByDeirdreLouiseGinta
{
    public partial class FormPatientManagementSystem : Form
    {
        Regex validateStrings = new Regex("^[A-Za-z]+$"); 
        Regex validateIntegers = new Regex("^[0-9]+$"); 
        List<Consultant> consultant = new List<Consultant>();
        List<Patient> patient = new List<Patient>(); 
        List<Clinic> clinicName = new List<Clinic>();
        List<Person> person = new List<Person>();
        public FormPatientManagementSystem()
        {
            InitializeComponent();
        }

        private void buttonAddPatient_Click(object sender, EventArgs e)
        {

          PatientList(); 
          ClearTextBoxes();
        }

        public void PatientList()
        {
            
            if (validateStrings.IsMatch(textBoxFirstName.Text) && (validateStrings.IsMatch(textBoxSurname.Text) && (validateStrings.IsMatch(richTextBoxAddress.Text)) && (validateIntegers.IsMatch(textBoxPhone.Text)) && (validateIntegers.IsMatch(textBoxMRN.Text))))
            {
               
                patient.Add(new Patient(richTextBoxAddress.Text, int.Parse(textBoxMRN.Text), textBoxFirstName.Text, textBoxSurname.Text, int.Parse(textBoxPhone.Text)));
                

                foreach (var p in patient)
                {
                   
                    ListViewItem pt = new ListViewItem(p.firstName);
                    pt.SubItems.Add(p.lastName);
                    pt.SubItems.Add(p.phone.ToString());
                    pt.SubItems.Add(p.patientAddress);
                    pt.SubItems.Add(p.patientMRN.ToString());
                    listViewPatientList.Items.Add(pt);

                    comboBoxSelectPatient.Items.Add(p.firstName); 
                }

            }
            else
            {
                MessageBox.Show("Please enter all fields correctly to submit a patient!");
                
            }
           

        }
        public void ClearTextBoxes()
        {
            textBoxFirstName.Clear();
            textBoxSurname.Clear();
            textBoxPhone.Clear();
            richTextBoxAddress.Clear();
            textBoxMRN.Clear();
            textBoxRegNo.Clear();
            comboBoxClinicName.ResetText();
        }
        private void buttonAddConsultant_Click(object sender, EventArgs e)
        {
            
            consultant.Add(new Consultant(textBoxFirstName.Text, textBoxSurname.Text, int.Parse(textBoxPhone.Text), int.Parse(textBoxRegNo.Text)));
            
            foreach (var c in consultant)
            {
                
                comboBoxSelectConsultant.Items.Add(c.firstName);
                
            }
            ClearTextBoxes();
        }

        private void FormPatientManagementSystem_Load(object sender, EventArgs e)
        {
           
            clinicName.Add(new Clinic("Monaghan"));
            clinicName.Add(new Clinic("Cavan"));

            foreach (var clinic in clinicName)
            {
                comboBoxClinicName.Items.Add(clinic);
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
                remove.Remove();
            }
          
        }
    }
}
