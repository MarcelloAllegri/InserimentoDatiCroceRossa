using InserimentoDatiCroceRossa.DbModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InserimentoDatiCroceRossa.Windows
{
    /// <summary>
    /// Logica di interazione per LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            bool check_credentials = checkUser();

            if (check_credentials)
            {
                DataViewWindow dataViewWindow = new DataViewWindow();
                dataViewWindow.Show();

                this.Close();
            }
            else MessageBox.Show("Invalid username or password!");
        }

        private bool checkUser()
        {
            bool retVal = true;

            using (var db = new CroceRossaEntities())
            {
                Usr usr = db.Usr.FirstOrDefault(x => x.UsrNam == UserTextBox.Text);
                if (usr == null) retVal = false;
                else
                {
                    if (usr.UsrPsw != PasswordBox.Password.ToString()) retVal = false;
                }
            }

            return retVal;
        }
    }
}
