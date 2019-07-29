using InserimentoDatiCroceRossa.DbServiceObjects;
using InserimentoDatiCroceRossa.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace InserimentoDatiCroceRossa.UserControls
{
    /// <summary>
    /// Logica di interazione per AuthorityDetailUserControl.xaml
    /// </summary>
    public partial class AuthorityDetailUserControl : UserControl
    {
        public AuthorityDetailUserControl()
        {
            InitializeComponent();
        }

        private bool CheckDoppione()
        {
            string authorityName = (this.DataContext as AuthorityEntity).AuthorityName.ToLower();


            AuthorityService service = new AuthorityService();
            List<AuthorityEntity> entities = service.GetAllAuthorities();

            if (entities.Any(x => x.AuthorityName.ToLower().Equals(authorityName)))
                return true;

            return false;
        }

        private bool CheckData()
        {
            if (string.IsNullOrEmpty((this.DataContext as AuthorityEntity).AuthorityName))
            {
                MessageBox.Show("nome vuoto!");
                return false;
            }

            return true;
        }

        public void Save()
        {
            if (CheckData())
            {
                AuthorityService service = new AuthorityService();
                if ((this.DataContext as AuthorityEntity).Id == -1 && !CheckDoppione())
                {
                    if (service.Add(this.DataContext as AuthorityEntity) == 0)
                    {
                        MessageBox.Show("Salvato!");
                        this.DataContext = new AuthorityEntity();
                    }
                    else
                        MessageBox.Show("Errore durante il salvataggio!");
                }
                else
                {
                    if (service.Update(this.DataContext as AuthorityEntity) == 0)
                        MessageBox.Show("Salvato!");
                    else MessageBox.Show("Errore durante il salvataggio!");
                }

            }
        }
    }
}
