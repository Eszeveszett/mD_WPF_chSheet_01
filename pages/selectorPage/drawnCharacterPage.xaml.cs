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
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.ObjectModel;

using mD_WPF_chSheet_01.Models.dzeta;

namespace mD_WPF_chSheet_01.pages.selectorPage
{
    // <summary>
    // Interaction logic for drawnCharacterPage.xaml
    // </summary>
    public partial class drawnCharacterPage : Page
    {
        public class displayedData
        {
            public int dcId { get; set; }
            public int drId { get; set; }
            public string dName { get; set; }
            public string dRace { get; set; }
            public string dGender { get; set; }
            //Igen baszod? Kell? Nesze baszod
            public BitmapImage dImage { get; set; }
        }


        dzetaContext context = new dzetaContext();

        List<Races> races = new List<Races>();
        List<Characters> characters = new List<Characters>();
        List<Charactersskills> charactersskills = new List<Charactersskills>();
        List<Racesskills> racessklikks = new List<Racesskills>();
        List<Skills> skills = new List<Skills>();
        List<displayedData> dData = new List<displayedData>();

        ObservableCollection<displayedData> gender = new ObservableCollection<displayedData>();

        /*private*/
        ObservableCollection<displayedData> raceList { get; set; }

        //ObservableCollection<displayedData> Expandinglist = new ObservableCollection<displayedData>();

        public drawnCharacterPage()
        {
            InitializeComponent();

            // Sok sok lófasz betöltése, listába pakolása

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



            for (int c = 0; c < characters.Count; c++)
            {
                for (int r = 0; r < races.Count; r++)
                {
                    if (characters[c].RaceId == races[r].Id)
                    {
                BitmapImage bi = new BitmapImage();

                bi.BeginInit();
                bi.UriSource = new Uri(@"/images/chIcon/" + characters[c].RaceId + ".jpg", UriKind.RelativeOrAbsolute);
                        dData.Add(new displayedData()
                        {
                            dcId = characters[c].Id,
                            drId = characters[c].RaceId,
                            dName = characters[c].Name,
                            dRace = races[r].RaceName,
                            dGender = races[r].Gender,
                            dImage = bi
                        });
                bi.EndInit();
                    }
                }

            }

            LBO_PlayingCharacter.ItemsSource = dData;

            CBO_RaceSelector.ItemsSource = dData.Select(x => x.dRace).Distinct();
            //CBO_RaceSelectorTwo.ItemsSource = dData.Select(x => x.dRace).Distinct();

            CBO_GenderSelector.ItemsSource = dData.Select(x => x.dGender).Distinct();
            //CBO_GenderSelectorTwo.ItemsSource = dData.Select(x => x.dGender).Distinct();

            LBO_characterSkills.ItemsSource = raceList;

            LBO_raceSkills.Visibility = Visibility.Hidden;
            LBO_characterSkills.Visibility = Visibility.Hidden;
        }

        private void CBO_RaceSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            raceList = new ObservableCollection<displayedData>(dData.Where(x => x.dRace == CBO_RaceSelector.SelectedItem.ToString()));
            LBO_PlayingCharacter.ItemsSource = raceList;
        }

        private void CBO_GenderSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            raceList = new ObservableCollection<displayedData>(dData.Where(x => x.dGender == CBO_GenderSelector.SelectedItem.ToString()));
            LBO_PlayingCharacter.ItemsSource = raceList;
        }

        //private void BTN_Male_Click(object sender, RoutedEventArgs e)
        //{
        //    gender.Clear();
        //    for (int outSide = 0; outSide < dData.Count; outSide++)
        //    {
        //        if (dData[outSide].dGender != "Female")
        //        {
        //            gender.Add(dData[outSide]);
        //        }
        //    }
        //    LBO_PlayingCharacter.ItemsSource = gender;
        //    LBO_raceSkills.Visibility = Visibility.Hidden;
        //    LBO_characterSkills.Visibility = Visibility.Hidden;
        //}

        //private void BTN_Female_Click(object sender, RoutedEventArgs e)
        //{
        //    gender.Clear();
        //    for (int outSide = 0; outSide < dData.Count; outSide++)
        //    {
        //        if (dData[outSide].dGender == "Female")
        //        {
        //            gender.Add(dData[outSide]);
        //        }
        //    }
        //    LBO_PlayingCharacter.ItemsSource = gender;
        //    LBO_raceSkills.Visibility = Visibility.Hidden;
        //    LBO_characterSkills.Visibility = Visibility.Hidden;
        //}

        //private void BTN_allCharacter_Click(object sender, RoutedEventArgs e)
        //{
        //    LBO_PlayingCharacter.ItemsSource = dData;
        //    LBO_raceSkills.Visibility = Visibility.Hidden;
        //    LBO_characterSkills.Visibility = Visibility.Hidden;
        //}

        private void LBO_PlayingCharacter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Charactersskills> karakteridk = new List<Charactersskills>();
            List<Racesskills> fajiidk = new List<Racesskills>();
            List<Skills> karakterskillek = new List<Skills>();
            List<Skills> fajskillek = new List<Skills>();

            LBO_raceSkills.Visibility = Visibility.Visible;
            LBO_characterSkills.Visibility = Visibility.Visible;

            if (LBO_PlayingCharacter.SelectedItem != null)
            {
                TBX_Name.Text = ((displayedData)LBO_PlayingCharacter.SelectedItem).dName;
                TBX_Race.Text = ((displayedData)LBO_PlayingCharacter.SelectedItem).dRace;
                TBX_Gender.Text = ((displayedData)LBO_PlayingCharacter.SelectedItem).dGender;

                foreach (var item in races)
                {
                    if (((displayedData)LBO_PlayingCharacter.SelectedItem).drId == item.Id)
                    {
                        TBX_Desc.Text = item.Description;
                    }
                }

                for (int idFilter = 0; idFilter < characters.Count; idFilter++)
                {
                    if (((displayedData)LBO_PlayingCharacter.SelectedItem).dcId == characters[idFilter].Id)
                    {
                        TBO_Vitality.Text = characters[idFilter].Vitality.ToString();               //  Ugyan ez a többire. Nincs értelme darabolni
                        PBR_Vitality.Value = Convert.ToDouble(characters[idFilter].Vitality);

                        TBO_Strength.Text = characters[idFilter].Strength.ToString();
                        PBR_Strength.Value = Convert.ToDouble(characters[idFilter].Strength);
                        TBO_Endurance.Text = characters[idFilter].Endurance.ToString();
                        PBR_Endurance.Value = Convert.ToDouble(characters[idFilter].Endurance);
                        TBO_Toughtness.Text = characters[idFilter].Toughtness.ToString();
                        PBR_Toughtness.Value = Convert.ToDouble(characters[idFilter].Toughtness);


                        TBO_Dexterity.Text = characters[idFilter].Dexterity.ToString();
                        PBR_Dexterity.Value = Convert.ToDouble(characters[idFilter].Dexterity);

                        TBO_Agility.Text = characters[idFilter].Agility.ToString();
                        PBR_Agility.Value = Convert.ToDouble(characters[idFilter].Agility);
                        TBO_Perception.Text = characters[idFilter].Perception.ToString();
                        PBR_Perception.Value = Convert.ToDouble(characters[idFilter].Perception);
                        TBO_Quickness.Text = characters[idFilter].Quickness.ToString();
                        PBR_Quickness.Value = Convert.ToDouble(characters[idFilter].Quickness);


                        TBO_Intuition.Text = characters[idFilter].Intuition.ToString();
                        PBR_Intuition.Value = Convert.ToDouble(characters[idFilter].Intuition);

                        TBO_Intelligence.Text = characters[idFilter].Intelligence.ToString();
                        PBR_Intelligence.Value = Convert.ToDouble(characters[idFilter].Intelligence);
                        TBO_Wisdom.Text = characters[idFilter].Wisdom.ToString();
                        PBR_Wisdom.Value = Convert.ToDouble(characters[idFilter].Wisdom);
                        TBO_Resourcefull.Text = characters[idFilter].Resourcefull.ToString();
                        PBR_Resourcefull.Value = Convert.ToDouble(characters[idFilter].Resourcefull);

                        TBO_Charisma.Text = characters[idFilter].Charisma.ToString();
                        PBR_Charisma.Value = Convert.ToDouble(characters[idFilter].Charisma);
                        TBO_Appearance.Text = characters[idFilter].Appearance.ToString();
                        PBR_Appearance.Value = Convert.ToDouble(characters[idFilter].Appearance);
                        TBO_Influence.Text = characters[idFilter].Influence.ToString();
                        PBR_Influence.Value = Convert.ToDouble(characters[idFilter].Influence);
                        TBO_Luck.Text = characters[idFilter].Luck.ToString();
                        PBR_Luck.Value = Convert.ToDouble(characters[idFilter].Luck);
                    }
                }

                for (int charinchar = 0; charinchar < charactersskills.Count; charinchar++)
                {
                    if (((displayedData)LBO_PlayingCharacter.SelectedItem).dcId == charactersskills[charinchar].CharacterId)
                    {
                        karakteridk.Add(charactersskills[charinchar]);
                    }
                }
                for (int charincharskill = 0; charincharskill < skills.Count; charincharskill++)
                {
                    for (int papucs = 0; papucs < karakteridk.Count; papucs++)
                    {
                        if (skills[charincharskill].Id == karakteridk[papucs].SkillId)
                        {
                            karakterskillek.Add(skills[charincharskill]);
                        }
                    }
                }
            }
            //****** raceskills
            if (LBO_PlayingCharacter.SelectedItem != null)
            {
                for (int charinrace = 0; charinrace < racessklikks.Count; charinrace++)
                {
                    if (((displayedData)LBO_PlayingCharacter.SelectedItem).drId == racessklikks[charinrace].RaceId)
                    {
                        fajiidk.Add(racessklikks[charinrace]);
                    }
                }
            }

            if (LBO_PlayingCharacter.SelectedItem != null)
            {
                for (int charinraceskill = 0; charinraceskill < skills.Count; charinraceskill++)
                {
                    for (int papucs = 0; papucs < fajiidk.Count; papucs++)
                    {
                        if (skills[charinraceskill].Id == fajiidk[papucs].SkillId)
                        {
                            fajskillek.Add(skills[charinraceskill]);
                        }
                    }
                }
            }

            //if (LBO_PlayingCharacter.SelectedItem != null)
            //{
            //    BitmapImage bi = new BitmapImage();

            //    bi.BeginInit();
            //    bi.UriSource = new Uri(@"/images/chIcon/" + ((displayedData)LBO_PlayingCharacter.SelectedItem).drId.ToString() + ".jpg", UriKind.RelativeOrAbsolute);
            //    bi.EndInit();

                
            //}

            LBO_characterSkills.ItemsSource = karakterskillek;

            LBO_raceSkills.ItemsSource = fajskillek;
        }
    }
}
