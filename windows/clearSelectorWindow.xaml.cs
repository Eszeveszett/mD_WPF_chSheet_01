using System;
using System.Collections.Generic;
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

using mD_WPF_chSheet_01.userControl;
using mD_WPF_chSheet_01.pages;
using mD_WPF_chSheet_01.windows;

using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Collections.ObjectModel;

using mD_WPF_chSheet_01.Models.dzeta;

namespace mD_WPF_chSheet_01.windows
{
    /// <summary>
    /// Interaction logic for clearSelectorWindow.xaml
    /// </summary>
    public partial class clearSelectorWindow : Window
    {
        dzetaContext context = new dzetaContext();

        List<Races> races = new List<Races>();
        List<Characters> characters = new List<Characters>();
        List<Charactersskills> charactersskills = new List<Charactersskills>();
        List<Racesskills> racessklikks = new List<Racesskills>();
        List<Skills> skills = new List<Skills>();

        public clearSelectorWindow()
        {
            InitializeComponent();

            context.Races.Load();
            foreach (var item in context.Races)
            {
                races.Add(item);
            }

            context.Characters.Load();
            foreach (var item in context.Characters)
            {
                characters.Add(item);
            }

            context.Charactersskills.Load();
            foreach (var item in context.Charactersskills)
            {
                charactersskills.Add(item);
            }

            context.Racesskills.Load();
            foreach (var item in context.Racesskills)
            {
                racessklikks.Add(item);
            }

            context.Skills.Load();
            foreach (var item in context.Skills)
            {
                skills.Add(item);
            }

            LBO_rRace.ItemsSource = context.Races.Local.ToObservableCollection();
            LBO_rRace.SelectedIndex = -1;
        }

        private void BTN_Exit_Click(object sender, RoutedEventArgs e)
        {
            quickStartWindow qsw = new quickStartWindow();
            this.Close();
            qsw.Show();
        }

        private void BTN_finaly_Click(object sender, RoutedEventArgs e)
        {
            characterStatisticWindow csw = new characterStatisticWindow();
            this.Close();
            csw.Show();
        }

        private void LBO_rRace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LBO_rRace.SelectedItem != null)
            {
                TBO_raceModifier.Text = ((Races)LBO_rRace.SelectedItem).RaceName + " " + ((Races)LBO_rRace.SelectedItem).Gender
                    + " Race Modifier" + "\n\n Na most már minden változik";

                TBO_placeOfLive.Text = ((Races)LBO_rRace.SelectedItem).RaceName + " " + ((Races)LBO_rRace.SelectedItem).Gender
                    + " " + ((Races)LBO_rRace.SelectedItem).Description + "\n\n Csak a Bohr állandó";
            }
            else
            {
                TBO_raceModifier.Text = "Faji sajátosságok";
                TBO_placeOfLive.Text = "Faj történelme és élőhelye";
            }
        }
    }
}
