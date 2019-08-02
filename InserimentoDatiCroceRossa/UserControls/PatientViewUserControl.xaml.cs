using InserimentoDatiCroceRossa.DbServiceObjects;
using InserimentoDatiCroceRossa.Objects;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace InserimentoDatiCroceRossa.UserControls
{
    /// <summary>
    /// Logica di interazione per PatientViewUserControl.xaml
    /// </summary>
    public partial class PatientViewUserControl : UserControl
    {
        ObservableCollection<PatientEntity> patients = new ObservableCollection<PatientEntity>();
        public PatientViewUserControl()
        {
            InitializeComponent();
        }

        private void PatientViewUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.RefreshData();
        }

        public void RefreshData()
        {
            PatientService service = new PatientService();
            patients = new ObservableCollection<PatientEntity>(service.GetAllPatients());
            this.lvPatient.ItemsSource = patients;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.PatientListTabItem.Visibility = Visibility.Collapsed;
            this.CloseButton.Visibility = this.patientDetailTabItem.Visibility = this.SaveButton.Visibility = Visibility.Visible;

            this.patientDetailTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            patientDetailUserControl.DataContext = new PatientEntity();
        }

        private void ModifyUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.lvPatient.SelectedItem;

            if (selectedItem != null)
            {
                this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.PatientListTabItem.Visibility = Visibility.Collapsed;
                this.CloseButton.Visibility = this.patientDetailTabItem.Visibility = this.SaveButton.Visibility = Visibility.Visible;

                this.patientDetailTabItem.IsSelected = true;
                this.TabControl.UpdateLayout();

                patientDetailUserControl.DataContext = selectedItem as PatientEntity;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            patientDetailUserControl.Save();
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.lvPatient.SelectedItem;

            if (selectedItem != null)
            {
                PatientEntity patient = selectedItem as PatientEntity;

                PatientService service = new PatientService();
                if (MessageBox.Show("Sei sicuro di voler eliminare \"" + patient.FiscalCode + " \" ?", "Elimina Paziente", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (service.Delete(patient) == 0)
                    {
                        MessageBox.Show("cancellato!");
                        this.RefreshData();
                    }
                    else
                        MessageBox.Show("NON cancellato!");
                }
                else
                    MessageBox.Show("NON cancellato!");
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.PatientListTabItem.Visibility = Visibility.Visible;
            this.CloseButton.Visibility = this.SaveButton.Visibility = this.patientDetailTabItem.Visibility = Visibility.Collapsed;

            this.PatientListTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            patientDetailUserControl.DataContext = new PatientEntity();
            RefreshData();
        }
    }
}
