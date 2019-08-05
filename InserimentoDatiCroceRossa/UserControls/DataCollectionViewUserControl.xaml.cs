using System;
using System.Collections.Generic;
using InserimentoDatiCroceRossa.DbServiceObjects;
using InserimentoDatiCroceRossa.Objects;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

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
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.DataCollectionListTabItem.Visibility = Visibility.Collapsed;
            this.CloseButton.Visibility = this.dataCollectionDetailTabItem.Visibility = this.SaveButton.Visibility = Visibility.Visible;

            this.dataCollectionDetailTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            dataCollectionDetailUserControl.DataContext = new DataCollectionEntity();
        }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.lvDataCollection.SelectedItem;

            if (selectedItem != null)
            {
                this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.DataCollectionListTabItem.Visibility = Visibility.Collapsed;
                this.CloseButton.Visibility = this.dataCollectionDetailTabItem.Visibility = this.SaveButton.Visibility = Visibility.Visible;

                this.dataCollectionDetailTabItem.IsSelected = true;
                this.TabControl.UpdateLayout();

                dataCollectionDetailUserControl.DataContext = selectedItem as DataCollectionEntity;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //dataCollectionDetailUserControl.Save();
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

            this.DataCollectionListTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            dataCollectionDetailUserControl.DataContext = new DataCollectionEntity();
            RefreshData();
        }

        public void RefreshData()
        {
            using (new WaitCursor())
            {
                this.dataCollectionList = new ObservableCollection<DataCollectionViewEntity>();
                new DataCollectionService().GetAllData().ForEach(item => { this.dataCollectionList.Add((DataCollectionViewEntity)item); });
                this.lvDataCollection.ItemsSource = null;
                this.lvDataCollection.ItemsSource = dataCollectionList;
            }
            
        }        
    }
}
