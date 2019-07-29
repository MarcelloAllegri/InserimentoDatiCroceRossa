using InserimentoDatiCroceRossa.DbServiceObjects;
using InserimentoDatiCroceRossa.Objects;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace InserimentoDatiCroceRossa.UserControls
{
    /// <summary>
    /// Logica di interazione per LicencePlateViewUserControl.xaml
    /// </summary>
    public partial class LicencePlateViewUserControl : UserControl
    {
        ObservableCollection<LicencePlateEntity> licencePlates = new ObservableCollection<LicencePlateEntity>(); 
        public LicencePlateViewUserControl()
        {
            InitializeComponent();
        }

        private void LicencePlateViewUserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void RefreshData()
        {
            LicencePlateService service = new LicencePlateService();
            licencePlates = new ObservableCollection<LicencePlateEntity>(service.GetAllLicencePlates());
            this.lvLicencePlates.ItemsSource = licencePlates;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.LicencePlateListTabItem.Visibility = Visibility.Collapsed;
            this.CloseButton.Visibility = this.licencePlateDetailTabItem.Visibility = this.SaveButton.Visibility = Visibility.Visible;

            this.licencePlateDetailTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            licencePlateDetailUserControl.DataContext = new LicencePlateEntity();
        }

        private void ModifyUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.lvLicencePlates.SelectedItem;

            if (selectedItem != null)
            {
                this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.LicencePlateListTabItem.Visibility = Visibility.Collapsed;
                this.CloseButton.Visibility = this.licencePlateDetailTabItem.Visibility = this.SaveButton.Visibility = Visibility.Visible;

                this.licencePlateDetailTabItem.IsSelected = true;
                this.TabControl.UpdateLayout();

                licencePlateDetailUserControl.DataContext = selectedItem as LicencePlateEntity;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            licencePlateDetailUserControl.Save();
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.lvLicencePlates.SelectedItem;

            if (selectedItem != null)
            {
                LicencePlateEntity licencePlate = selectedItem as LicencePlateEntity;

                LicencePlateService service = new LicencePlateService();
                if (MessageBox.Show("Sei sicuro di voler eliminare \"" + licencePlate.Targa + " \" ?", "Elimina Targa", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (service.Delete(licencePlate) == 0)
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
            this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.LicencePlateListTabItem.Visibility = Visibility.Visible;
            this.CloseButton.Visibility = this.SaveButton.Visibility = this.licencePlateDetailTabItem.Visibility = Visibility.Collapsed;

            this.LicencePlateListTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            licencePlateDetailUserControl.DataContext = new LicencePlateEntity();
            RefreshData();
        }
    }
}
