using InserimentoDatiCroceRossa.Objects;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace InserimentoDatiCroceRossa.Windows
{
    /// <summary>
    /// Logica di interazione per DataViewWindow.xaml
    /// </summary>
    public partial class DataViewWindow : Window
    {
        public DataViewWindow()
        {
            InitializeComponent();
        }

        private void UsersMenuItem_Click(object sender, RoutedEventArgs e)
        {
            disableAllUC();
            userViewUserControl.IsEnabled = true;
            userViewUserControl.Visibility = Visibility.Visible;
            this.UpdateLayout();
            userViewUserControl.RefreshData();
        }

        private void UserMenuItem_Click(object sender, RoutedEventArgs e)
        {
            disableAllUC();
            UserEntity user = new UserEntity();
            userUserControl.DataContext = user;
            userUserControl.IsEnabled = true;
            userUserControl.Visibility = Visibility.Visible;
            this.UpdateLayout();
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();            
        }

        private void disableAllUC()
        {
            this.userUserControl.Visibility = this.userViewUserControl.Visibility = Visibility.Collapsed;
        }
    }
}
