using PatientList.Models;
using PatientList.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PatientList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            // Create an instance of the ViewModel
            var viewModel = new PatientListViewModel();

            // Set the ViewModel as the DataContext of the MainWindow
            DataContext = viewModel;
        }
        private void OnRightClickEdit(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                var textBlock = (TextBlock)sender;
                var patient = (Patient)textBlock.Tag;

                if (DataContext is PatientListViewModel viewModel)
                {
                    viewModel.EditCommand.Execute(patient);
                }
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var rowItem = (sender as Button).DataContext as Patient;
            if (DataContext is PatientListViewModel viewModel)
            {
                viewModel.DeleteCommand.Execute(rowItem);
            }
        }

        
    }
}
