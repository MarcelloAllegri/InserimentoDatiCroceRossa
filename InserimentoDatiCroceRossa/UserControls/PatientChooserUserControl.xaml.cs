using InserimentoDatiCroceRossa.DbServiceObjects;
using InserimentoDatiCroceRossa.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logica di interazione per PatientChooserUserControl.xaml
    /// </summary>
    public partial class PatientChooserUserControl : UserControl
    {
        private ObservableCollection<PatientEntity> m_patientsList;

        public ObservableCollection<PatientEntity> PatientList
        {
            get { return m_patientsList; }
            set { m_patientsList = value; }
        }

        public PatientChooserUserControl()
        {
            InitializeComponent();
        }

        private void FilterContentButton_Click(object sender, RoutedEventArgs e)
        {
            string text = this.FilterTextBox.Text;

            if (string.IsNullOrEmpty(text))
                this.RefreshData();
            else
            {
                using (new WaitCursor())
                {
                    this.PatientList = new ObservableCollection<PatientEntity>(new PatientService().GetAllPatients());

                    this.lvPatient.ItemsSource = new ObservableCollection<PatientEntity>(
                          PatientList.Where(x => x.FiscalCode.ToLower().Contains(text.ToLower()) ||
                          x.Surname.ToLower().Contains(text.ToLower()) ||
                          x.Name.ToLower().Contains(text.ToLower())).ToList());
                }
            }
        }

        public void RefreshData()
        {
            using (new WaitCursor())
            {
                this.PatientList = new ObservableCollection<PatientEntity>(new PatientService().GetAllPatients());
                this.lvPatient.ItemsSource = PatientList;
                this.FilterTextBox.Text = string.Empty;
            }
        }
    }
}
