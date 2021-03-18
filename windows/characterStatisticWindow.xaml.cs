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
using System.Windows.Shapes;

namespace mD_WPF_chSheet_01.windows
{
    /// <summary>
    /// Interaction logic for characterStatisticWindow.xaml
    /// </summary>
    public partial class characterStatisticWindow : Window
    {
        List<string> race = new List<string>();
        List<string> gender = new List<string>();
        List<string> raceDescription = new List<string>();
        List<string> attributumDescription = new List<string>();
        List<string> backgroundDescription = new List<string>();
        public characterStatisticWindow()
        {
            InitializeComponent();
            //Demo adatok (Kurvasok, kurva felesleges)
            race.Add("Orc"); race.Add("Human"); race.Add("Gnome"); race.Add("Goblin"); race.Add("Parasit"); race.Add("Symbiont");

            gender.Add("Male"); gender.Add("Female"); gender.Add("Transgender"); gender.Add("Genderless");
            #region attributumDescription
            attributumDescription.Add("Vitality");
            attributumDescription.Add("Endurence");
            attributumDescription.Add("Toughness");
            attributumDescription.Add("Strength");

            attributumDescription.Add("Dexterity");
            attributumDescription.Add("Perception");
            attributumDescription.Add("Quickness");
            attributumDescription.Add("Agility");

            attributumDescription.Add("Intuition");
            attributumDescription.Add("Wisdom");
            attributumDescription.Add("Intelligence");
            attributumDescription.Add("Resourcefull");

            attributumDescription.Add("Charisma");
            attributumDescription.Add("Appearance");
            attributumDescription.Add("Influence");
            attributumDescription.Add("Luck");
            #endregion
            backgroundDescription.Add("None"); backgroundDescription.Add("Sailor");
            backgroundDescription.Add("Fisher"); backgroundDescription.Add("Woodcutter");
            backgroundDescription.Add("Vilager"); backgroundDescription.Add("Nooble");

            CBO_raceSelection.ItemsSource = race;
            CBO_raceSelection.SelectedIndex = 0;
            CBO_genderSelection.ItemsSource = gender;
            CBO_genderSelection.SelectedIndex = 0;

            LBO_attributumBlock.DataContext = attributumDescription;
        }

        private void CBO_raceSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TBO_raceDescription.Text = race[CBO_raceSelection.SelectedIndex] + " Description";
        }

        private void CBO_genderSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TBO_raceDescription.Text = race[CBO_raceSelection.SelectedIndex] + " Description";
        }

        private void LBO_attributumBlock_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TBO_attributumDescription.Text = attributumDescription[LBO_attributumBlock.SelectedIndex];
            }
            catch (Exception)
            {

                TBO_attributumDescription.Text = "Az index nem található";
            }
        }

        private void LBO_backgroundSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TBO_backgroundDescription.Text = string.Format("{0} {1} {2}", race[CBO_raceSelection.SelectedIndex],
                gender[CBO_genderSelection.SelectedIndex], backgroundDescription[LBO_backgroundSelector.SelectedIndex]);
        }

        private void btn_prev_Click(object sender, RoutedEventArgs e)
        {
            clearSelectorWindow csw = new clearSelectorWindow();
            this.Close();
            csw.Show();
        }
    }
}
