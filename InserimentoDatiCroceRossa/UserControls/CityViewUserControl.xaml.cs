using InserimentoDatiCroceRossa.DbServiceObjects;
using InserimentoDatiCroceRossa.Objects;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace InserimentoDatiCroceRossa.UserControls
{
    /// <summary>
    /// Logica di interazione per CityViewUserControl.xaml
    /// </summary>
    public partial class CityViewUserControl : UserControl
    {
        ObservableCollection<CityEntity> cities = new ObservableCollection<CityEntity>();
        public CityViewUserControl()
        {
            InitializeComponent();
        }

        private void CityViewUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            CityService service = new CityService();
            cities = new ObservableCollection<CityEntity>(service.GetAllCities());
            this.lvCity.ItemsSource = cities;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.CityListTabItem.Visibility = Visibility.Collapsed;
            this.CloseButton.Visibility = this.cityDetailTabItem.Visibility = this.SaveButton.Visibility = Visibility.Visible;

            this.cityDetailTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            cityDetailUserControl.DataContext = new CityEntity();
        }

        private void ModifyUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.lvCity.SelectedItem;

            if (selectedItem != null)
            {
                this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.CityListTabItem.Visibility = Visibility.Collapsed;
                this.CloseButton.Visibility = this.cityDetailTabItem.Visibility = this.SaveButton.Visibility = Visibility.Visible;

                this.cityDetailTabItem.IsSelected = true;
                this.TabControl.UpdateLayout();

                cityDetailUserControl.DataContext = selectedItem as CityEntity;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            cityDetailUserControl.Save();
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.lvCity.SelectedItem;

            if (selectedItem != null)
            {
                CityEntity city = selectedItem as CityEntity;

                CityService service = new CityService();
                if (MessageBox.Show("Sei sicuro di voler eliminare \"" + city.CityName + " \" ?", "Elimina Città", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (service.Delete(city) == 0)
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
            this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.CityListTabItem.Visibility = Visibility.Visible;
            this.CloseButton.Visibility = this.SaveButton.Visibility = this.cityDetailTabItem.Visibility = Visibility.Collapsed;

            this.CityListTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            cityDetailUserControl.DataContext = new CityEntity();
            RefreshData();
        }
    }
}
