using InserimentoDatiCroceRossa.DbServiceObjects;
using InserimentoDatiCroceRossa.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace InserimentoDatiCroceRossa.UserControls
{
    /// <summary>
    /// Logica di interazione per AutoDetailUserControl.xaml
    /// </summary>
    public partial class AutoDetailUserControl : UserControl
    {
        public AutoDetailUserControl()
        {
            InitializeComponent();
        }

        private bool CheckDoppione()
        {
            string carName = (this.DataContext as AutoEntity).CarName.ToLower();


            AutoService service = new AutoService();
            List<AutoEntity> cars = service.GetAllCars();

            if (cars.Any(x => x.CarName.ToLower().Equals(carName)))
                return true;

            return false;
        }

        private bool CheckData()
        {
            if (string.IsNullOrEmpty((this.DataContext as AutoEntity).CarName))
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
                AutoService service = new AutoService();
                if ((this.DataContext as AutoEntity).Id == -1 && !CheckDoppione())
                {
                    if (service.Add(this.DataContext as AutoEntity) == 0)
                    {
                        MessageBox.Show("Salvato!");
                        this.DataContext = new AutoEntity();
                    }
                    else
                        MessageBox.Show("Errore durante il salvataggio!");
                }
                else
                {
                    if (service.Update(this.DataContext as AutoEntity) == 0)
                        MessageBox.Show("Salvato!");
                    else MessageBox.Show("Errore durante il salvataggio!");
                }

            }
        }
    }
}
