using InserimentoDatiCroceRossa.Objects;
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

namespace InserimentoDatiCroceRossa.Windows
{
    /// <summary>
    /// Logica di interazione per DataViewWindow.xaml
    /// </summary>
    public partial class DataViewWindow : Window
    {
        public DataViewWindow()
        {
            InitializeComponent();
        }

        private void UsersMenuItem_Click(object sender, RoutedEventArgs e)
        {
            disableAllUC();
            userViewUserControl.IsEnabled = true;
            userViewUserControl.Visibility = Visibility.Visible;
            this.UpdateLayout();
            userViewUserControl.RefreshData();
        }        

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();            
        }

        private void disableAllUC()
        {
            this.userViewUserControl.Visibility = Visibility.Collapsed;
            this.volunteerViewUserControl.Visibility = Visibility.Collapsed;
            this.addressViewUserControl.Visibility = Visibility.Collapsed;
            this.authorityViewUserControl.Visibility = Visibility.Collapsed;
            this.autoViewUserControl.Visibility = Visibility.Collapsed;
            this.licencePlateViewUserControl.Visibility = Visibility.Collapsed;
            this.carLicPlateAssociationsViewUserControl.Visibility = Visibility.Collapsed;
            this.cityViewUserControl.Visibility = Visibility.Collapsed;
            this.pathologyViewUserControl.Visibility = Visibility.Collapsed;
            this.patientViewUserControl.Visibility = Visibility.Collapsed;
        }

        private void VolunteersMenuItem_Click(object sender, RoutedEventArgs e)
        {
            disableAllUC();
            this.volunteerViewUserControl.IsEnabled = true;
            volunteerViewUserControl.Visibility = Visibility.Visible;
            this.UpdateLayout();
            volunteerViewUserControl.RefreshData();
        }

        private void AddressMenuItem_Click(object sender, RoutedEventArgs e)
        {
            disableAllUC();
            this.addressViewUserControl.IsEnabled = true;
            addressViewUserControl.Visibility = Visibility.Visible;
            this.UpdateLayout();
            addressViewUserControl.RefreshData();
        }

        private void AuthoritiesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            disableAllUC();
            this.authorityViewUserControl.IsEnabled = true;
            authorityViewUserControl.Visibility = Visibility.Visible;
            this.UpdateLayout();
            authorityViewUserControl.RefreshData();
        }

        private void CarMenuItem_Click(object sender, RoutedEventArgs e)
        {
            disableAllUC();
            this.autoViewUserControl.IsEnabled = true;
            autoViewUserControl.Visibility = Visibility.Visible;
            this.UpdateLayout();
            autoViewUserControl.RefreshData();
        }

        private void LicencePlatesMenuItem_Click(object sender, RoutedEventArgs e)
        {            
            disableAllUC();
            this.licencePlateViewUserControl.IsEnabled = true;
            licencePlateViewUserControl.Visibility = Visibility.Visible;
            this.UpdateLayout();
            licencePlateViewUserControl.RefreshData();
        }

        private void AssociationTabItem_Click(object sender, RoutedEventArgs e)
        {            
            disableAllUC();
            this.carLicPlateAssociationsViewUserControl.IsEnabled = true;
            carLicPlateAssociationsViewUserControl.Visibility = Visibility.Visible;
            this.UpdateLayout();
            carLicPlateAssociationsViewUserControl.RefreshData();
        }

        private void CityMenuItem_Click(object sender, RoutedEventArgs e)
        {
            disableAllUC();
            this.cityViewUserControl.IsEnabled = true;
            cityViewUserControl.Visibility = Visibility.Visible;
            this.UpdateLayout();
            cityViewUserControl.RefreshData();
        }

        private void PathologyMenuItem_Click(object sender, RoutedEventArgs e)
        {
            disableAllUC();
            this.pathologyViewUserControl.IsEnabled = true;
            pathologyViewUserControl.Visibility = Visibility.Visible;
            this.UpdateLayout();
            pathologyViewUserControl.RefreshData();
        }

        private void PatientMenuItem_Click(object sender, RoutedEventArgs e)
        {
            disableAllUC();
            this.patientViewUserControl.IsEnabled = true;
            patientViewUserControl.Visibility = Visibility.Visible;
            this.UpdateLayout();
            patientViewUserControl.RefreshData();
        }
    }
}
