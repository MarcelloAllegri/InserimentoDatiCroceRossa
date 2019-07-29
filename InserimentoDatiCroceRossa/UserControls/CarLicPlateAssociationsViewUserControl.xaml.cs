using InserimentoDatiCroceRossa.DbServiceObjects;
using InserimentoDatiCroceRossa.Objects;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace InserimentoDatiCroceRossa.UserControls
{
    /// <summary>
    /// Logica di interazione per CarLicPlateAssociationsViewUserControl.xaml
    /// </summary>
    public partial class CarLicPlateAssociationsViewUserControl : UserControl
    {
        ObservableCollection<CarLicencePlateAssociationEntity> associations = new ObservableCollection<CarLicencePlateAssociationEntity>();
        public CarLicPlateAssociationsViewUserControl()
        {
            InitializeComponent();
        }

        private void CarLicPlateAssociationsViewUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            associations = new ObservableCollection<CarLicencePlateAssociationEntity>(new CarLicPlateAssociationService().GetAllAssociation());
            this.lvAssociations.ItemsSource = associations;
        }
    }
}
