using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Collections.ObjectModel;

using mD_WPF_chSheet_01.Models.dzeta;
using mD_WPF_chSheet_01.pages;
using mD_WPF_chSheet_01.pages.selectorPage;
using mD_WPF_chSheet_01.windows;

namespace mD_WPF_chSheet_01.pages.selectorPage
{
    /// <summary>
    /// Interaction logic for SelectReadyCharacterPage.xaml
    /// </summary>
    public partial class drawnCharacterFirstPage : Page
    {
        dzetaContext context = new dzetaContext();
        ObservableCollection<openScreen> os = new ObservableCollection<openScreen>();

        public drawnCharacterFirstPage()
        {
            InitializeComponent();

            context.Races.Load();
            context.Characters.Load();


            IEnumerable<openScreen> selectedRace = (from Race in context.Races
                join raceskill in context.Racesskills on Race.Id equals raceskill.RaceId
                join skill in context.Skills on raceskill.SkillId equals skill.Id
                join charskill in context.Charactersskills on skill.Id equals charskill.SkillId
                join Character in context.Characters on charskill.CharacterId equals Character.Id
                select new openScreen
                {
                    openId = Race.Id,
                    openRace = Race.RaceName,
                    openGender = Race.Gender,
                    openName = Character.Name
                }).OrderBy(x=>x.openName).ToList();

            LBO_PlayingCharacter.ItemsSource = selectedRace;
            LBO_PlayingCharacter.SelectedIndex = 0;

            CBO_RaceSelector.ItemsSource = context.Races.Local.GroupBy(x => x.RaceName).Select(x => x.FirstOrDefault());
            CBO_RaceSelector.SelectedIndex = -1;


            CBO_GenderSelector.ItemsSource = context.Races.Local.Select(x => x.Gender).ToList().Distinct();
            CBO_GenderSelector.SelectedIndex = -1;
        }

        private void CBO_RaceSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBO_RaceSelector.SelectedItem != null)
            {
                IEnumerable<openScreen> selectedRace = (from Race in context.Races
                    join raceskill in context.Racesskills on Race.Id equals raceskill.RaceId
                    join skill in context.Skills on raceskill.SkillId equals skill.Id
                    join charskill in context.Charactersskills on skill.Id equals charskill.SkillId
                    join Character in context.Characters on charskill.CharacterId equals Character.Id
                    where (Character.RaceId == ((Races)CBO_RaceSelector.SelectedItem).Id) &&
                    (Race.Gender == (string)CBO_GenderSelector.SelectedItem)
                    select new openScreen
                    {
                        openId = Race.Id,
                        openRace = Race.RaceName,
                        openGender = Race.Gender,
                        openName = Character.Name
                    }).ToList();
                
                LBO_PlayingCharacter.ItemsSource = selectedRace;
                LBO_PlayingCharacter.SelectedIndex = 0;
            }
        }

        private void CBO_GenderSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBO_GenderSelector.SelectedItem != null)
            {
                IEnumerable<openScreen> selectedRace = (from Race in context.Races
                    join raceskill in context.Racesskills on Race.Id equals raceskill.RaceId
                    join skill in context.Skills on raceskill.SkillId equals skill.Id
                    join charskill in context.Charactersskills on skill.Id equals charskill.SkillId
                    join Character in context.Characters on charskill.CharacterId equals Character.Id
                    where /*(Character.RaceId == ((Races)CBO_RaceSelector.SelectedItem).Id) &&*/
                    (Race.Gender == (string)CBO_GenderSelector.SelectedItem)
                    select new openScreen
                    {
                        openId = Race.Id,
                        openRace = Race.RaceName,
                        openGender = Race.Gender,
                        openName = Character.Name
                    }).ToList();

                LBO_PlayingCharacter.ItemsSource = selectedRace;
                LBO_PlayingCharacter.SelectedIndex = 0;
            }
        }

        public class openScreen
        {
            public int openId { get; set; }
            public string openName { get; set; }
            public string openRace { get; set; }
            public string openGender { get; set; }

            public openScreen()
            {

            }

            public openScreen(int openId, string openName, string openRace, string openGender)
            {
                this.openId = openId;
                this.openRace = openRace;
                this.openGender = openGender;
                this.openName = openName;
            }
        }


    }
}
