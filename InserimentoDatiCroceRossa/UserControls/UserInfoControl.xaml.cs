using InserimentoDatiCroceRossa.DbClasses;
using InserimentoDatiCroceRossa.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logica di interazione per UserUserControl.xaml
    /// </summary>
    public partial class UserInfoControl : UserControl, INotifyPropertyChanged
    {        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        
        private List<char> m_UserTypeList;

        public List<char> UserTypeList
        {
            get { return m_UserTypeList; }
            set { m_UserTypeList = value; OnPropertyChanged(nameof(UserTypeList)); }
        }


        public UserInfoControl()
        {
            InitializeComponent();
        }

        public void Save()
        {
            if(CheckData())
            {
                UsersService userService = new UsersService();
                if ((this.DataContext as UserEntity).Id == -1)
                {
                    if (userService.Add(this.DataContext as UserEntity) == 0)
                    {
                        MessageBox.Show("Utente Salvato!");
                        this.DataContext = new UserEntity();
                    }
                    else
                        MessageBox.Show("Errore durante il salvataggio!");
                }
                else
                {
                    if (userService.Update(this.DataContext as UserEntity) == 0)
                        MessageBox.Show("Utente Salvato!");
                    else MessageBox.Show("Errore durante il salvataggio!");                    
                }
                
            }            
        }

        private bool CheckData()
        {
            if (string.IsNullOrEmpty((this.DataContext as UserEntity).AccountName))
            {
                MessageBox.Show("Nome account vuoto!");
                return false;
            }
            else
            {
                if((this.DataContext as UserEntity).AccountName.Length>20)
                {
                    MessageBox.Show("Il nome utente non può essere lungo più di 20 caratteri");
                    return false;
                }
            }

            if(string.IsNullOrEmpty((this.DataContext as UserEntity).Password))
            {
                MessageBox.Show("Inserisci una password!");
                return false;
            }
            
            if(string.IsNullOrEmpty((this.DataContext as UserEntity).UserType.ToString()))
            {
                MessageBox.Show("Scegli un tipo di utente!");
                return false;
            }

            return true;
        }

        private void UserTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            char selectedValue = (char)((sender as ComboBox).SelectedValue);
            if (!string.IsNullOrEmpty(selectedValue.ToString()))            
                (this.DataContext as UserEntity).UserType = selectedValue;
            else
                (this.DataContext as UserEntity).UserType = '\0';
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = (sender as PasswordBox);
            string password = passwordBox.Password;

            (this.DataContext as UserEntity).Password = password;
        }

        

        private void UserUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.UserTypeList = new List<char>() { '\0', 'A', 'D', 'V' };            
        }

        private void ShowPasswordCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.PasswordTextBlock.Visibility = Visibility.Visible;            
            this.UpdateLayout();
        }

        private void ShowPasswordCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.PasswordTextBlock.Visibility = Visibility.Collapsed;
            this.UpdateLayout();
        }

        private void UserUserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.UserTypeList = new List<char>() { '\0', 'A', 'D', 'V' };

            this.passwordBox.Password = (this.DataContext as UserEntity).Password;
            this.UserTypeComboBox.SelectedItem = (this.DataContext as UserEntity).UserType;
        }
    }    
}
