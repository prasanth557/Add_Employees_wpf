using PatientList.Commands;
using PatientList.Models;
using PatientList.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PatientList.ViewModel
{
    public class PatientListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Patient> patients;
        public ObservableCollection<Patient> Patients
        {
            get { return patients; }
            set
            {
                patients = value;
                RaisePropertyChanged("Patients");
            }
        }


        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public PatientListViewModel()
        {
            Patients = new ObservableCollection<Patient>();
            AddCommand = new RelayCommand(AddPatient);
            EditCommand = new RelayCommand(EditPatient, CanEditPatient);
            DeleteCommand = new RelayCommand(DeletePatient, CanDeletePatient);
        }

        private bool CanEditPatient(object patient)
        {
            // Add your logic here to determine if a patient can be edited
            if (patient is Patient existingPatient)
            {
                var dialog = new PatientDialog();
                dialog.LastNameTextBox.Text = existingPatient.LastName;
                dialog.FirstNameTextBox.Text = existingPatient.FirstName;
                dialog.ResidenceTextBox.Text = existingPatient.Residence;

            if (dialog.ShowDialog() == true)
            {
                    existingPatient.LastName = dialog.LastName;
                    existingPatient.FirstName = dialog.FirstName;
                    existingPatient.Residence = dialog.Residence;
                }
            }
            return true; // For example, allow editing all patients
        }

        private bool CanDeletePatient(object patient)
        {
            // Add your logic here to determine if a patient can be deleted
            return true; // For example, allow deleting all patients
        }

        // Implement the AddPatient, EditPatient, and DeletePatient methods.

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        private void AddPatient(object parameter)
        {
            var dialog = new PatientDialog();

            if (dialog.ShowDialog() == true)
            {
                var patient = new Patient
                {
                    LastName = dialog.LastName,
                    FirstName = dialog.FirstName,
                    Residence = dialog.Residence
                };
                Patients.Add(patient);
            }
        }

        private void EditPatient(object parameter)
        {
            // Add your logic here to determine if a patient can be edited
            if (parameter is Patient existingPatient)
            {
                var dialog = new PatientDialog();
                dialog.LastNameTextBox.Text = existingPatient.LastName;
                dialog.FirstNameTextBox.Text = existingPatient.FirstName;
                dialog.ResidenceTextBox.Text = existingPatient.Residence;

                if (dialog.ShowDialog() == true)
                {
                    existingPatient.LastName = dialog.LastName;
                    existingPatient.FirstName = dialog.FirstName;
                    existingPatient.Residence = dialog.Residence;
                }
            }
        }

        private void DeletePatient(object parameter)
        {
            if (parameter is Patient existingPatient)
            {
                Patients.Remove(existingPatient);
            }
        }

    }
}

