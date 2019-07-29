using InserimentoDatiCroceRossa.DbServiceObjects;
using InserimentoDatiCroceRossa.Objects;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace InserimentoDatiCroceRossa.UserControls
{
    /// <summary>
    /// Logica di interazione per AuthorityViewUserControl.xaml
    /// </summary>
    public partial class AuthorityViewUserControl : UserControl
    {
        ObservableCollection<AuthorityEntity> entities = new ObservableCollection<AuthorityEntity>();
        public AuthorityViewUserControl()
        {
            InitializeComponent();
        }

        private void AuthorityViewUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }
        public void RefreshData()
        {
            AuthorityService service = new AuthorityService();
            entities = new ObservableCollection<AuthorityEntity>(service.GetAllAuthorities());
            this.lvAuthorities.ItemsSource = entities;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.AuthorityListTabItem.Visibility = Visibility.Collapsed;
            this.CloseButton.Visibility = this.authorityDetailTabItem.Visibility = this.SaveButton.Visibility = Visibility.Visible;

            this.authorityDetailTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            authorityDetailUserControl.DataContext = new AuthorityEntity();
        }

        private void ModifyUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.lvAuthorities.SelectedItem;

            if (selectedItem != null)
            {
                this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.AuthorityListTabItem.Visibility = Visibility.Collapsed;
                this.CloseButton.Visibility = this.authorityDetailTabItem.Visibility = this.SaveButton.Visibility = Visibility.Visible;

                this.authorityDetailTabItem.IsSelected = true;
                this.TabControl.UpdateLayout();

                authorityDetailUserControl.DataContext = selectedItem as AuthorityEntity;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            authorityDetailUserControl.Save();
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.lvAuthorities.SelectedItem;

            if (selectedItem != null)
            {
                AuthorityEntity ent = selectedItem as AuthorityEntity;

                AuthorityService service = new AuthorityService();
                if (MessageBox.Show("Sei sicuro di voler eliminare \"" + ent.AuthorityName + " \" ?", "Elimina Ente", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (service.Delete(ent) == 0)
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
            this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.AuthorityListTabItem.Visibility = Visibility.Visible;
            this.CloseButton.Visibility = this.SaveButton.Visibility = this.authorityDetailTabItem.Visibility = Visibility.Collapsed;

            this.AuthorityListTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            authorityDetailUserControl.DataContext = new AuthorityEntity();
            RefreshData();
        }
    }
}
