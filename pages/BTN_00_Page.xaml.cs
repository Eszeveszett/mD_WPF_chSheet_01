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
using System.IO;

using mD_WPF_chSheet_01.pages;
using mD_WPF_chSheet_01.windows;

namespace mD_WPF_chSheet_01.pages
{
    /// <summary>
    /// Interaction logic for BTN_00_Page.xaml
    /// </summary>
    public partial class BTN_00_Page : Page
    {
        List<string> race = new List<string>();
        List<string> gender = new List<string>();
        List<string> raceDescription = new List<string>();
        List<string> attributumDescription = new List<string>();
        List<string> backgroundDescription = new List<string>();


        List<testClass> tc = new List<testClass>();
        public BTN_00_Page()
        {
            InitializeComponent();

            //Demo adatok (Kurvasok, kurva felesleges)
            #region demoadatok
            //race.Add("Orc"); race.Add("Human"); race.Add("Gnome"); race.Add("Goblin"); race.Add("Parasit"); race.Add("Symbiont");

            //gender.Add("Male"); gender.Add("Female"); gender.Add("Transgender"); gender.Add("Genderless");

            //attributumDescription.Add("Vitality");
            //attributumDescription.Add("Endurence");
            //attributumDescription.Add("Toughness");
            //attributumDescription.Add("Strength");

            //attributumDescription.Add("Dexterity");
            //attributumDescription.Add("Perception");
            //attributumDescription.Add("Quickness");
            //attributumDescription.Add("Agility");

            //attributumDescription.Add("Intuition");
            //attributumDescription.Add("Wisdom");
            //attributumDescription.Add("Intelligence");
            //attributumDescription.Add("Resourcefull");

            //attributumDescription.Add("Charisma");
            //attributumDescription.Add("Appearance");
            //attributumDescription.Add("Influence");
            //attributumDescription.Add("Luck");

            //backgroundDescription.Add("None"); backgroundDescription.Add("Sailor");
            //backgroundDescription.Add("Fisher"); backgroundDescription.Add("Woodcutter");
            //backgroundDescription.Add("Vilager"); backgroundDescription.Add("Nooble");
            #endregion
            olvaso();
            LBO_race.DataContext = tc;
        }

        private void olvaso()
        {
            StreamReader sr = new StreamReader("../../documents/raceAge.txt");
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] szo = sor.Split(';');

                tc.Add(new testClass(szo[0], (Convert.ToInt32(szo[1]))));
            }
        }
    }
}
