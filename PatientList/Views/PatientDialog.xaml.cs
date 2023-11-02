using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PatientList.Views
{
    /// <summary>
    /// Interaction logic for PatientDialog.xaml
    /// </summary>
    public partial class PatientDialog : Window
    {
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string Residence
        {
            get; private set;
        }
        public PatientDialog()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            LastName = LastNameTextBox.Text;
            FirstName = FirstNameTextBox.Text;
            Residence = ResidenceTextBox.Text;
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
    
}
