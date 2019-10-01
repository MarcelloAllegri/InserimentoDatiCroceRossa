using InserimentoDatiCroceRossa.DbServiceObjects;
using InserimentoDatiCroceRossa.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logica di interazione per DataCollectionDetailUserControl.xaml
    /// </summary>
    public partial class DataCollectionDetailUserControl : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<PatientEntity> m_patientsCollection;
        private ObservableCollection<PathologyEntity> m_pathologiesCollection;
        private ObservableCollection<CarLicencePlateAssociationEntity> m_carLicPlateAssociations;
        private ObservableCollection<VolunteerEntity> m_volunteersList;
        private ObservableCollection<AuthorityEntity> m_entitiesList;

        protected void NotifyPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public ObservableCollection<PathologyEntity> PathologiesCollection
        {
            get { return m_pathologiesCollection; }
            set
            {
                m_pathologiesCollection = value;
                NotifyPropertyChanged(nameof(PathologiesCollection));
            }
        }
        public ObservableCollection<PatientEntity> PatientsCollection
        {
            get { return m_patientsCollection; }
            set
            {
                m_patientsCollection = value;
                NotifyPropertyChanged(nameof(PatientsCollection));
            }
        }
        public Dictionary<int, string> ServiceTypologiesCollection
        {
            get
            {
                return new Dictionary<int, string>()
                {
                    { 1, "Istituto"},
                    { 2, "Ordinario"},
                    { 3, "Urgente"},
                    { 4, "Protezione Civile"},
                    { 5, "Deceduto"},
                    { 6, "Altro Servizio"},
                    { 7, "Annullato"},
                    {-1, "Non specificato"},
            };
            }
        }
        public ObservableCollection<CarLicencePlateAssociationEntity> CarLicPlateAssociations
        {
            get { return m_carLicPlateAssociations; }
            set
            {
                m_carLicPlateAssociations = value;
                NotifyPropertyChanged(nameof(CarLicPlateAssociations));
            }
        }
        public ObservableCollection<VolunteerEntity> VolunteersList
        {
            get { return m_volunteersList; }
            set
            {
                m_volunteersList = value;
                NotifyPropertyChanged(nameof(VolunteersList));
            }
        }
        public ObservableCollection<AuthorityEntity> EntitiesList
        {
            get { return m_entitiesList; }
            set
            {
                m_entitiesList = value;
                NotifyPropertyChanged(nameof(EntitiesList));
            }
        }

        public DataCollectionDetailUserControl()
        {
            InitializeComponent();
        }

        private void DataCollectionDetailUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.RefreshBackgroundData();
        }

        private void RefreshBackgroundData()
        {
            using (new WaitCursor())
            {
                this.PathologiesCollection = new ObservableCollection<PathologyEntity>(new PathologyService().GetAllPathologies());
                this.PatientsCollection = new ObservableCollection<PatientEntity>(new PatientService().GetAllPatients());
                this.CarLicPlateAssociations = new ObservableCollection<CarLicencePlateAssociationEntity>(new CarLicPlateAssociationService().GetAllAssociation().Where(x=>x.IsEnabled == true).OrderBy(x=> x.CarName));
                this.VolunteersList = new ObservableCollection<VolunteerEntity>(new VolunteerService().GetAllVolunteers());
                this.EntitiesList = new ObservableCollection<AuthorityEntity>(new AuthorityService().GetAllAuthorities());
            }
        }

        private void PatientChooserButton_Click(object sender, RoutedEventArgs e)
        {
            this.PatientChooserToolbar.Visibility = Visibility.Visible;
            this.patientChooserUserControl.Visibility = Visibility.Visible;
            this.patientChooserUserControl.RefreshData();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.patientChooserUserControl.lvPatient.SelectedItem;

            if(selectedItem != null)
            {
                (this.DataContext as DataCollectionViewEntity).PatientId = (selectedItem as PatientEntity).Id;
                this.SelectedPatientTextBox.Text = (this.DataContext as DataCollectionViewEntity).PatientFCdAndFullName;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.PatientChooserToolbar.Visibility = Visibility.Collapsed;
            this.patientChooserUserControl.Visibility = Visibility.Collapsed;
        }
    }
}
