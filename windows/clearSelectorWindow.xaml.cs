using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Shapes;

using mD_WPF_chSheet_01.userControl;
using mD_WPF_chSheet_01.pages;
using mD_WPF_chSheet_01.windows;

using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Collections.ObjectModel;

using System.Media;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using mD_WPF_chSheet_01.Models.dzeta;

namespace mD_WPF_chSheet_01.windows
{
    /// <summary>
    /// Interaction logic for clearSelectorWindow.xaml
    /// </summary>
    public partial class clearSelectorWindow : Window
    {

        public class advantages
        {
            public int adId { get; set; }
            public string adName { get; set; }
            public string adDesc { get; set; }
            public advantages(int adId, string adName, string adDesc)
            {
                this.adId = adId; this.adName = adName; this.adDesc = adDesc;
            }
        }

        public class disadvantages
        {
            public int disId { get; set; }
            public string disName { get; set; }
            public string disDesc { get; set; }
            public disadvantages(int disId, string disName, string disDesc)
            {
                this.disId = disId; this.disName = disName; this.disDesc = disDesc;
            }
        }

        #region soksoklistamegacontext
        dzetaContext context = new dzetaContext();

        List<Races> races = new List<Races>();
        List<Characters> characters = new List<Characters>();
        List<Charactersskills> charactersskills = new List<Charactersskills>();
        List<Racesskills> racessklikks = new List<Racesskills>();
        List<Skills> skills = new List<Skills>();

        List<Vitalitys> vitalitys = new List<Vitalitys>();
        List<Dexteritys> dexteritys = new List<Dexteritys>();
        List<Intuitions> intuitions = new List<Intuitions>();
        List<Charisms> charisms = new List<Charisms>();

        List<advantages> adv = new List<advantages>();
        List<disadvantages> dis = new List<disadvantages>();

        List<int> abilityQuality = new List<int>() {50,45,40,35};
        #endregion

        public clearSelectorWindow()
        {
            InitializeComponent();

            #region advdisadv
            adv.Add(new advantages(0,"Sharp eye", "sees farther than others"));
            adv.Add(new advantages(1, "Escapist", "Is easily and quickly absorbed in danger"));
            adv.Add(new advantages(2, "Brave", "More resistant to fear"));
            adv.Add(new advantages(3, "Clinging soul", "Higher death resistance. His soul is harder to break away from his body"));
            adv.Add(new advantages(4, "Lucky", "Each resistance increases by one point"));


            dis.Add(new disadvantages(0, "Missing legg", "One legg is missing"));
            dis.Add(new disadvantages(1, "Missinf arm", "One larm is missing"));
            dis.Add(new disadvantages(2, "Blind", "You are blind"));
            dis.Add(new disadvantages(3, "Phobia", "Unreal fear"));
            dis.Add(new disadvantages(4, "Fetish", "Compulsive attraction"));
            #endregion

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

            context.Vitalitys.Load();
            foreach (var item in context.Vitalitys)
            {
                vitalitys.Add(item);
            }

            context.Dexteritys.Load();
            foreach (var item in context.Dexteritys)
            {
                dexteritys.Add(item);
            }

            context.Intuitions.Load();
            foreach (var item in context.Intuitions)
            {
                intuitions.Add(item);
            }

            context.Charisms.Load();
            foreach (var item in context.Charisms)
            {
                charisms.Add(item);
            }

            LBO_rRace.ItemsSource = context.Races.Local.ToObservableCollection();
            LBO_rRace.SelectedItem = null;

            LBO_advantages.ItemsSource = adv;
            LBO_disadvantages.ItemsSource = dis;
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

                #region vitality
                int myStrMin = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId-1)].StrengthMin;
                int myStrMax = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId-1)].StrengthMax;
                TBO_myStrengthMin.Text = myStrMin.ToString();
                TBO_myStrengthMax.Text = myStrMax.ToString();

                int myEndMin = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId-1)].EnduranceMin;
                int myEndMax = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId-1)].EnduranceMax;
                TBO_myEnduranceMin.Text = myEndMin.ToString();
                TBO_myEnduranceMax.Text = myEndMax.ToString();

                int myTghMin = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId-1)].ToughtnessMin;
                int myTghMax = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId-1)].ToughtnessMax;
                TBO_myToughtnessMin.Text = myTghMin.ToString();
                TBO_myToughtnessMax.Text = myTghMax.ToString();

                TBO_myVitality.Text = (myStrMin + myEndMin + myTghMin).ToString();
                PBR_myVitality.Value = Convert.ToInt32(myStrMin + myStrMin + myStrMin);
                PBR_myStrength.Value = Convert.ToInt32(myStrMax);
                PBR_myEndurance.Value = Convert.ToInt32(myEndMax);
                PBR_myToughtness.Value = Convert.ToInt32(myTghMax);
                #endregion

                #region dexterity
                int myAgiMin = dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].AgilityMin;
                int myAgiMax = dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].AgilityMax;
                TBO_myAgilityMin.Text = myAgiMin.ToString();
                TBO_myAgilityMax.Text = myAgiMax.ToString();

                int myPerMin = dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].PerceptionMin;
                int myPerMax = dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].PerceptionMax;
                TBO_myPerceptionMin.Text = myPerMin.ToString();
                TBO_myPerceptionMax.Text = myPerMax.ToString();

                int myQuiMin = dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].QuicknessMin;
                int myQuiMax = dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].QuicknessMax;
                TBO_myQuicknessMin.Text = myQuiMin.ToString();
                TBO_myQuicknessMax.Text = myQuiMax.ToString();

                TBO_myDexterity.Text = (myAgiMin + myPerMin + myQuiMin).ToString();
                PBR_myDexterity.Value = Convert.ToInt32(myAgiMin + myPerMin + myQuiMin);
                PBR_myAgility.Value = Convert.ToInt32(myPerMax);
                PBR_myPerception.Value = Convert.ToInt32(myPerMax);
                PBR_myQuickness.Value = Convert.ToInt32(myQuiMax);
                #endregion

                #region intuition
                int myIntMin = intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].IntelligenceMin;
                int myIntMax = intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].IntelligenceMax;
                TBO_myIntelligenceMin.Text = myIntMin.ToString();
                TBO_myIntelligenceMax.Text = myIntMax.ToString();

                int myWisMin = intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].WisdomMin;
                int myWisMax = intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].WisdomMax;
                TBO_myWisdomMin.Text = myWisMin.ToString();
                TBO_myWisdomMax.Text = myWisMax.ToString();

                int myResMin = intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].ResourcefullMin;
                int myResMax = intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].ResourcefullMax;
                TBO_myResourcefullMin.Text = myResMin.ToString();
                TBO_myResourcefullMax.Text = myResMax.ToString();

                PBR_myIntuition.ToolTip = (myIntMin + myWisMin + myResMin).ToString();
                TBO_myIntuition.Text = (myIntMin + myWisMin + myResMin).ToString();
                PBR_myIntuition.Value = Convert.ToInt32(myIntMin + myWisMin + myResMin);
                PBR_myIntelligence.Value = Convert.ToInt32(myIntMax);
                PBR_myWisdom.Value = Convert.ToInt32(myWisMax);
                PBR_myResourcefull.Value = Convert.ToInt32(myResMax);
                #endregion

                #region charisma
                int myAppMin = charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].AppearanceMin;
                int myAppMax = charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].AppearanceMax;
                TBO_myAppearanceMin.Text = myAppMin.ToString();
                TBO_myAppearanceMax.Text = myAppMax.ToString();

                int myInfMin = charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].InfluenceMin;
                int myInfMax = charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].InfluenceMax;
                TBO_myInfluenceMin.Text = myInfMin.ToString();
                TBO_myInfluenceMax.Text = myInfMax.ToString();

                int myLuckMin = charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].LuckMin;
                int myLuckax = charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].LuckMax;
                TBO_myLuckMin.Text = myLuckMin.ToString();
                TBO_myLuckMax.Text = myLuckax.ToString();

                PBR_myCharism.ToolTip = (myAppMin + myInfMin + myLuckMin).ToString();
                TBO_myCharism.Text = (myAppMin + myInfMin + myLuckMin).ToString();
                PBR_myCharism.Value = Convert.ToInt32(myAppMin + myInfMin + myLuckMin);
                PBR_myAppearance.Value = Convert.ToInt32(myAppMax);
                PBR_myInfluence.Value = Convert.ToInt32(myInfMax);
                PBR_myLuck.Value = Convert.ToInt32(myLuckax);
                #endregion

                #region basevalues
                PBR_baseHealth.Value = Convert.ToInt32(myStrMin + myStrMin + myStrMin);
                PBR_baseStamina.Value = Convert.ToInt32(myAgiMin + myPerMin + myQuiMin);
                PBR_baseMana.Value = Convert.ToInt32(myIntMin + myWisMin + myResMin);
                PBR_baseImpact.Value = Convert.ToInt32(myAppMin + myInfMin + myLuckMin);
                #endregion


                //Image simpleImage = new Image();
                //simpleImage.Width = 100; simpleImage.Height = 100; simpleImage.Margin = new Thickness(5);

                BitmapImage bi = new BitmapImage();

                bi.BeginInit();
                //bi.UriSource = new Uri(@"/images/chIcon/13.jpg", UriKind.RelativeOrAbsolute);
                bi.UriSource = new Uri(@"/images/chIcon/" + ((Races)LBO_rRace.SelectedItem).Pictures.ToString() + ".jpg",UriKind.RelativeOrAbsolute);
                bi.EndInit();

                //simpleImage.Source = bi;

                IMG_Race.Source = bi;


            }
            else
            {
                TBO_raceModifier.Text = "Faji sajátosságok";
                TBO_placeOfLive.Text = "Faj történelme és élőhelye";
            }
        }

        private void BTN_vitalityQuality_Click(object sender, RoutedEventArgs e)
        {
            if (LBO_rRace.SelectedItem != null && abilityQuality.Count > 0)
            {
                TBO_strengthQuality.Text = Convert.ToString(vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].StrengthMin);
                TBO_endurenceQuality.Text = Convert.ToString(vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].EnduranceMin);
                TBO_toughtnessQuality.Text = Convert.ToString(vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].ToughtnessMin);

                int vq = (vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].StrengthMin +
                           vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].EnduranceMin +
                           vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].ToughtnessMin);
                TBO_vitalityQuality.Text = (abilityQuality[0] - vq).ToString();
                abilityQuality.Remove(abilityQuality[0]);
                //BTN_qualityOne.Visibility = Visibility.Hidden;
                BTN_vitalityQuality.IsEnabled = false;
            }
            //if (abilityQuality.Count > 0)
            //{
            //    int? vq = (vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].StrengthMin +
            //               vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].EnduranceMin +
            //               vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].ToughtnessMin);
            //    TBO_vitalityQuality.Text = (abilityQuality[0]-vq).ToString();
            //    abilityQuality.Remove(abilityQuality[0]);
            //}
        }

        private void BTN_dexterityQuality_Click(object sender, RoutedEventArgs e)
        {
            if (LBO_rRace.SelectedItem != null && abilityQuality.Count > 0)
            {
                TBO_agilityQuality.Text = Convert.ToString(dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].AgilityMin);
                TBO_perceptionQuality.Text = Convert.ToString(dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].PerceptionMin);
                TBO_quicknessQuality.Text = Convert.ToString(dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].QuicknessMin);

                int dq = (dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].AgilityMin +
                           dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].PerceptionMin +
                           dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].QuicknessMin);
                TBO_dexterityQuality.Text = (abilityQuality[0] - dq).ToString();
                abilityQuality.Remove(abilityQuality[0]);
                BTN_dexterityQuality.IsEnabled = false;
            }
        }

        private void BTN_intuitionQuality_Click(object sender, RoutedEventArgs e)
        {
            if (LBO_rRace.SelectedItem != null && abilityQuality.Count > 0)
            {
                TBO_intelligenceQuality.Text = Convert.ToString(intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].IntelligenceMin);
                TBO_wisdomQuality.Text = Convert.ToString(intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].WisdomMin);
                TBO_resourcefullQuality.Text = Convert.ToString(intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].WisdomMin);

                int iq = (intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].IntelligenceMin +
                           intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].WisdomMin +
                           intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].WisdomMin);
                TBO_intuitionQuality.Text = (abilityQuality[0] - iq).ToString();
                abilityQuality.Remove(abilityQuality[0]);
                BTN_intuitionQuality.IsEnabled = false;
            }

        }

        private void BTN_charismQuality_Click(object sender, RoutedEventArgs e)
        {
            if (LBO_rRace.SelectedItem != null && abilityQuality.Count > 0)
            {
                TBO_appearanceQuality.Text = Convert.ToString(charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].AppearanceMin);
                TBO_influenceQuality.Text = Convert.ToString(charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].InfluenceMin);
                TBO_luckQuality.Text = Convert.ToString(charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].LuckMin);

                int cq = (charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].AppearanceMin +
                           charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].InfluenceMin +
                           charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].LuckMin);
                TBO_charismaQuality.Text = (abilityQuality[0] - cq).ToString();
                abilityQuality.Remove(abilityQuality[0]);
                BTN_charismaQuality.IsEnabled = false;
            }

        }

        private void BTN_qualityReset_Click(object sender, RoutedEventArgs e)
        {
            abilityQuality.Add(50); abilityQuality.Add(45); abilityQuality.Add(40); abilityQuality.Add(35);
            TBO_vitalityQuality.Text = ""; TBO_dexterityQuality.Text = ""; 
            TBO_intuitionQuality.Text = ""; TBO_charismaQuality.Text = "";

            TBO_strengthQuality.Text = ""; TBO_endurenceQuality.Text = ""; TBO_toughtnessQuality.Text = "";
            TBO_agilityQuality.Text = ""; TBO_perceptionQuality.Text = ""; TBO_quicknessQuality.Text = "";
            TBO_intelligenceQuality.Text = ""; TBO_wisdomQuality.Text = ""; TBO_resourcefullQuality.Text = "";
            TBO_appearanceQuality.Text = ""; TBO_influenceQuality.Text = ""; TBO_luckQuality.Text = "";

            //BTN_qualityOne.Visibility = Visibility.Visible;
            BTN_vitalityQuality.IsEnabled = true; BTN_dexterityQuality.IsEnabled = true;
            BTN_intuitionQuality.IsEnabled = true; BTN_charismaQuality.IsEnabled = true;
        }

        private void BTN_strengthQualityP_Click(object sender, RoutedEventArgs e)
        {
            int strMin = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].StrengthMin;
            int strAct = Convert.ToInt32(TBO_strengthQuality.Text);
            int strMax = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].StrengthMax;
            int pool = Convert.ToInt32(TBO_vitalityQuality.Text);
            if (LBO_rRace.SelectedItem != null)
            {
                if (strAct >= strMax - 1)
                {
                    BTN_strengthQualityP.IsEnabled = false;
                }
                if (strMin <= strAct)
                {
                    strAct++;
                    pool--;
                    TBO_vitalityQuality.Text = pool.ToString();
                    TBO_strengthQuality.Text = strAct.ToString();

                }
            }
        }

        private void BTN_strengthQualityM_Click(object sender, RoutedEventArgs e)
        {
            int strMin = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].StrengthMin;
            int strAct = Convert.ToInt32(TBO_strengthQuality.Text);
            int strMax = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].StrengthMax;
            int pool = Convert.ToInt32(TBO_vitalityQuality.Text);
            if (LBO_rRace.SelectedItem != null)
            {
                if (strMin + 1 >= strAct)
                {
                    BTN_strengthQualityM.IsEnabled = false;
                }
                if (strMin <= strAct)
                {
                    strAct--;
                    pool++;
                    TBO_vitalityQuality.Text = pool.ToString();
                    TBO_strengthQuality.Text = strAct.ToString();
                }
            }
        }

        private void BTN_endurenceQualityP_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_toughtnessQualityP_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_toughtnessQualityM_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
