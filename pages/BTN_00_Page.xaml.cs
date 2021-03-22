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
        List<string> gender = new List<string>();


        List<testClass> tc = new List<testClass>();
        public BTN_00_Page()
        {
            gender.Add("Male"); gender.Add("Female"); gender.Add("Transgender"); gender.Add("Genderless");

            InitializeComponent();
            olvaso();
            LBO_race.DataContext = tc;
            LBO_race.SelectedIndex = -1;
            LBO_gender.DataContext = gender;
            LBO_gender.SelectedIndex = -1;

            
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

        private void LBO_race_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void LBO_gender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        //private void BTN_race_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void BTN_background_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private void BTN_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
