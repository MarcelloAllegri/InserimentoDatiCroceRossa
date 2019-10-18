using System;
using System.Collections.Generic;
using InserimentoDatiCroceRossa.DbServiceObjects;
using InserimentoDatiCroceRossa.Objects;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace InserimentoDatiCroceRossa.UserControls
{
    /// <summary>
    /// Logica di interazione per DataCollectionViewUserControl.xaml
    /// </summary>
    public partial class DataCollectionViewUserControl : UserControl
    {
        ObservableCollection<DataCollectionViewEntity> dataCollectionList = new ObservableCollection<DataCollectionViewEntity>();
        public DataCollectionViewUserControl()
        {
            InitializeComponent();
        }        

        private void DataCollectionViewUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.RefreshData();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvDataCollection.ItemsSource);
            view.Filter = Filter();
        }

        private Predicate<object> Filter()
        {
            if (string.IsNullOrEmpty(FilterTextBox.Text))
                return null;
            else
                return new Predicate<object>(o =>  ((DataCollectionViewEntity)o).AddressValue.ToLower().Contains(FilterTextBox.Text.ToLower())
                || ((DataCollectionViewEntity)o).AutoAndLicPlate.ToLower().Contains(FilterTextBox.Text.ToLower())
                || ((DataCollectionViewEntity)o).DriverName.ToLower().Contains(FilterTextBox.Text.ToLower())
                || ((DataCollectionViewEntity)o).EntityName.ToLower().Contains(FilterTextBox.Text.ToLower())
                || ((DataCollectionViewEntity)o).PlaceValue.ToLower().Contains(FilterTextBox.Text.ToLower())
                || ((DataCollectionViewEntity)o).PatientFCdAndFullName.ToLower().Contains(FilterTextBox.Text.ToLower())
                || ((DataCollectionViewEntity)o).Rescuer1Name.ToLower().Contains(FilterTextBox.Text.ToLower())
                || ((DataCollectionViewEntity)o).Rescuer2Name.ToLower().Contains(FilterTextBox.Text.ToLower())
                || ((DataCollectionViewEntity)o).ServiceTypeToString.ToLower().Contains(FilterTextBox.Text.ToLower())); 
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.DataCollectionListTabItem.Visibility = Visibility.Collapsed;
            this.CloseButton.Visibility = this.dataCollectionDetailTabItem.Visibility = this.SaveButton.Visibility = Visibility.Visible;
            FilterTextBox.IsEnabled = false;

            this.dataCollectionDetailTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            dataCollectionDetailUserControl.DataContext = new DataCollectionViewEntity();
            dataCollectionDetailUserControl.RefreshBackgroundData();
            dataCollectionDetailUserControl.SelectedPatientTextBox.Text = string.Empty;
        }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.lvDataCollection.SelectedItem;

            if (selectedItem != null)
            {
                this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.DataCollectionListTabItem.Visibility = Visibility.Collapsed;
                this.CloseButton.Visibility = this.dataCollectionDetailTabItem.Visibility = this.SaveButton.Visibility = Visibility.Visible;
                FilterTextBox.IsEnabled = false;

                this.dataCollectionDetailTabItem.IsSelected = true;
                this.TabControl.UpdateLayout();

                dataCollectionDetailUserControl.RefreshBackgroundData();
                dataCollectionDetailUserControl.DataContext = selectedItem as DataCollectionViewEntity;
                dataCollectionDetailUserControl.SelectedPatientTextBox.Text = (dataCollectionDetailUserControl.DataContext as DataCollectionViewEntity).PatientFCdAndFullName;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            dataCollectionDetailUserControl.Save();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.lvDataCollection.SelectedItem;

            if (selectedItem != null)
            {
                DataCollectionEntity item = selectedItem as DataCollectionEntity;

                DataCollectionService service = new DataCollectionService();
                if (MessageBox.Show("Sei sicuro di voler eliminare l'elemento selezionato?", "Elimina riga", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (service.Delete(item) == 0)
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
            this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.DataCollectionListTabItem.Visibility = Visibility.Visible;
            this.CloseButton.Visibility = this.SaveButton.Visibility = this.dataCollectionDetailTabItem.Visibility = Visibility.Collapsed;
            FilterTextBox.IsEnabled = true;

            this.DataCollectionListTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            dataCollectionDetailUserControl.DataContext = new DataCollectionViewEntity();
            RefreshData();
        }

        public void RefreshData()
        {
            using (new WaitCursor())
            {
                this.dataCollectionList = new ObservableCollection<DataCollectionViewEntity>();
                new DataCollectionService().GetAllData().ForEach(item => { this.dataCollectionList.Add(item); });
                this.lvDataCollection.ItemsSource = null;
                this.lvDataCollection.ItemsSource = dataCollectionList;
            }
            
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvDataCollection.ItemsSource).Refresh();
        }
    }
}
