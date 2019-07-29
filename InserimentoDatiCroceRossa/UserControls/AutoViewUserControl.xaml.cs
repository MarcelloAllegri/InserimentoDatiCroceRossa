using InserimentoDatiCroceRossa.DbServiceObjects;
using InserimentoDatiCroceRossa.Objects;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace InserimentoDatiCroceRossa.UserControls
{
    /// <summary>
    /// Logica di interazione per AutoViewUserControl.xaml
    /// </summary>
    public partial class AutoViewUserControl : UserControl
    {
        ObservableCollection<AutoEntity> cars = new ObservableCollection<AutoEntity>();
        public AutoViewUserControl()
        {
            InitializeComponent();
        }

        private void AutoViewUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            AutoService service = new AutoService();
            cars = new ObservableCollection<AutoEntity>(service.GetAllCars());
            this.lvAuto.ItemsSource = cars;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.AutoListTabItem.Visibility = Visibility.Collapsed;
            this.CloseButton.Visibility = this.autoDetailTabItem.Visibility = this.SaveButton.Visibility = Visibility.Visible;

            this.autoDetailTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            autoDetailUserControl.DataContext = new AutoEntity();
        }

        private void ModifyUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.lvAuto.SelectedItem;

            if (selectedItem != null)
            {
                this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.AutoListTabItem.Visibility = Visibility.Collapsed;
                this.CloseButton.Visibility = this.autoDetailTabItem.Visibility = this.SaveButton.Visibility = Visibility.Visible;

                this.autoDetailTabItem.IsSelected = true;
                this.TabControl.UpdateLayout();

                autoDetailUserControl.DataContext = selectedItem as AutoEntity;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            autoDetailUserControl.Save();
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.lvAuto.SelectedItem;

            if (selectedItem != null)
            {
                AutoEntity car = selectedItem as AutoEntity;

                AutoService service = new AutoService();
                if (MessageBox.Show("Sei sicuro di voler eliminare \"" + car.CarName + " \" ?", "Elimina Auto", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (service.Delete(car) == 0)
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
            this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.AutoListTabItem.Visibility = Visibility.Visible;
            this.CloseButton.Visibility = this.SaveButton.Visibility = this.autoDetailTabItem.Visibility = Visibility.Collapsed;

            this.AutoListTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            autoDetailUserControl.DataContext = new AutoEntity();
            RefreshData();
        }
    }
}
