using InserimentoDatiCroceRossa.DbServiceObjects;
using InserimentoDatiCroceRossa.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace InserimentoDatiCroceRossa.UserControls
{
    /// <summary>
    /// Logica di interazione per PathologyDetailUserControl.xaml
    /// </summary>
    public partial class PathologyDetailUserControl : UserControl
    {
        public PathologyDetailUserControl()
        {
            InitializeComponent();
        }

        private bool CheckDoppione()
        {
            string pathologyName = (this.DataContext as PathologyEntity).PathologyName.ToLower();

            PathologyService service = new PathologyService();
            List<PathologyEntity> pathologies = service.GetAllPathologies();

            if (pathologies.Any(x => x.PathologyName.ToLower().Equals(pathologyName)))
                return true;

            return false;
        }

        private bool CheckData()
        {
            if (string.IsNullOrEmpty((this.DataContext as PathologyEntity).PathologyName))
            {
                MessageBox.Show("nome patologia vuoto!");
                return false;
            }

            return true;
        }

        public void Save()
        {
            if (CheckData())
            {
                PathologyService service = new PathologyService();
                if ((this.DataContext as PathologyEntity).Id == -1 && !CheckDoppione())
                {
                    if (service.Add(this.DataContext as PathologyEntity) == 0)
                    {
                        MessageBox.Show("Salvato!");
                        this.DataContext = new PathologyEntity();
                    }
                    else
                        MessageBox.Show("Errore durante il salvataggio!");
                }
                else
                {
                    if (service.Update(this.DataContext as PathologyEntity) == 0)
                        MessageBox.Show("Salvato!");
                    else MessageBox.Show("Errore durante il salvataggio!");
                }

            }
        }
    }
}
