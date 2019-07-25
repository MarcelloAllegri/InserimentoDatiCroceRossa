using InserimentoDatiCroceRossa.DbServiceObjects;
using InserimentoDatiCroceRossa.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace InserimentoDatiCroceRossa.UserControls
{    
    public partial class AddressViewUserControl : UserControl
    {
        ObservableCollection<AddressEntity> addresses = new ObservableCollection<AddressEntity>();
        public AddressViewUserControl()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.AddressListTabItem.Visibility = Visibility.Collapsed;
            this.CloseButton.Visibility = this.addressDetailTabItem.Visibility = this.SaveButton.Visibility = Visibility.Visible;

            this.addressDetailTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            addressDetailUserControl.DataContext = new AddressEntity();
        }

        private void ModifyUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.lvAddreses.SelectedItem;

            if (selectedItem != null)
            {
                this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.AddressListTabItem.Visibility = Visibility.Collapsed;
                this.CloseButton.Visibility = this.addressDetailTabItem.Visibility = this.SaveButton.Visibility = Visibility.Visible;

                this.addressDetailTabItem.IsSelected = true;
                this.TabControl.UpdateLayout();

                addressDetailUserControl.DataContext = selectedItem as AddressEntity;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            addressDetailUserControl.Save();
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.lvAddreses.SelectedItem;

            if (selectedItem != null)
            {
                AddressEntity address = selectedItem as AddressEntity;

                AddressService service = new AddressService();
                if (MessageBox.Show("Sei sicuro di voler eliminare \"" + address.AddressName + " \" ?", "Elimina Indirizzo", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (service.Delete(address) == 0)
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
            this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.AddressListTabItem.Visibility = Visibility.Visible;
            this.CloseButton.Visibility = this.SaveButton.Visibility = this.addressDetailTabItem.Visibility = Visibility.Collapsed;

            this.AddressListTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            addressDetailUserControl.DataContext = new AddressEntity();
            RefreshData();
        }

        private void AddressViewUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            AddressService service = new AddressService();
            addresses = new ObservableCollection<AddressEntity>(service.GetAllAddresses());
            this.lvAddreses.ItemsSource = addresses;
        }
    }
}
