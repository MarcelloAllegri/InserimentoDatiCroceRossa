using InserimentoDatiCroceRossa.DbServiceObjects;
using InserimentoDatiCroceRossa.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace InserimentoDatiCroceRossa.UserControls
{
    /// <summary>
    /// Logica di interazione per LicencePlatesDetailUserControl.xaml
    /// </summary>
    public partial class LicencePlatesDetailUserControl : UserControl
    {
        public LicencePlatesDetailUserControl()
        {
            InitializeComponent();
        }

        private bool CheckDoppione()
        {
            string licencePlate = (this.DataContext as LicencePlateEntity).Targa.ToLower();


            LicencePlateService service = new LicencePlateService();
            List<LicencePlateEntity> targhe = service.GetAllLicencePlates();

            if (targhe.Any(x => x.Targa.ToLower().Equals(licencePlate)))
                return true;

            return false;
        }

        private bool CheckData()
        {
            if (string.IsNullOrEmpty((this.DataContext as LicencePlateEntity).Targa))
            {
                MessageBox.Show("targa vuota!");
                return false;
            }

            return true;
        }

        public void Save()
        {
            if (CheckData())
            {
                LicencePlateService service = new LicencePlateService();
                if ((this.DataContext as LicencePlateEntity).Id == -1 && !CheckDoppione())
                {
                    if (service.Add(this.DataContext as LicencePlateEntity) == 0)
                    {
                        MessageBox.Show("Salvato!");
                        this.DataContext = new LicencePlateEntity();
                    }
                    else
                        MessageBox.Show("Errore durante il salvataggio!");
                }
                else
                {
                    if (service.Update(this.DataContext as LicencePlateEntity) == 0)
                        MessageBox.Show("Salvato!");
                    else MessageBox.Show("Errore durante il salvataggio!");
                }

            }
        }
    }
}
