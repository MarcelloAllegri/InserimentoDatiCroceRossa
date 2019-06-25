using InserimentoDatiCroceRossa.DbClasses;
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
    /// <summary>
    /// Logica di interazione per UserViewUserControl.xaml
    /// </summary>
    public partial class UserViewUserControl : UserControl
    {
        ObservableCollection<UserEntity> users = new ObservableCollection<UserEntity>();
        public void RefreshData()
        {
            UsersService service = new UsersService();
            users = new ObservableCollection<UserEntity>(service.GetAllUser());
            this.lvUsers.ItemsSource = users;

            if (GlobalInfo.IsUserAdmin && !this.UserGrid.Columns.Contains(VisualGrid.TryFindResource("PasswordColumn") as GridViewColumn))
            { 
                this.UserGrid.Columns.Add(VisualGrid.TryFindResource("PasswordColumn") as GridViewColumn);
                this.UserGrid.Columns.Move(2, 1);
                this.UpdateLayout();
            }
        }
        public UserViewUserControl()
        {
            InitializeComponent();
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.lvUsers.SelectedItem;

            if(selectedItem != null)
            {
                UserEntity user = selectedItem as UserEntity;
                if (user.AccountName.ToLower().Equals("admin"))
                    MessageBox.Show("Non si può eliminare l'utente amministratore principale!");
                else
                {
                    UsersService service = new UsersService();
                    if (MessageBox.Show("Sei sicuro di voler eliminare \"" + user.AccountName + " \" ?", "Elimina Utente", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        if (service.Delete(user) == 0)
                        {
                            MessageBox.Show("Utente cancellato!");
                            users.Remove(user);
                        }
                        else
                            MessageBox.Show("Utente NON cancellato!");
                    }
                    else
                        MessageBox.Show("Utente NON cancellato!");
                }
            }
        }

        private void ModifyUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.lvUsers.SelectedItem;

            if (selectedItem != null)
            {
                this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.ListTabItem.Visibility = Visibility.Collapsed;
                this.CloseButton.Visibility = this.userInfoTabItem.Visibility = this.SaveButton.Visibility = Visibility.Visible;

                this.userInfoTabItem.IsSelected = true;
                this.TabControl.UpdateLayout();

                userInfoUserControl.DataContext = selectedItem as UserEntity;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.ListTabItem.Visibility = Visibility.Visible;
            this.CloseButton.Visibility = this.SaveButton.Visibility = this.userInfoTabItem.Visibility = Visibility.Collapsed;
            
            this.ListTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            userInfoUserControl.DataContext = new UserEntity();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            userInfoUserControl.Save();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
