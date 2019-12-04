using InserimentoDatiCroceRossa.DbServiceObjects;
using InserimentoDatiCroceRossa.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace InserimentoDatiCroceRossa.UserControls
{
    /// <summary>
    /// Logica di interazione per PatientDetailUserControl.xaml
    /// </summary>
    public partial class PatientDetailUserControl : UserControl
    {
        public PatientDetailUserControl()
        {
            InitializeComponent();
        }

        public Dictionary<int,string> SexsDictionary
        {
            get
            {
                return new Dictionary<int, string>()
                {
                    {0,"Non specificato" },
                    {1,"M" },
                    {2,"F" }
                };
            }
        }

        private bool CheckDoppione()
        {
            PatientEntity patient = (this.DataContext as PatientEntity);
            PatientService service = new PatientService();
            List<PatientEntity> patients = service.GetAllPatients();

            if (patients.Any(x => !string.IsNullOrEmpty(x.FiscalCode) && x.FiscalCode.ToLower().Equals(patient.FiscalCode.ToLower()) && x.Id != patient.Id))
            {
                MessageBox.Show("Esiste già un paziente con lo stesso codice fiscale!");
                return true;
            }
            return false;
        }

        private bool CheckData()
        {
            PatientEntity patient = (this.DataContext as PatientEntity);

            if (string.IsNullOrEmpty(patient.Name))
            {
                MessageBox.Show("nome vuoto!");
                return false;
            }
            if (string.IsNullOrEmpty(patient.Surname))
            {
                MessageBox.Show("cognome vuoto!");
                return false;
            }
            if (patient.Bday == null)
            {
                MessageBox.Show("data di nascita non inserita!");
                return false;
            }

            return true;
        }

        public void Save()
        {
            if (CheckData() && !CheckDoppione())
            {
                PatientService service = new PatientService();
                if ((this.DataContext as PatientEntity).Id == -1)
                {
                    if (service.Add(this.DataContext as PatientEntity) == 0)
                    {
                        MessageBox.Show("Salvato!");
                        this.DataContext = new PatientEntity();
                    }
                    else
                        MessageBox.Show("Errore durante il salvataggio!");
                }
                else
                {
                    if (service.Update(this.DataContext as PatientEntity) == 0)
                        MessageBox.Show("Salvato!");
                    else MessageBox.Show("Errore durante il salvataggio!");
                }

            }
        }
    }
}
