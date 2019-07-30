using InserimentoDatiCroceRossa.DbServiceObjects;
using InserimentoDatiCroceRossa.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace InserimentoDatiCroceRossa.UserControls
{
    /// <summary>
    /// Logica di interazione per CarLicPlateAssociationDetailUserControl.xaml
    /// </summary>
    public partial class CarLicPlateAssociationDetailUserControl : UserControl
    {
        public CarLicPlateAssociationDetailUserControl()
        {
            InitializeComponent();
        }

        public void Save()
        {
            if (CheckData())
            {
                CarLicPlateAssociationService service = new CarLicPlateAssociationService();
                if ((this.DataContext as CarLicencePlateAssociationEntity).Id == -1 && !CheckDoppione())
                {
                    int id = service.Add(this.DataContext as CarLicencePlateAssociationEntity);
                    if (id!=-1)
                    {
                        disableConcurrentRecords(id);
                        MessageBox.Show("Salvato!");
                        this.DataContext = new CarLicencePlateAssociationEntity();
                    }
                    else
                        MessageBox.Show("Errore durante il salvataggio!");
                }
                else
                {
                    if (service.Update(this.DataContext as CarLicencePlateAssociationEntity) == 0)
                    {
                        disableConcurrentRecords((this.DataContext as CarLicencePlateAssociationEntity).Id);
                        MessageBox.Show("Salvato!");
                    }
                    else MessageBox.Show("Errore durante il salvataggio!");
                }

            }
        }

        private void disableConcurrentRecords(int id)
        {
            CarLicencePlateAssociationEntity dt = this.DataContext as CarLicencePlateAssociationEntity;
            if (dt.IsEnabled == true)
            {
                using (var db = new InserimentoDatiCroceRossa.DbModel.CroceRossaEntities())
                {
                    List<int> concurrentIds = db.CarTar.Where(x => (x.CarId == dt.CarId || x.TarId == dt.LicencePlateId) &&
                    x.CarTarOwnId != id && x.CarTarEnb == true).Select(y => y.CarTarOwnId).ToList();

                    concurrentIds.ForEach(item => { db.CarTar.First(x => x.CarTarOwnId == item).CarTarEnb = false; });
                    db.SaveChanges();
                }
            }
        }

        private bool CheckDoppione()
        {
            string carName = (this.DataContext as CarLicencePlateAssociationEntity).CarName.ToLower();
            string LicPlate = (this.DataContext as CarLicencePlateAssociationEntity).LicencePlate.ToLower();

            CarLicPlateAssociationService service = new CarLicPlateAssociationService();
            List<CarLicencePlateAssociationEntity> associations = service.GetAllAssociation();

            if (associations.Any(x => x.CarName.ToLower().Equals(carName) && x.LicencePlate.ToLower().Equals(LicPlate)))
                return true;

            return false;
        }

        private bool CheckData()
        {
            if (string.IsNullOrEmpty((this.DataContext as CarLicencePlateAssociationEntity).CarName))
            {
                MessageBox.Show("Scegli l'automezzo!");
                return false;
            }

            if (string.IsNullOrEmpty((this.DataContext as CarLicencePlateAssociationEntity).LicencePlate))
            {
                MessageBox.Show("Scegli la targa!");
                return false;
            }

            return true;
        }

        public void populateLists()
        {
            (this.DataContext as CarLicencePlateAssociationEntity).CarList = new AutoService().GetAllCars();
            (this.DataContext as CarLicencePlateAssociationEntity).LicencePlateList = new LicencePlateService().GetAllLicencePlates();
            
        }
    }
}
