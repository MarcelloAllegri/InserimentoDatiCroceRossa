using InserimentoDatiCroceRossa.DbClasses;
using InserimentoDatiCroceRossa.DbModel;
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
            Style = (Style)FindResource(typeof(Window));
            InitializeComponent();
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            string error = checkDbConnection();
            if (string.IsNullOrEmpty(error))
            {
                bool check_credentials = checkUser();

                if (check_credentials)
                {
                    DataViewWindow dataViewWindow = new DataViewWindow();
                    dataViewWindow.Show();

                    this.Close();
                }
                else MessageBox.Show("Username o password non corretti!");
            }
            else MessageBox.Show(error);
        }

        private bool checkUser()
        {
            bool retVal = true;

            using (var db = new CroceRossaEntities())
            {
                Usr usr = db.Usr.FirstOrDefault(x => x.UsrNam.Equals(UserTextBox.Text.ToString()));
                if (usr == null) retVal = false;
                else
                {
                    if (KriptoEntity.DecryptString(usr.UsrPsw) != PasswordBox.Password.ToString()) retVal = false;
                    else GlobalInfo.LoggedUser = usr.toUserEntity();
                }
            }

            return retVal;
        }

        private string checkDbConnection()
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    db.Database.Connection.Open();                    
                }
            }
            catch (Exception e)
            {

                return e.Message;
            }

            return "";
        }
    }
}
