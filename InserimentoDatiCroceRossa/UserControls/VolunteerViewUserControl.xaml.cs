using InserimentoDatiCroceRossa.DbClasses;
using InserimentoDatiCroceRossa.DbServiceObjects;
using InserimentoDatiCroceRossa.Objects;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace InserimentoDatiCroceRossa.UserControls
{
    /// <summary>
    /// Logica di interazione per VolunteerViewUserControl.xaml
    /// </summary>
    public partial class VolunteerViewUserControl : UserControl
    {
        ObservableCollection<VolunteerEntity> volunteers = new ObservableCollection<VolunteerEntity>();
        public void RefreshData()
        {
            VolunteerService service = new VolunteerService();
            volunteers = new ObservableCollection<VolunteerEntity>(service.GetAllVolunteers());
            this.lvVolunteers.ItemsSource = volunteers;            
        }
        public VolunteerViewUserControl()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.VolunteerListTabItem.Visibility = Visibility.Collapsed;
            this.CloseButton.Visibility = this.volunteerDetailTabItem.Visibility = this.SaveButton.Visibility = Visibility.Visible;

            this.volunteerDetailTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            volunteerDetailUserControl.DataContext = new VolunteerEntity();
        }

        private void ModifyUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.lvVolunteers.SelectedItem;

            if (selectedItem != null)
            {
                this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.VolunteerListTabItem.Visibility = Visibility.Collapsed;
                this.CloseButton.Visibility = this.volunteerDetailTabItem.Visibility = this.SaveButton.Visibility = Visibility.Visible;

                this.volunteerDetailTabItem.IsSelected = true;
                this.TabControl.UpdateLayout();

                volunteerDetailUserControl.DataContext = selectedItem as VolunteerEntity;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            volunteerDetailUserControl.Save();
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.lvVolunteers.SelectedItem;

            if (selectedItem != null)
            {
                VolunteerEntity volunteer = selectedItem as VolunteerEntity;

                VolunteerService service = new VolunteerService();
                if (MessageBox.Show("Sei sicuro di voler eliminare \"" + volunteer.Name + " " + volunteer.Surname + " \" ?", "Elimina Volontario", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (service.Delete(volunteer) == 0)
                        MessageBox.Show("cancellato!");
                    else
                        MessageBox.Show("NON cancellato!");
                }
                else
                    MessageBox.Show("NON cancellato!");
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.AddButton.Visibility = this.DeleteButton.Visibility = this.ModifyButton.Visibility = this.VolunteerListTabItem.Visibility = Visibility.Visible;
            this.CloseButton.Visibility = this.SaveButton.Visibility = this.volunteerDetailTabItem.Visibility = Visibility.Collapsed;

            this.VolunteerListTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            volunteerDetailTabItem.DataContext = new VolunteerEntity();
            RefreshData();
        }

        private void VolunteerViewUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }
    }
}
