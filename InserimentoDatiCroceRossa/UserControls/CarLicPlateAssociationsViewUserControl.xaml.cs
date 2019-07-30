using InserimentoDatiCroceRossa.DbServiceObjects;
using InserimentoDatiCroceRossa.Objects;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace InserimentoDatiCroceRossa.UserControls
{
    /// <summary>
    /// Logica di interazione per CarLicPlateAssociationsViewUserControl.xaml
    /// </summary>
    public partial class CarLicPlateAssociationsViewUserControl : UserControl
    {
        ObservableCollection<CarLicencePlateAssociationEntity> associations = new ObservableCollection<CarLicencePlateAssociationEntity>();
        public CarLicPlateAssociationsViewUserControl()
        {
            InitializeComponent();
        }

        private void CarLicPlateAssociationsViewUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            associations = new ObservableCollection<CarLicencePlateAssociationEntity>(new CarLicPlateAssociationService().GetAllAssociation());
            this.lvAssociations.ItemsSource = associations;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.AssociationListTabItem.Visibility = Visibility.Collapsed;
            this.CloseButton.Visibility = this.associationDetailTabItem.Visibility = this.SaveButton.Visibility = Visibility.Visible;

            this.associationDetailTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            carLicPlateAssociationDetailUserControl.DataContext = new CarLicencePlateAssociationEntity();
            carLicPlateAssociationDetailUserControl.populateLists();
        }

        private void ModifyUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.lvAssociations.SelectedItem;

            if (selectedItem != null)
            {
                this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.AssociationListTabItem.Visibility = Visibility.Collapsed;
                this.CloseButton.Visibility = this.associationDetailTabItem.Visibility = this.SaveButton.Visibility = Visibility.Visible;

                this.associationDetailTabItem.IsSelected = true;
                this.TabControl.UpdateLayout();

                carLicPlateAssociationDetailUserControl.DataContext = selectedItem as CarLicencePlateAssociationEntity;
                carLicPlateAssociationDetailUserControl.populateLists();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            carLicPlateAssociationDetailUserControl.Save();
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.lvAssociations.SelectedItem;

            if (selectedItem != null)
            {
                CarLicencePlateAssociationEntity association = selectedItem as CarLicencePlateAssociationEntity;

                CarLicPlateAssociationService service = new CarLicPlateAssociationService();
                if (MessageBox.Show("Sei sicuro di voler eliminare \"" + association.CarName + " " + association.LicencePlate + " \" ?", "Elimina Associazione", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (service.Delete(association) == 0)
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
            this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.AssociationListTabItem.Visibility = Visibility.Visible;
            this.CloseButton.Visibility = this.SaveButton.Visibility = this.associationDetailTabItem.Visibility = Visibility.Collapsed;

            this.AssociationListTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            carLicPlateAssociationDetailUserControl.DataContext = new CarLicPlateAssociationService();
            RefreshData();
        }
    }
}
