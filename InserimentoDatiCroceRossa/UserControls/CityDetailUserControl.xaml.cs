using InserimentoDatiCroceRossa.DbServiceObjects;
using InserimentoDatiCroceRossa.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace InserimentoDatiCroceRossa.UserControls
{
    /// <summary>
    /// Logica di interazione per CityDetailUserControl.xaml
    /// </summary>
    public partial class CityDetailUserControl : UserControl
    {
        public CityDetailUserControl()
        {
            InitializeComponent();
        }

        private bool CheckDoppione()
        {
            string cityName = (this.DataContext as CityEntity).CityName.ToLower();

            CityService service = new CityService();
            List<CityEntity> cities = service.GetAllCities();

            if (cities.Any(x => x.CityName.ToLower().Equals(cityName)))
                return true;

            return false;
        }

        private bool CheckData()
        {
            if (string.IsNullOrEmpty((this.DataContext as CityEntity).CityName))
            {
                MessageBox.Show("città vuota!");
                return false;
            }

            return true;
        }

        public void Save()
        {
            if (CheckData())
            {
                CityService service = new CityService();
                if ((this.DataContext as CityEntity).Id == -1 && !CheckDoppione())
                {
                    if (service.Add(this.DataContext as CityEntity) == 0)
                    {
                        MessageBox.Show("Salvato!");
                        this.DataContext = new CityEntity();
                    }
                    else
                        MessageBox.Show("Errore durante il salvataggio!");
                }
                else
                {
                    if (service.Update(this.DataContext as CityEntity) == 0)
                        MessageBox.Show("Salvato!");
                    else MessageBox.Show("Errore durante il salvataggio!");
                }

            }
        }
    }
}
