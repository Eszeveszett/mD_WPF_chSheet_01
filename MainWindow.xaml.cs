﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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


using System.Collections.ObjectModel;

using mD_WPF_chSheet_01.pages;
using mD_WPF_chSheet_01.windows;
using mD_WPF_chSheet_01.NetworkingCommunication;

namespace mD_WPF_chSheet_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> race = new List<string>();
        List<string> gender = new List<string>();
        List<string> raceDescription = new List<string>();
        List<string> attributumDescription = new List<string>();
        List<string> backgroundDescription = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            //FRM_startPage.Content = new mainWindowPage();
            //Demo adatok (Kurvasok, kurvafelesleges)
            //race.Add("Orc"); race.Add("Human"); race.Add("Gnome"); race.Add("Goblin"); race.Add("Parasit"); race.Add("Symbiont");

            //gender.Add("Male"); gender.Add("Female"); gender.Add("Transgender"); gender.Add("Genderless");
            #region attributumDescription
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



        }

        private void BTN_newGame_Click(object sender, RoutedEventArgs e)
        {
            quickStartWindow arbitrament = new quickStartWindow();
            arbitrament.Show();
        }

        private void BTN_quitGame_Click(object sender, RoutedEventArgs e)
        {
            //MessageBoxResult quitGame = MessageBox.Show("Really escape?", "Escape?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            //switch (quitGame)
            //{
            //    case MessageBoxResult.Yes:
            //        Close();
            //        break;
            //    case MessageBoxResult.No:
            //        break;
            //}
            //Thread.Sleep(250);
            Close();

        }

        private void BTN_testing_Click(object sender, RoutedEventArgs e)
        {
            testWindow tw = new testWindow();
            tw.ShowDialog();
        }

        private void BTN_Connection_Click(object sender, RoutedEventArgs e)
        {
            ConnectionSelectorWindow csw = new ConnectionSelectorWindow();
            csw.Show();
        }

        private void BTN_Connection_MouseEnter(object sender, MouseEventArgs e)
        {
            BTN_Connection.Width = 125;
            
        }

        private void BTN_Connection_MouseLeave(object sender, MouseEventArgs e)
        {
            BTN_Connection.Width = 100;
            
        }

        private void BTN_Continue_MouseEnter(object sender, MouseEventArgs e)
        {
            TBL_cLower.FontSize = 14;
            TBL_cUpper.FontSize = 14;
        }

        private void BTN_Continue_MouseLeave(object sender, MouseEventArgs e)
        {
            TBL_cLower.FontSize = 12;
            TBL_cUpper.FontSize = 12;
        }

        private void BTN_newGame_MouseEnter(object sender, MouseEventArgs e)
        {
            BTN_newGame.Width = 125;
        }

        private void BTN_newGame_MouseLeave(object sender, MouseEventArgs e)
        {
            BTN_newGame.Width = 100;
        }

        private void BTN_quitGame_MouseEnter(object sender, MouseEventArgs e)
        {
            BTN_quitGame.Width = 125;
        }

        private void BTN_quitGame_MouseLeave(object sender, MouseEventArgs e)
        {
            BTN_quitGame.Width = 100;
        }


    }
}
