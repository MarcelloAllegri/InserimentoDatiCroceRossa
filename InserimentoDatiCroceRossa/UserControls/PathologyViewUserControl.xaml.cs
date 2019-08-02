using InserimentoDatiCroceRossa.DbServiceObjects;
using InserimentoDatiCroceRossa.Objects;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace InserimentoDatiCroceRossa.UserControls
{
    /// <summary>
    /// Logica di interazione per PathologyViewUserControl.xaml
    /// </summary>
    public partial class PathologyViewUserControl : UserControl
    {
        ObservableCollection<PathologyEntity> pathologies = new ObservableCollection<PathologyEntity>();
        public PathologyViewUserControl()
        {
            InitializeComponent();
        }

        private void PathologyViewUserControl_Loaded(object sender, RoutedEventArgs e)
        {       
            RefreshData();
        }

        public void RefreshData()
        {
            PathologyService service = new PathologyService();
            pathologies = new ObservableCollection<PathologyEntity>(service.GetAllPathologies());
            this.lvPathology.ItemsSource = pathologies;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.PathologyListTabItem.Visibility = Visibility.Collapsed;
            this.CloseButton.Visibility = this.pathologyDetailTabItem.Visibility = this.SaveButton.Visibility = Visibility.Visible;

            this.pathologyDetailTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            pathologyDetailUserControl.DataContext = new PathologyEntity();
        }

        private void ModifyUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.lvPathology.SelectedItem;

            if (selectedItem != null)
            {
                this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.PathologyListTabItem.Visibility = Visibility.Collapsed;
                this.CloseButton.Visibility = this.pathologyDetailTabItem.Visibility = this.SaveButton.Visibility = Visibility.Visible;

                this.pathologyDetailTabItem.IsSelected = true;
                this.TabControl.UpdateLayout();

                pathologyDetailUserControl.DataContext = selectedItem as PathologyEntity;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            pathologyDetailUserControl.Save();
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.lvPathology.SelectedItem;

            if (selectedItem != null)
            {
                PathologyEntity pathology = selectedItem as PathologyEntity;

                PathologyService service = new PathologyService();
                if (MessageBox.Show("Sei sicuro di voler eliminare \"" + pathology.PathologyName + " \" ?", "Elimina patologia", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (service.Delete(pathology) == 0)
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
            this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.PathologyListTabItem.Visibility = Visibility.Visible;
            this.CloseButton.Visibility = this.SaveButton.Visibility = this.pathologyDetailTabItem.Visibility = Visibility.Collapsed;

            this.PathologyListTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            pathologyDetailUserControl.DataContext = new PathologyEntity();
            RefreshData();
        }
    }
}
