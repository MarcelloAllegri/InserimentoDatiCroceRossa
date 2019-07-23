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
    /// Logica di interazione per VolunteerDetailUserControl.xaml
    /// </summary>
    public partial class VolunteerDetailUserControl : UserControl
    {
        public VolunteerDetailUserControl()
        {
            InitializeComponent();
        }

        private bool CheckDoppione()
        {
            string name = (this.DataContext as VolunteerEntity).Name.ToLower();
            string surname = (this.DataContext as VolunteerEntity).Surname.ToLower();

            VolunteerService volunteerService = new VolunteerService();
            List<VolunteerEntity> volontariDb = volunteerService.GetAllVolunteers();

            if (volontariDb.Any(x => x.Name.ToLower().Equals(name)) && volontariDb.Any(x => x.Surname.ToLower().Equals(surname)))
                return true;

            return false;
        }

        private bool CheckData()
        {
            if (string.IsNullOrEmpty((this.DataContext as VolunteerEntity).Name))
            {
                MessageBox.Show("Nome vuoto!");
                return false;
            }

            if (string.IsNullOrEmpty((this.DataContext as VolunteerEntity).Surname))
            {
                MessageBox.Show("Cognome vuoto!");
                return false;
            }

            return true;
        }

        public void Save()
        {
            if (CheckData())
            {
                VolunteerService volunteerService = new VolunteerService();
                if ((this.DataContext as VolunteerEntity).Id == -1 && !CheckDoppione())
                {
                    if (volunteerService.Add(this.DataContext as VolunteerEntity) == 0)
                    {
                        MessageBox.Show("Salvato!");
                        this.DataContext = new VolunteerEntity();
                    }
                    else
                        MessageBox.Show("Errore durante il salvataggio!");
                }
                else
                {
                    if (volunteerService.Update(this.DataContext as VolunteerEntity) == 0)
                        MessageBox.Show("Salvato!");
                    else MessageBox.Show("Errore durante il salvataggio!");
                }

            }
        }
    }
}
