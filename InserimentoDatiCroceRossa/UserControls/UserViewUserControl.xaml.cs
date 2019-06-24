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

            if (GlobalInfo.IsUserAdmin && !this.UserGrid.Columns.Contains(Grid.TryFindResource("PasswordColumn") as GridViewColumn))
            { 
                this.UserGrid.Columns.Add(Grid.TryFindResource("PasswordColumn") as GridViewColumn);
                this.UserGrid.Columns.Move(2, 1);
                this.UpdateLayout();
            }
        }
        public UserViewUserControl()
        {
            InitializeComponent();
        }
    }
}
