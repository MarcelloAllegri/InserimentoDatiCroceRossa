using InserimentoDatiCroceRossa.DbServiceObjects;
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

namespace InserimentoDatiCroceRossa.UserControls
{
    /// <summary>
    /// Logica di interazione per AddressDetailUserControl.xaml
    /// </summary>
    public partial class AddressDetailUserControl : UserControl
    {
        public AddressDetailUserControl()
        {
            InitializeComponent();
        }

        private bool CheckDoppione()
        {
            string addressName = (this.DataContext as AddressEntity).AddressName.ToLower();
            

            AddressService service = new AddressService();
            List<AddressEntity> indirizziDb = service.GetAllAddresses();

            if (indirizziDb.Any(x => x.AddressName.ToLower().Equals(addressName)))
                return true;

            return false;
        }

        private bool CheckData()
        {
            if (string.IsNullOrEmpty((this.DataContext as AddressEntity).AddressName))
            {
                MessageBox.Show("indirizzo vuoto!");
                return false;
            }           

            return true;
        }

        public void Save()
        {
            if (CheckData())
            {
                AddressService service = new AddressService();
                if ((this.DataContext as AddressEntity).Id == -1 && !CheckDoppione())
                {
                    if (service.Add(this.DataContext as AddressEntity) == 0)
                    {
                        MessageBox.Show("Salvato!");
                        this.DataContext = new AddressEntity();
                    }
                    else
                        MessageBox.Show("Errore durante il salvataggio!");
                }
                else
                {
                    if (service.Update(this.DataContext as AddressEntity) == 0)
                        MessageBox.Show("Salvato!");
                    else MessageBox.Show("Errore durante il salvataggio!");
                }

            }
        }
    }
}
