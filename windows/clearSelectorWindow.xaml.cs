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
using mD_WPF_chSheet_01.objects.characterObject;

namespace mD_WPF_chSheet_01.windows
{
    /// <summary>
    /// Interaction logic for clearSelectorWindow.xaml
    /// </summary>
    public partial class clearSelectorWindow : Window
    {

        public class advantages
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Desc { get; set; }
            public advantages(int Id, string Name, string Desc)
            {
                this.Id = Id; this.Name = Name; this.Desc = Desc;
            }
        }

        public class displayedSkill
        {
            public int Id { get; set; }
            public string SkillName { get; set; }
            public int SkillCost { get; set; }
            public string SkillClass { get; set; }

            public BitmapImage SkillImage { get; set; }
        }

        #region soksoklistamegacontext
        dzetaContext context = new dzetaContext();

        ObservableCollection<Races> races = new ObservableCollection<Races>();
        ObservableCollection<Characters> characters = new ObservableCollection<Characters>();
        ObservableCollection<Charactersskills> charactersskills = new ObservableCollection<Charactersskills>();
        ObservableCollection<Racesskills> racessklikks = new ObservableCollection<Racesskills>();
        ObservableCollection<Skills> skills = new ObservableCollection<Skills>();

        ObservableCollection<Vitalitys> vitalitys = new ObservableCollection<Vitalitys>();
        ObservableCollection<Dexteritys> dexteritys = new ObservableCollection<Dexteritys>();
        ObservableCollection<Intuitions> intuitions = new ObservableCollection<Intuitions>();
        ObservableCollection<Charisms> charisms = new ObservableCollection<Charisms>();

        ObservableCollection<advantages> adv = new ObservableCollection<advantages>();
        ObservableCollection<advantages> dis = new ObservableCollection<advantages>();
        ObservableCollection<advantages> selectedAda = new ObservableCollection<advantages>();

        ObservableCollection<displayedSkill> dispSkill = new ObservableCollection<displayedSkill>();

        ObservableCollection<displayedSkill> ismertskill = new ObservableCollection<displayedSkill>();
        ObservableCollection<displayedSkill> nemismertskill = new ObservableCollection<displayedSkill>();

        ObservableCollection<int> abilityQuality = new ObservableCollection<int>() {50,45,40,35};

        ObservableCollection<characterAttribution> characterIstic = new ObservableCollection<characterAttribution>();
        #endregion

        public clearSelectorWindow()
        {
            InitializeComponent();

            #region soksokcontext
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
            #endregion

            for (int i = 0; i < skills.Count; i++)
            {

                BitmapImage bi = new BitmapImage();

                bi.BeginInit();
                bi.UriSource = new Uri(@"/images/skillClassIcon/" + skills[i].SkillClass + ".jpg", UriKind.RelativeOrAbsolute);
                dispSkill.Add(new displayedSkill()
                {
                    Id = skills[i].Id,
                    SkillName = skills[i].SkillName,
                    SkillCost = skills[i].SkillCost,
                    SkillClass = skills[i].SkillClass,
                    SkillImage = bi
                });
                bi.EndInit();
            }
            
            LBO_rRace.ItemsSource = context.Races.Local.ToObservableCollection();
            LBO_rRace.SelectedItem = null;

            LBO_adandd.ItemsSource = selectedAda;

            characterIstic.Add(new characterAttribution());

            BTN_strengthQualityM.IsEnabled = false; BTN_endurenceQualityM.IsEnabled = false; BTN_toughtnessQualityM.IsEnabled = false;
            BTN_agilityQualityM.IsEnabled = false; BTN_perceptionQualityM.IsEnabled = false; BTN_quicknessQualityM.IsEnabled = false;
            BTN_intelligenceQualityM.IsEnabled = false; BTN_wisdomQualityM.IsEnabled = false; BTN_resourcefullQualityM.IsEnabled = false;
            BTN_appearanceQualityM.IsEnabled = false; BTN_influenceQualityM.IsEnabled = false; BTN_luckQualityM.IsEnabled = false;

            BTN_strengthQualityP.IsEnabled = false; BTN_endurenceQualityP.IsEnabled = false; BTN_toughtnessQualityP.IsEnabled = false;
            BTN_agilityQualityP.IsEnabled = false; BTN_perceptionQualityP.IsEnabled = false; BTN_quicknessQualityP.IsEnabled = false;
            BTN_intelligenceQualityP.IsEnabled = false; BTN_wisdomQualityP.IsEnabled = false; BTN_resourcefullQualityP.IsEnabled = false;
            BTN_appearanceQualityP.IsEnabled = false; BTN_influenceQualityP.IsEnabled = false; BTN_luckQualityP.IsEnabled = false;

            advdisadv();
            toolTipp();
        }

        private void advdisadv()
        {
            adv.Add(new advantages(0, "Sharp eye", "Sees farther than others"));
            adv.Add(new advantages(1, "Escapist", "Is easily and quickly absorbed in danger"));
            adv.Add(new advantages(2, "Brave", "More resistant to fear"));
            adv.Add(new advantages(3, "Clinging soul", "Higher death resistance. His soul is harder to break away from his body"));
            adv.Add(new advantages(4, "Lucky", "Each resistance increases by one point"));


            dis.Add(new advantages(0, "Missing leg", "One leg is missing"));
            dis.Add(new advantages(1, "Missing arm", "One arm is missing"));
            dis.Add(new advantages(2, "Missing head", "One head is missing"));
            dis.Add(new advantages(3, "Blind", "You are blind"));
            dis.Add(new advantages(4, "Phobia", "Unreal fear"));
            dis.Add(new advantages(5, "Fetish", "Compulsive attraction"));

            LBO_advantages.DataContext = adv;
            foreach (var item in adv)
            {
                LBO_advantages.Items.Add(item);
            }

            LBO_disadvantages.DataContext = dis;
            foreach (var item in dis)
            {
                LBO_disadvantages.Items.Add(item);
            }
        }

        

        private void skillfilterone()
        {
            if (LBO_rRace.SelectedItem != null)
            {
                LBO_knownSkill.Items.Clear();
                LBO_optionalSkill.Items.Clear();
                ismertskill.Clear();
                nemismertskill.Clear();

                for (int allskill = 0; allskill < dispSkill.Count; allskill++)
                {
                    nemismertskill.Add(dispSkill[allskill]);
                }

                for (int skillek = 0; skillek < skills.Count; skillek++)
                {
                    for (int fajiskillek = 0; fajiskillek < racessklikks.Count; fajiskillek++)
                    {
                        if (((Races)LBO_rRace.SelectedItem).Id == racessklikks[fajiskillek].RaceId)
                        {
                            if (racessklikks[fajiskillek].SkillId == skills[skillek].Id)
                            {
                                ismertskill.Add(dispSkill[fajiskillek]);
                                nemismertskill.Remove(dispSkill[fajiskillek]);
                            }
                        }
                    }
                }


                for (int i = 0; i < ismertskill.Count; i++)
                {
                    LBO_knownSkill.Items.Add(ismertskill[i]);
                }
                for (int i = 0; i < nemismertskill.Count; i++)
                {
                    LBO_optionalSkill.Items.Add(nemismertskill[i]);
                }
                //LBO_knownSkill.ItemsSource = ismertskill;
                //LBO_optionalSkill.ItemsSource = nemismertskill;
            }
        }

        private void toolTipp()
        {
            LBL_Vitality.ToolTip = vitalitys[0].Description;
            LBL_Dexterity.ToolTip = dexteritys[0].Description;
            LBL_Intuition.ToolTip = intuitions[0].Description;
            LBL_Charisma.ToolTip = charisms[0].Description;

            LBL_Strength.ToolTip = vitalitys[0].StrengthDescription;
            LBL_Endurence.ToolTip = vitalitys[0].EnduranceDescription;
            LBL_Toughtness.ToolTip = vitalitys[0].ToughtnessDescription;

            LBL_Agility.ToolTip = dexteritys[0].AgilityDescription;
            LBL_Perception.ToolTip = dexteritys[0].PerceptionDescription;
            LBL_Quickness.ToolTip = dexteritys[0].QuicknessDescription;

            LBL_Intelligence.ToolTip = intuitions[0].IntelligenceDescription;
            LBL_Wisdom.ToolTip = intuitions[0].WisdomDescription;
            LBL_Resourcefull.ToolTip = intuitions[0].ResourcefullDescription;

            LBL_Appearance.ToolTip = charisms[0].AppearanceDescription;
            LBL_Influence.ToolTip = charisms[0].InfluenceDescription;
            LBL_Luck.ToolTip = charisms[0].LuckDescription;

            
            SP_baseHealth.ToolTip = "Vitality harminc feletti része";
            SP_baseStamina.ToolTip = "Dexterity harminc feletti része";
            SP_baseMana.ToolTip = "Intuition harminc feletti része";
            SP_baseImpact.ToolTip = "Charisma harminc feletti része";
            SP_basePotency.ToolTip = "Tulajdonság egy és Tulajdonság kettő bónuszok, plussz a felvett képzettségek fokozata, plusz a felvett képzettségek minőségfokozata után " +
                "adott minőségben minden fokozat után plusz egy, minőségnövekedésenként újraszámolva";
            SP_baseRegeneration.ToolTip = "Endurence I + Endurence II + Tougthness I + Tougthness II Naponta";
            SP_baseKnowledge.ToolTip = "Intelligencia I + Intelligencia II + Wisdom I + Wisdom II";
            SP_basePiety.ToolTip = "(Wisdom I + Wisdom II)*3";

            SP_baseSlashingAttack.ToolTip = "Agility I + Strength II";
            SP_baseCrushingAttack.ToolTip = "Strength I + Endurence II";
            SP_basePierceAttack.ToolTip = "Agility I + Quickness II";
            SP_baseProjectileAttack.ToolTip = "Agility I + Perception II";
            SP_baseFireAttack.ToolTip = "Intelligence I + Wisdom I + Skill";
            SP_baseIceAttack.ToolTip = "Intelligence I + Wisdom I + Skill";
            SP_baseEarthAttack.ToolTip = "Intelligence I + Wisdom I + Skill";
            SP_baseAirAttack.ToolTip = "Intelligence I + Wisdom I + Skill";
            SP_baseMagicAttack.ToolTip = "Intelligence I + Wisdom I + Skill";
            SP_baseDivineAttack.ToolTip = "Wisdom I + Resourcefull II + Skill";
            SP_baseRevengeAttavk.ToolTip = "Perception I + Resourcefull I + Quickness II";
            SP_baseThrowingAttack.ToolTip = "Agility II + Perception II + Resourcefull II + Luck II";
            SP_baseDarkAttack.ToolTip = "Intelligence I + Resourcefull II";
            SP_baseLightAttack.ToolTip = "Wisdom I + Resourcefull II";
            SP_baseMindAttack.ToolTip = "Appearance I + Influence II";
            SP_baseControllAttack.ToolTip = "Appearance II + Influence II + Wisdom II + Intelligence II";

            SP_baseDeathProt.ToolTip = "Wisdom II + Luck I + Luck II";
            SP_basePhysicalProt.ToolTip = "Endurence I + Toughtness II";
            SP_baseProjectileProt.ToolTip = "Perception I + Quickness II";
            SP_basePierceProt.ToolTip = "Quickness I + Agility II";
            SP_baseSlashingProt.ToolTip = "Agility I + Toughtness II";
            SP_baseCrushingProt.ToolTip = "Toughtness I + Toughtness II";
            SP_baseFracturePtot.ToolTip = "Endurence I + Toughtness II";
            SP_baseBleedingProt.ToolTip = "Endurence I + Endurence II";
            SP_baseDiseaseProt.ToolTip = "Endurence I + Endurence II";
            SP_baseInfectionProt.ToolTip = "Endurence I + Endurence II + Luck II";
            SP_basePoisonProt.ToolTip = "Endurence I + Endurence II";
            SP_baseAsphyxiaProt.ToolTip = "Endurence I + Toughtness I";
            SP_baseEnergyProt.ToolTip = "Intelligence I + Intelligence II";
            SP_baseMagicProt.ToolTip = "Intelligence I + Wisdom I";
            SP_baseBurningProt.ToolTip = "Perception I + Quickness II";
            SP_baseEarthProt.ToolTip = "Endurence I + Wisdom I";
            SP_baseFrostbiteProt.ToolTip = "Toughtness I + Wisdom I";
            SP_baseAirProt.ToolTip = "Endurence I + Endurence II";
            SP_baseDarkProt.ToolTip = "Intelligence I + Resourcefull II";
            SP_baseLightProt.ToolTip = "Wisdom I + Resourcefull II";
        }

        private void characteristicPanel()
        {
            
            PRB_basePotency.Value = characterIstic[0].strengthA + characterIstic[0].strengthP + characterIstic[0].endurenceA + characterIstic[0].endurenceP +
            characterIstic[0].toughnessA + characterIstic[0].toughnessP + characterIstic[0].agilityA + characterIstic[0].agilityP + characterIstic[0].perceptionA +
            characterIstic[0].perceptionP + characterIstic[0].quicknessA + characterIstic[0].quicknessP + characterIstic[0].intelligenceA + characterIstic[0].intelligenceP +
            characterIstic[0].wisdomA + characterIstic[0].wisdomP + characterIstic[0].resourcefullA + characterIstic[0].resourcefullP + characterIstic[0].appearanceA +
            characterIstic[0].appearanceP + characterIstic[0].influenceA + characterIstic[0].influenceP + characterIstic[0].luckA + characterIstic[0].luckP;

                
            PRB_baseRegeneration.Value = characterIstic[0].endurenceA + characterIstic[0].endurenceP + characterIstic[0].toughnessA + characterIstic[0].toughnessP;
                
            PRB_baseKnowledge.Value = characterIstic[0].intelligenceA + characterIstic[0].intelligenceP + characterIstic[0].wisdomA + characterIstic[0].wisdomP;
                
            PRB_basePiety.Value = (characterIstic[0].wisdomA + characterIstic[0].wisdomP)*3;

            PRB_baseSlashingAttack.Value = characterIstic[0].agilityA + characterIstic[0].strengthP;
            PRB_baseCrushingAttack.Value = characterIstic[0].strengthA + characterIstic[0].endurenceP;
            PRB_basePierceAttack.Value = characterIstic[0].agilityA + characterIstic[0].quicknessP;
            PRB_baseProjectileAttack.Value = characterIstic[0].agilityA + characterIstic[0].perceptionP;
            PRB_baseFireAttack.Value = characterIstic[0].intelligenceA + characterIstic[0].wisdomA;
            PRB_baseIceAttack.Value = characterIstic[0].intelligenceA + characterIstic[0].wisdomA;
            PRB_baseEarthAttack.Value = characterIstic[0].intelligenceA + characterIstic[0].wisdomA;
            PRB_baseAirAttack.Value = characterIstic[0].intelligenceA + characterIstic[0].wisdomA;
            PRB_baseMagicAttack.Value = characterIstic[0].intelligenceA + characterIstic[0].wisdomA;
            PRB_baseDivineAttack.Value = characterIstic[0].wisdomA + characterIstic[0].resourcefullP;
            PRB_baseRevengeAttavk.Value = characterIstic[0].perceptionA + characterIstic[0].resourcefullP + characterIstic[0].quicknessP;
            PRB_baseThrowingAttack.Value = characterIstic[0].agilityP + characterIstic[0].perceptionP + characterIstic[0].resourcefullP + characterIstic[0].luckP;
            PRB_baseDarkAttack.Value = characterIstic[0].intelligenceA + characterIstic[0].resourcefullP;
            PRB_baseLightAttack.Value = characterIstic[0].wisdomA + characterIstic[0].resourcefullP;
            PRB_baseMindAttack.Value = characterIstic[0].appearanceA + characterIstic[0].influenceP;
            PRB_baseControllAttack.Value = characterIstic[0].appearanceP + characterIstic[0].influenceP + characterIstic[0].wisdomP + characterIstic[0].intelligenceP;

            PRB_baseDeathProt.Value = characterIstic[0].wisdomP + characterIstic[0].luckA + characterIstic[0].luckP;
            PRB_basePhysicalProt.Value = characterIstic[0].endurenceA + characterIstic[0].toughnessP;
            PRB_baseProjectileProt.Value = characterIstic[0].perceptionA + characterIstic[0].quicknessP;
            PRB_basePierceProt.Value = characterIstic[0].quicknessA + characterIstic[0].agilityP;
            PRB_baseSlashingProt.Value = characterIstic[0].agilityA + characterIstic[0].toughnessP;
            PRB_baseCrushingProt.Value = characterIstic[0].toughnessA + characterIstic[0].toughnessP;
            PRB_baseFracturePtot.Value = characterIstic[0].endurenceA + characterIstic[0].toughnessP;
            PRB_baseBleedingProt.Value = characterIstic[0].endurenceA + characterIstic[0].endurenceP;
            PRB_baseDiseaseProt.Value = characterIstic[0].endurenceA + characterIstic[0].endurenceP;
            PRB_baseInfectionProt.Value = characterIstic[0].endurenceA + characterIstic[0].endurenceP + characterIstic[0].luckP;
            PRB_basePoisonProt.Value = characterIstic[0].endurenceA + characterIstic[0].endurenceP;
            PRB_baseAsphyxiaProt.Value = characterIstic[0].endurenceA + characterIstic[0].toughnessA;
            PRB_baseEnergyProt.Value = characterIstic[0].intelligenceA + characterIstic[0].intelligenceP;
            PRB_baseMagicProt.Value = characterIstic[0].intelligenceA + characterIstic[0].wisdomP;
            PRB_baseBurningProt.Value = characterIstic[0].perceptionA + characterIstic[0].quicknessP;
            PRB_baseEarthProt.Value = characterIstic[0].endurenceA + characterIstic[0].wisdomA;
            PRB_baseFrostbiteProt.Value = characterIstic[0].toughnessA + characterIstic[0].wisdomA;
            PRB_baseAirProt.Value = characterIstic[0].endurenceA + characterIstic[0].endurenceP;
            PRB_baseDarkProt.Value = characterIstic[0].intelligenceA + characterIstic[0].resourcefullP;
            PRB_baseLightProt.Value = characterIstic[0].wisdomA + characterIstic[0].resourcefullP;

            TBO_avaliableSkillpoint.Text = (PRB_basePotency.Value + (characterIstic[0].intelligenceA + characterIstic[0].intelligenceP + characterIstic[0].wisdomA +
                characterIstic[0].wisdomP + characterIstic[0].resourcefullA + characterIstic[0].resourcefullP)*3).ToString();
        }

        private void LBO_rRace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (LBO_rRace.SelectedItem != null)
            {
                TBO_raceModifier.Text = ((Races)LBO_rRace.SelectedItem).Description;
                TBO_raceModifier.Foreground = Brushes.LightGoldenrodYellow;
                

                TBO_placeOfLive.Text = ((Races)LBO_rRace.SelectedItem).History;
                TBO_placeOfLive.Foreground = Brushes.LightGoldenrodYellow;

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
                bi.UriSource = new Uri(@"/images/chIcon/" + ((Races)LBO_rRace.SelectedItem).Id.ToString() + ".jpg",UriKind.RelativeOrAbsolute);
                bi.EndInit();

                //simpleImage.Source = bi;

                IMG_Race.Source = bi;
                IMG_SAPimage.Source = bi;
                IMG_AARPicture.Source = bi;
                IMG_AADicture.Source = bi;
            }
            //else
            //{
            //    TBO_raceModifier.Text = "Faji sajátosságok";
            //    TBO_placeOfLive.Text = "Faj történelme és élőhelye";
            //}
            skillfilterone();
        }

        private void LBO_advantages_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (LBO_advantages.SelectedItem != null)
            {
                //LBO_adandd.BorderBrush = Brushes.White;
                selectedAda.Add(new advantages(adv[LBO_advantages.SelectedIndex].Id, adv[LBO_advantages.SelectedIndex].Name, adv[LBO_advantages.SelectedIndex].Desc));
                adv.Remove(adv[LBO_advantages.SelectedIndex]);
                LBO_advantages.Items.Clear();
                foreach (var item in adv)
                {
                    LBO_advantages.Items.Add(item);
                }
            }

        }

        private void LBO_disadvantages_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (LBO_disadvantages.SelectedItem != null)
            {
                //LBO_adandd.BorderBrush = Brushes.Black;
                selectedAda.Add(new advantages(dis[LBO_disadvantages.SelectedIndex].Id, dis[LBO_disadvantages.SelectedIndex].Name, dis[LBO_disadvantages.SelectedIndex].Desc));
                dis.Remove(dis[LBO_disadvantages.SelectedIndex]);
                LBO_disadvantages.Items.Clear();
                foreach (var item in dis)
                {
                    LBO_disadvantages.Items.Add(item);
                }
            }
        }

        private void BTN_adadd_Click(object sender, RoutedEventArgs e)
        {
            selectedAda.Clear();
            adv.Clear();
            dis.Clear();
            //LBO_adandd.Items.Clear();
            LBO_advantages.Items.Clear();
            LBO_disadvantages.Items.Clear();
            advdisadv();
        }




        private void BTN_vitalityQuality_Click(object sender, RoutedEventArgs e)
        {
            if (LBO_rRace.SelectedItem != null && abilityQuality.Count > 0)
            {
                //TBO_TestBox.Text = "";
                int basehealth = abilityQuality[0] - 30;
                PRB_baseHealth.Value = basehealth;
                //TBO_TestBox.Text = (basehealth).ToString();

                TBO_strengthQuality.Text = Convert.ToString(vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].StrengthMin);
                PBR_strengthQuality.Maximum = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].StrengthMax;

                TBO_endurenceQuality.Text = Convert.ToString(vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].EnduranceMin);
                PBR_endurenceQuality.Maximum = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].EnduranceMax;

                TBO_toughtnessQuality.Text = Convert.ToString(vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].ToughtnessMin);
                PBR_toughtnessQuality.Maximum = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].ToughtnessMax;

                int vq = (vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].StrengthMin +
                           vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].EnduranceMin +
                           vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].ToughtnessMin);
                TBO_vitalityQuality.Text = (abilityQuality[0] - vq).ToString();
                abilityQuality.Remove(abilityQuality[0]);
                //BTN_qualityOne.Visibility = Visibility.Hidden;
                BTN_vitalityQuality.IsEnabled = false;

                PBR_strengthQuality.Value = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].StrengthMin;
                PBR_endurenceQuality.Value = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].EnduranceMin;
                PBR_toughtnessQuality.Value = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].ToughtnessMin;

                BTN_strengthQualityM.IsEnabled = false; BTN_endurenceQualityM.IsEnabled = false; BTN_toughtnessQualityM.IsEnabled = false;

                BTN_strengthQualityP.IsEnabled = true; BTN_endurenceQualityP.IsEnabled = true; BTN_toughtnessQualityP.IsEnabled = true;
            }
        }

        private void BTN_dexterityQuality_Click(object sender, RoutedEventArgs e)
        {
            if (LBO_rRace.SelectedItem != null && abilityQuality.Count > 0)
            {
                //TBO_TestBox.Text = "";
                int baseStamina = abilityQuality[0] - 30;
                PRB_baseStamina.Value = baseStamina;
                //TBO_TestBox.Text = (baseStamina).ToString();

                TBO_agilityQuality.Text = Convert.ToString(dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].AgilityMin);
                PBR_agilityQuality.Maximum = dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].AgilityMax;

                TBO_perceptionQuality.Text = Convert.ToString(dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].PerceptionMin);
                PBR_perceptionQuality.Maximum = dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].PerceptionMax;

                TBO_quicknessQuality.Text = Convert.ToString(dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].QuicknessMin);
                PBR_quicknessQuality.Maximum = dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].QuicknessMax;

                int dq = (dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].AgilityMin +
                           dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].PerceptionMin +
                           dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].QuicknessMin);
                TBO_dexterityQuality.Text = (abilityQuality[0] - dq).ToString();
                abilityQuality.Remove(abilityQuality[0]);
                BTN_dexterityQuality.IsEnabled = false;

                PBR_agilityQuality.Value = dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].AgilityMin;
                PBR_perceptionQuality.Value = dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].PerceptionMin;
                PBR_quicknessQuality.Value = dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].QuicknessMin;

                BTN_agilityQualityM.IsEnabled = false; BTN_perceptionQualityM.IsEnabled = false; BTN_quicknessQualityM.IsEnabled = false;

                BTN_agilityQualityP.IsEnabled = true; BTN_perceptionQualityP.IsEnabled = true; BTN_quicknessQualityP.IsEnabled = true;
            }
        }

        private void BTN_intuitionQuality_Click(object sender, RoutedEventArgs e)
        {
            if (LBO_rRace.SelectedItem != null && abilityQuality.Count > 0)
            {
                //TBO_TestBox.Text = "";
                int basemana = abilityQuality[0] - 30;
                PRB_baseMana.Value = basemana;
                //TBO_TestBox.Text = (basemana).ToString();

                TBO_intelligenceQuality.Text = Convert.ToString(intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].IntelligenceMin);
                PBR_intelligenceQuality.Maximum = intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].IntelligenceMax;

                TBO_wisdomQuality.Text = Convert.ToString(intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].WisdomMin);
                PBR_wisdomQuality.Maximum = intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].WisdomMax;

                TBO_resourcefullQuality.Text = Convert.ToString(intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].WisdomMin);
                PBR_resourcefullQuality.Maximum = intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].WisdomMax;

                int iq = (intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].IntelligenceMin +
                           intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].WisdomMin +
                           intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].WisdomMin);
                TBO_intuitionQuality.Text = (abilityQuality[0] - iq).ToString();
                abilityQuality.Remove(abilityQuality[0]);
                BTN_intuitionQuality.IsEnabled = false;

                PBR_intelligenceQuality.Value = intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].IntelligenceMin;
                PBR_wisdomQuality.Value = intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId- 1)].WisdomMin;
                PBR_resourcefullQuality.Value = intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].ResourcefullMin;

                BTN_intelligenceQualityM.IsEnabled = false; BTN_wisdomQualityM.IsEnabled = false; BTN_resourcefullQualityM.IsEnabled = false;

                BTN_intelligenceQualityP.IsEnabled = true; BTN_wisdomQualityP.IsEnabled = true; BTN_resourcefullQualityP.IsEnabled = true;
            }

        }

        private void BTN_charismQuality_Click(object sender, RoutedEventArgs e)
        {
            if (LBO_rRace.SelectedItem != null && abilityQuality.Count > 0)
            {
                //TBO_TestBox.Text = "";
                int baseimpact = abilityQuality[0] - 30;
                PRB_baseImpact.Value = baseimpact;
                //TBO_TestBox.Text = (baseimpact).ToString();

                TBO_appearanceQuality.Text = Convert.ToString(charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].AppearanceMin);
                PBR_appearanceQuality.Maximum = charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].AppearanceMax;

                TBO_influenceQuality.Text = Convert.ToString(charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].InfluenceMin);
                PBR_influenceQuality.Maximum = charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].InfluenceMax;

                TBO_luckQuality.Text = Convert.ToString(charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].LuckMin);
                PBR_luckQuality.Maximum = charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].LuckMax;

                int cq = (charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].AppearanceMin +
                           charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].InfluenceMin +
                           charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].LuckMin);
                TBO_charismaQuality.Text = (abilityQuality[0] - cq).ToString();
                abilityQuality.Remove(abilityQuality[0]);
                BTN_charismaQuality.IsEnabled = false;

                PBR_appearanceQuality.Value = charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].AppearanceMin;
                PBR_influenceQuality.Value = charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].InfluenceMin;
                PBR_luckQuality.Value = charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].LuckMin;

                BTN_appearanceQualityM.IsEnabled = false; BTN_influenceQualityM.IsEnabled = false; BTN_luckQualityM.IsEnabled = false;

                BTN_appearanceQualityP.IsEnabled = true; BTN_influenceQualityP.IsEnabled = true; BTN_luckQualityP.IsEnabled = true;
            }

        }

        
        
        private void BTN_qualityReset_Click(object sender, RoutedEventArgs e)
        {
            abilityQuality.Clear();
            abilityQuality.Add(50); abilityQuality.Add(45); abilityQuality.Add(40); abilityQuality.Add(35);
            TBO_vitalityQuality.Text = ""; TBO_dexterityQuality.Text = ""; 
            TBO_intuitionQuality.Text = ""; TBO_charismaQuality.Text = "";

            TBO_strengthQuality.Text = ""; TBO_STRI.Text = ""; TBO_STRII.Text = "";
            TBO_endurenceQuality.Text = ""; TBO_ENDI.Text = ""; TBO_ENDII.Text = "";
            TBO_toughtnessQuality.Text = ""; TBO_TGHI.Text = ""; TBO_TGHII.Text = "";
            PBR_strengthQuality.Value = 0;
            //vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].StrengthMin;
            PBR_endurenceQuality.Value = 0;
            //vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].EnduranceMin;
            PBR_toughtnessQuality.Value = 0;
            //vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].ToughtnessMin;

            TBO_agilityQuality.Text = ""; TBO_AGII.Text = ""; TBO_AGIII.Text = "";
            TBO_perceptionQuality.Text = ""; TBO_PERI.Text = ""; TBO_PERII.Text = "";
            TBO_quicknessQuality.Text = ""; TBO_QUII.Text = ""; TBO_QUIII.Text = "";
            PBR_agilityQuality.Value = 0;
            //dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].AgilityMin;
            PBR_perceptionQuality.Value = 0;
            //dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].PerceptionMin;
            PBR_quicknessQuality.Value = 0;
            //dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].QuicknessMin;

            TBO_intelligenceQuality.Text = ""; TBO_INTI.Text = ""; TBO_INTII.Text = "";
            TBO_wisdomQuality.Text = ""; TBO_WISI.Text = ""; TBO_WISII.Text = "";
            TBO_resourcefullQuality.Text = ""; TBO_RESI.Text = ""; TBO_RESII.Text = "";
            PBR_intelligenceQuality.Value = 0;
            //intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].IntelligenceMin;
            PBR_wisdomQuality.Value = 0;
            //intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].WisdomMin;
            PBR_resourcefullQuality.Value = 0;
            //intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].ResourcefullMin;

            TBO_appearanceQuality.Text = ""; TBO_APPI.Text = ""; TBO_APPII.Text = "";
            TBO_influenceQuality.Text = ""; TBO_INFI.Text = ""; TBO_INFII.Text = "";
            TBO_luckQuality.Text = ""; TBO_LuckI.Text = ""; TBO_LuckII.Text = "";
            PBR_appearanceQuality.Value = 0;
            //charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].AppearanceMin;
            PBR_influenceQuality.Value = 0;
            //charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].InfluenceMin;
            PBR_luckQuality.Value = 0;
            //charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].LuckMin;


            //BTN_qualityOne.Visibility = Visibility.Visible;
            BTN_vitalityQuality.IsEnabled = true; BTN_dexterityQuality.IsEnabled = true;
            BTN_intuitionQuality.IsEnabled = true; BTN_charismaQuality.IsEnabled = true;

            BTN_strengthQualityM.IsEnabled = false; BTN_endurenceQualityM.IsEnabled = false; BTN_toughtnessQualityM.IsEnabled = false;
            BTN_agilityQualityM.IsEnabled = false; BTN_perceptionQualityM.IsEnabled = false; BTN_quicknessQualityM.IsEnabled = false;
            BTN_intelligenceQualityM.IsEnabled = false; BTN_wisdomQualityM.IsEnabled = false; BTN_resourcefullQualityM.IsEnabled = false;
            BTN_appearanceQualityM.IsEnabled = false; BTN_influenceQualityM.IsEnabled = false; BTN_luckQualityM.IsEnabled = false;

            BTN_strengthQualityP.IsEnabled = false; BTN_endurenceQualityP.IsEnabled = false; BTN_toughtnessQualityP.IsEnabled = false;
            BTN_agilityQualityP.IsEnabled = false; BTN_perceptionQualityP.IsEnabled = false; BTN_quicknessQualityP.IsEnabled = false;
            BTN_intelligenceQualityP.IsEnabled = false; BTN_wisdomQualityP.IsEnabled = false; BTN_resourcefullQualityP.IsEnabled = false;
            BTN_appearanceQualityP.IsEnabled = false; BTN_influenceQualityP.IsEnabled = false; BTN_luckQualityP.IsEnabled = false;


            #region charastericticreset
            PRB_baseHealth.Value = 0; PRB_baseStamina.Value = 0; PRB_baseMana.Value = 0; PRB_baseImpact.Value = 0;

            PRB_basePotency.Value = 0; PRB_baseRegeneration.Value = 0; PRB_baseKnowledge.Value = 0; PRB_basePiety.Value = 0;

            PRB_baseSlashingAttack.Value = 0;
            PRB_baseCrushingAttack.Value = 0;
            PRB_basePierceAttack.Value = 0;
            PRB_baseProjectileAttack.Value = 0;
            PRB_baseFireAttack.Value = 0;
            PRB_baseIceAttack.Value = 0;
            PRB_baseEarthAttack.Value = 0;
            PRB_baseAirAttack.Value = 0;
            PRB_baseMagicAttack.Value = 0;
            PRB_baseDivineAttack.Value = 0;
            PRB_baseRevengeAttavk.Value = 0;
            PRB_baseThrowingAttack.Value = 0;
            PRB_baseDarkAttack.Value = 0;
            PRB_baseLightAttack.Value = 0;
            PRB_baseMindAttack.Value = 0;
            PRB_baseControllAttack.Value = 0;

            PRB_baseDeathProt.Value = 0;
            PRB_basePhysicalProt.Value = 0;
            PRB_baseProjectileProt.Value = 0;
            PRB_basePierceProt.Value = 0;
            PRB_baseSlashingProt.Value = 0;
            PRB_baseCrushingProt.Value = 0;
            PRB_baseFracturePtot.Value = 0;
            PRB_baseBleedingProt.Value = 0;
            PRB_baseDiseaseProt.Value = 0;
            PRB_baseInfectionProt.Value = 0;
            PRB_basePoisonProt.Value = 0;
            PRB_baseAsphyxiaProt.Value = 0;
            PRB_baseEnergyProt.Value = 0;
            PRB_baseMagicProt.Value = 0;
            PRB_baseBurningProt.Value = 0;
            PRB_baseEarthProt.Value = 0;
            PRB_baseFrostbiteProt.Value = 0;
            PRB_baseAirProt.Value = 0;
            PRB_baseDarkProt.Value = 0;
            PRB_baseLightProt.Value = 0;
            #endregion
        }



        private void BTN_strengthQualityM_Click(object sender, RoutedEventArgs e)
        {
            if (LBO_rRace.SelectedItem != null)
            {
                BTN_strengthQualityP.IsEnabled = true;
                int strMin = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].StrengthMin;
                int strAct = Convert.ToInt32(TBO_strengthQuality.Text);
                int strMax = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].StrengthMax;
                int pool = Convert.ToInt32(TBO_vitalityQuality.Text);

                if (pool+1 > 0)
                {
                    BTN_strengthQualityP.IsEnabled = true;
                    BTN_endurenceQualityP.IsEnabled = true;
                    BTN_toughtnessQualityP.IsEnabled = true;
                }
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
                    PBR_strengthQuality.Value = strAct;

                    characterIstic[0].strengthA = (strAct - 10) / 2;
                    TBO_STRI.Text = characterIstic[0].strengthA.ToString();
                    characterIstic[0].strengthP = (strAct - 10) / 3;
                    TBO_STRII.Text = characterIstic[0].strengthP.ToString();
                    characteristicPanel();
                }
            }
        }

        private void BTN_strengthQualityP_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LBO_rRace.SelectedItem != null)
                {
                    BTN_strengthQualityM.IsEnabled = true;
                    int strMin = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].StrengthMin;
                    int strAct = Convert.ToInt32(TBO_strengthQuality.Text);
                    int strMax = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].StrengthMax;
                    int pool = Convert.ToInt32(TBO_vitalityQuality.Text);
                    if (pool <= 1)
                    {
                        BTN_strengthQualityP.IsEnabled = false;
                        BTN_endurenceQualityP.IsEnabled = false;
                        BTN_toughtnessQualityP.IsEnabled = false;
                    }

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
                        PBR_strengthQuality.Value = strAct;

                        characterIstic[0].strengthA = (strAct - 10) / 2;
                        TBO_STRI.Text = characterIstic[0].strengthA.ToString();
                        characterIstic[0].strengthP = (strAct - 10) / 3;
                        TBO_STRII.Text = characterIstic[0].strengthP.ToString();
                        characteristicPanel();
                    }
                }
            }
            catch (Exception)
            {   
            }
        }

        private void BTN_endurenceQualityM_Click(object sender, RoutedEventArgs e)
        {
            if (LBO_rRace.SelectedItem != null)
            {
                BTN_endurenceQualityP.IsEnabled = true;
                int endMin = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].EnduranceMin;
                int endAct = Convert.ToInt32(TBO_endurenceQuality.Text);
                int strMax = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].EnduranceMax;
                int pool = Convert.ToInt32(TBO_vitalityQuality.Text);

                if (pool+1 > 0)
                {
                    BTN_strengthQualityP.IsEnabled = true;
                    BTN_endurenceQualityP.IsEnabled = true;
                    BTN_toughtnessQualityP.IsEnabled = true;
                }
                if (endMin + 1 >= endAct)
                {
                    BTN_endurenceQualityM.IsEnabled = false;
                }
                if (endMin <= endAct)
                {
                    endAct--;
                    pool++;
                    TBO_vitalityQuality.Text = pool.ToString();
                    TBO_endurenceQuality.Text = endAct.ToString();
                    PBR_endurenceQuality.Value = endAct;

                    characterIstic[0].endurenceA = (endAct - 10) / 2;
                    TBO_ENDI.Text = characterIstic[0].endurenceA.ToString();
                    characterIstic[0].endurenceP = (endAct - 10) / 3;
                    TBO_ENDII.Text = characterIstic[0].endurenceP.ToString();
                    characteristicPanel();
                }
            }
        }

        private void BTN_endurenceQualityP_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LBO_rRace.SelectedItem != null)
                {
                    BTN_endurenceQualityM.IsEnabled = true;
                    int endMin = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].EnduranceMin;
                    int endAct = Convert.ToInt32(TBO_endurenceQuality.Text);
                    int endMax = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].EnduranceMax;
                    int pool = Convert.ToInt32(TBO_vitalityQuality.Text);

                    if (pool <= 1)
                    {
                        BTN_strengthQualityP.IsEnabled = false;
                        BTN_endurenceQualityP.IsEnabled = false;
                        BTN_toughtnessQualityP.IsEnabled = false;
                    }
                    if (endAct >= endMax - 1)
                    {
                        BTN_endurenceQualityP.IsEnabled = false;
                    }
                    if (endMin <= endAct)
                    {
                        endAct++;
                        pool--;
                        TBO_vitalityQuality.Text = pool.ToString();
                        TBO_endurenceQuality.Text = endAct.ToString();
                        PBR_endurenceQuality.Value = endAct;

                        characterIstic[0].endurenceA = (endAct - 10) / 2;
                        TBO_ENDI.Text = characterIstic[0].endurenceA.ToString();
                        characterIstic[0].endurenceP = (endAct - 10) / 3;
                        TBO_ENDII.Text = characterIstic[0].endurenceP.ToString();
                        characteristicPanel();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void BTN_toughtnessQualityM_Click(object sender, RoutedEventArgs e)
        {
            if (LBO_rRace.SelectedItem != null)
            {
                BTN_toughtnessQualityP.IsEnabled = true;
                int tghMin = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].ToughtnessMin;
                int tghAct = Convert.ToInt32(TBO_toughtnessQuality.Text);
                int tghMax = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].ToughtnessMax;
                int pool = Convert.ToInt32(TBO_vitalityQuality.Text);

                if (pool+1 > 0)
                {
                    BTN_strengthQualityP.IsEnabled = true;
                    BTN_endurenceQualityP.IsEnabled = true;
                    BTN_toughtnessQualityP.IsEnabled = true;
                }
                if (tghMin + 1 >= tghAct)
                {
                    BTN_toughtnessQualityM.IsEnabled = false;
                }
                if (tghMin <= tghAct)
                {
                    tghAct--;
                    pool++;
                    TBO_vitalityQuality.Text = pool.ToString();
                    TBO_toughtnessQuality.Text = tghAct.ToString();
                    PBR_toughtnessQuality.Value = tghAct;

                    characterIstic[0].toughnessA = (tghAct - 10) / 2;
                    TBO_TGHI.Text = characterIstic[0].toughnessA.ToString();
                    characterIstic[0].toughnessP = (tghAct - 10) / 3;
                    TBO_TGHII.Text = characterIstic[0].toughnessP.ToString();
                    characteristicPanel();
                }
            }
        }

        private void BTN_toughtnessQualityP_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LBO_rRace.SelectedItem != null)
                {
                    BTN_toughtnessQualityM.IsEnabled = true;
                    int tghMin = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].ToughtnessMin;
                    int tghAct = Convert.ToInt32(TBO_toughtnessQuality.Text);
                    int tghMax = vitalitys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).VitalityId - 1)].ToughtnessMax;
                    int pool = Convert.ToInt32(TBO_vitalityQuality.Text);

                    if (pool <= 1)
                    {
                        BTN_strengthQualityP.IsEnabled = false;
                        BTN_endurenceQualityP.IsEnabled = false;
                        BTN_toughtnessQualityP.IsEnabled = false;
                    }
                    if (tghAct >= tghMax - 1)
                    {
                        BTN_toughtnessQualityP.IsEnabled = false;
                    }
                    if (tghMin <= tghAct)
                    {
                        tghAct++;
                        pool--;
                        TBO_vitalityQuality.Text = pool.ToString();
                        TBO_toughtnessQuality.Text = tghAct.ToString();
                        PBR_toughtnessQuality.Value = tghAct;

                        characterIstic[0].toughnessA = (tghAct - 10) / 2;
                        TBO_TGHI.Text = characterIstic[0].toughnessA.ToString();
                        characterIstic[0].toughnessP = (tghAct - 10) / 3;
                        TBO_TGHII.Text = characterIstic[0].toughnessP.ToString();
                        characteristicPanel();
                    }
                }
                
            }
            catch (Exception)
            {
            }
        }



        private void BTN_agilityQualityM_Click(object sender, RoutedEventArgs e)
        {
            if (LBO_rRace.SelectedItem != null)
            {
                BTN_agilityQualityP.IsEnabled = true;
                int agiMin = dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].AgilityMin;
                int agiAct = Convert.ToInt32(TBO_agilityQuality.Text);
                int agiMax = dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].AgilityMax;
                int pool = Convert.ToInt32(TBO_dexterityQuality.Text);

                if (pool + 1 > 0)
                {
                    BTN_agilityQualityP.IsEnabled = true;
                    BTN_perceptionQualityP.IsEnabled = true;
                    BTN_quicknessQualityP.IsEnabled = true;
                }
                if (agiMin + 1 >= agiAct)
                {
                    BTN_agilityQualityM.IsEnabled = false;
                }
                if (agiMin <= agiAct)
                {
                    agiAct--;
                    pool++;
                    TBO_dexterityQuality.Text = pool.ToString();
                    TBO_agilityQuality.Text = agiAct.ToString();
                    PBR_agilityQuality.Value = agiAct;

                    characterIstic[0].agilityA = (agiAct - 10) / 2;
                    TBO_AGII.Text = characterIstic[0].agilityA.ToString();
                    characterIstic[0].agilityP = (agiAct - 10) / 3;
                    TBO_AGIII.Text = characterIstic[0].agilityP.ToString();
                    characteristicPanel();
                }
            }
            
        }

        private void BTN_agilityQualityP_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LBO_rRace.SelectedItem != null)
                {
                    BTN_agilityQualityM.IsEnabled = true;
                    int agiMin = dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].AgilityMin;
                    int agiAct = Convert.ToInt32(TBO_agilityQuality.Text);
                    int agiMax = dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].AgilityMax;
                    int pool = Convert.ToInt32(TBO_dexterityQuality.Text);

                    if (pool <= 1)
                    {
                        BTN_agilityQualityP.IsEnabled = false;
                        BTN_perceptionQualityP.IsEnabled = false;
                        BTN_quicknessQualityP.IsEnabled = false;
                    }
                    if (agiAct >= agiMax - 1)
                    {
                        BTN_agilityQualityP.IsEnabled = false;
                    }
                    if (agiMin <= agiAct)
                    {
                        agiAct++;
                        pool--;
                        TBO_dexterityQuality.Text = pool.ToString();
                        TBO_agilityQuality.Text = agiAct.ToString();
                        PBR_agilityQuality.Value = agiAct;

                        characterIstic[0].agilityA = (agiAct - 10) / 2;
                        TBO_AGII.Text = characterIstic[0].agilityA.ToString();
                        characterIstic[0].agilityP = (agiAct - 10) / 3;
                        TBO_AGIII.Text = characterIstic[0].agilityP.ToString();
                        characteristicPanel();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void BTN_perceptionQualityM_Click(object sender, RoutedEventArgs e)
        {
            if (LBO_rRace.SelectedItem != null)
            {
                BTN_perceptionQualityP.IsEnabled = true;
                int perMin = dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].PerceptionMin;
                int perAct = Convert.ToInt32(TBO_perceptionQuality.Text);
                int perMax = dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].PerceptionMax;
                int pool = Convert.ToInt32(TBO_dexterityQuality.Text);

                if (pool + 1 > 0)
                {
                    BTN_agilityQualityP.IsEnabled = true;
                    BTN_perceptionQualityP.IsEnabled = true;
                    BTN_quicknessQualityP.IsEnabled = true;
                }
                if (perMin + 1 >= perAct)
                {
                    BTN_perceptionQualityM.IsEnabled = false;
                }
                if (perMin <= perAct)
                {
                    perAct--;
                    pool++;
                    TBO_dexterityQuality.Text = pool.ToString();
                    TBO_perceptionQuality.Text = perAct.ToString();
                    PBR_perceptionQuality.Value = perAct;

                    characterIstic[0].perceptionA = (perAct - 10) / 2;
                    TBO_PERI.Text = characterIstic[0].perceptionA.ToString();
                    characterIstic[0].perceptionP = (perAct - 10) / 3;
                    TBO_PERII.Text = characterIstic[0].perceptionP.ToString();
                    characteristicPanel();
                }
            }
        }

        private void BTN_perceptionQualityP_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LBO_rRace.SelectedItem != null)
                {
                    BTN_perceptionQualityM.IsEnabled = true;
                    int perMin = dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].PerceptionMin;
                    int perAct = Convert.ToInt32(TBO_perceptionQuality.Text);
                    int perMax = dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].PerceptionMax;
                    int pool = Convert.ToInt32(TBO_dexterityQuality.Text);

                    if (pool <= 1)
                    {
                        BTN_agilityQualityP.IsEnabled = false;
                        BTN_perceptionQualityP.IsEnabled = false;
                        BTN_quicknessQualityP.IsEnabled = false;
                    }
                    if (perAct >= perMax - 1)
                    {
                        BTN_perceptionQualityP.IsEnabled = false;
                    }
                    if (perMin <= perAct)
                    {
                        perAct++;
                        pool--;
                        TBO_dexterityQuality.Text = pool.ToString();
                        TBO_perceptionQuality.Text = perAct.ToString();
                        PBR_perceptionQuality.Value = perAct;

                        characterIstic[0].perceptionA = (perAct - 10) / 2;
                        TBO_PERI.Text = characterIstic[0].perceptionA.ToString();
                        characterIstic[0].perceptionP = (perAct - 10) / 3;
                        TBO_PERII.Text = characterIstic[0].perceptionP.ToString();
                        characteristicPanel();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void BTN_quicknessQualityM_Click(object sender, RoutedEventArgs e)
        {
            if (LBO_rRace.SelectedItem != null)
            {
                BTN_quicknessQualityP.IsEnabled = true;
                int quiMin = dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].QuicknessMin;
                int quiAct = Convert.ToInt32(TBO_quicknessQuality.Text);
                int quiMax = dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].QuicknessMax;
                int pool = Convert.ToInt32(TBO_dexterityQuality.Text);

                if (pool + 1 > 0)
                {
                    BTN_agilityQualityP.IsEnabled = true;
                    BTN_perceptionQualityP.IsEnabled = true;
                    BTN_quicknessQualityP.IsEnabled = true;
                }
                if (quiMin + 1 >= quiAct)
                {
                    BTN_quicknessQualityM.IsEnabled = false;
                }
                if (quiMin <= quiAct)
                {
                    quiAct--;
                    pool++;
                    TBO_dexterityQuality.Text = pool.ToString();
                    TBO_quicknessQuality.Text = quiAct.ToString();
                    PBR_quicknessQuality.Value = quiAct;

                    characterIstic[0].quicknessA = (quiAct - 10) / 2;
                    TBO_QUII.Text = characterIstic[0].quicknessA.ToString();
                    characterIstic[0].quicknessP = (quiAct - 10) / 3;
                    TBO_QUIII.Text = characterIstic[0].quicknessP.ToString();
                    characteristicPanel();
                }
            }
        }

        private void BTN_quicknessQualityP_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LBO_rRace.SelectedItem != null)
                {
                    BTN_quicknessQualityM.IsEnabled = true;
                    int quiMin = dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].QuicknessMin;
                    int quiAct = Convert.ToInt32(TBO_quicknessQuality.Text);
                    int quiMax = dexteritys[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).DexterityId - 1)].QuicknessMax;
                    int pool = Convert.ToInt32(TBO_dexterityQuality.Text);

                    if (pool <= 1)
                    {
                        BTN_agilityQualityP.IsEnabled = false;
                        BTN_perceptionQualityP.IsEnabled = false;
                        BTN_quicknessQualityP.IsEnabled = false;
                    }
                    if (quiAct >= quiMax - 1)
                    {
                        BTN_quicknessQualityP.IsEnabled = false;
                    }
                    if (quiMin <= quiAct)
                    {
                        quiAct++;
                        pool--;
                        TBO_dexterityQuality.Text = pool.ToString();
                        TBO_quicknessQuality.Text = quiAct.ToString();
                        PBR_quicknessQuality.Value = quiAct;

                        characterIstic[0].quicknessA = (quiAct - 10) / 2;
                        TBO_QUII.Text = characterIstic[0].quicknessA.ToString();
                        characterIstic[0].quicknessP = (quiAct - 10) / 3;
                        TBO_QUIII.Text = characterIstic[0].quicknessP.ToString();
                        characteristicPanel();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        
        
        private void BTN_intelligenceQualityM_Click(object sender, RoutedEventArgs e)
        {
            if (LBO_rRace.SelectedItem != null)
            {
                BTN_intelligenceQualityP.IsEnabled = true;
                int intMin = intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].IntelligenceMin;
                int intAct = Convert.ToInt32(TBO_intelligenceQuality.Text);
                int intMax = intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].IntelligenceMax;
                int pool = Convert.ToInt32(TBO_intuitionQuality.Text);

                if (pool + 1 > 0)
                {
                    BTN_intelligenceQualityP.IsEnabled = true;
                    BTN_wisdomQualityP.IsEnabled = true;
                    BTN_resourcefullQualityP.IsEnabled = true;
                }
                if (intMin + 1 >= intAct)
                {
                    BTN_intelligenceQualityM.IsEnabled = false;
                }
                if (intMin <= intAct)
                {
                    intAct--;
                    pool++;
                    TBO_intuitionQuality.Text = pool.ToString();
                    TBO_intelligenceQuality.Text = intAct.ToString();
                    PBR_intelligenceQuality.Value = intAct;

                    characterIstic[0].intelligenceA = (intAct - 10) / 2;
                    TBO_INTI.Text = characterIstic[0].intelligenceA.ToString();
                    characterIstic[0].intelligenceP = (intAct - 10) / 3;
                    TBO_INTII.Text = characterIstic[0].intelligenceP.ToString();
                    characteristicPanel();
                }
            }
        }

        private void BTN_intelligenceQualityP_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LBO_rRace.SelectedItem != null)
                {
                    BTN_intelligenceQualityM.IsEnabled = true;
                    int intMin = intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].IntelligenceMin;
                    int intAct = Convert.ToInt32(TBO_intelligenceQuality.Text);
                    int intMax = intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].IntelligenceMax;
                    int pool = Convert.ToInt32(TBO_intuitionQuality.Text);

                    if (pool <= 1)
                    {
                        BTN_intelligenceQualityP.IsEnabled = false;
                        BTN_wisdomQualityP.IsEnabled = false;
                        BTN_resourcefullQualityP.IsEnabled = false;
                    }
                    if (intAct >= intMax - 1)
                    {
                        BTN_intelligenceQualityP.IsEnabled = false;
                    }
                    if (intMin <= intAct)
                    {
                        intAct++;
                        pool--;
                        TBO_intuitionQuality.Text = pool.ToString();
                        TBO_intelligenceQuality.Text = intAct.ToString();
                        PBR_intelligenceQuality.Value = intAct;

                        characterIstic[0].intelligenceA = (intAct - 10) / 2;
                        TBO_INTI.Text = characterIstic[0].intelligenceA.ToString();
                        characterIstic[0].intelligenceP = (intAct - 10) / 3;
                        TBO_INTII.Text = characterIstic[0].intelligenceP.ToString();
                        characteristicPanel();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void BTN_wisdomQualityM_Click(object sender, RoutedEventArgs e)
        {
            if (LBO_rRace.SelectedItem != null)
            {
                BTN_wisdomQualityP.IsEnabled = true;
                int wisMin = intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].WisdomMin;
                int wisAct = Convert.ToInt32(TBO_wisdomQuality.Text);
                int wisMax = intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].WisdomMax;
                int pool = Convert.ToInt32(TBO_intuitionQuality.Text);

                if (pool + 1 > 0)
                {
                    BTN_intelligenceQualityP.IsEnabled = true;
                    BTN_wisdomQualityP.IsEnabled = true;
                    BTN_resourcefullQualityP.IsEnabled = true;
                }
                if (wisMin + 1 >= wisAct)
                {
                    BTN_wisdomQualityM.IsEnabled = false;
                }
                if (wisMin <= wisAct)
                {
                    wisAct--;
                    pool++;
                    TBO_intuitionQuality.Text = pool.ToString();
                    TBO_wisdomQuality.Text = wisAct.ToString();
                    PBR_wisdomQuality.Value = wisAct;

                    characterIstic[0].wisdomA = (wisAct - 10) / 2;
                    TBO_WISI.Text = characterIstic[0].wisdomA.ToString();
                    characterIstic[0].wisdomP = (wisAct - 10) / 3;
                    TBO_WISII.Text = characterIstic[0].wisdomP.ToString();
                    characteristicPanel();
                }
            }
        }

        private void BTN_wisdomQualityP_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LBO_rRace.SelectedItem != null)
                {
                    BTN_wisdomQualityM.IsEnabled = true;
                    int wisMin = intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].WisdomMin;
                    int wisAct = Convert.ToInt32(TBO_wisdomQuality.Text);
                    int wisMax = intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].WisdomMax;
                    int pool = Convert.ToInt32(TBO_intuitionQuality.Text);

                    if (pool <= 1)
                    {
                        BTN_intelligenceQualityP.IsEnabled = false;
                        BTN_wisdomQualityP.IsEnabled = false;
                        BTN_resourcefullQualityP.IsEnabled = false;
                    }
                    if (wisAct >= wisMax - 1)
                    {
                        BTN_wisdomQualityP.IsEnabled = false;
                    }
                    if (wisMin <= wisAct)
                    {
                        wisAct++;
                        pool--;
                        TBO_intuitionQuality.Text = pool.ToString();
                        TBO_wisdomQuality.Text = wisAct.ToString();
                        PBR_wisdomQuality.Value = wisAct;

                        characterIstic[0].wisdomA = (wisAct - 10) / 2;
                        TBO_WISI.Text = characterIstic[0].wisdomA.ToString();
                        characterIstic[0].wisdomP = (wisAct - 10) / 3;
                        TBO_WISII.Text = characterIstic[0].wisdomP.ToString();
                        characteristicPanel();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void BTN_resourcefullQualityM_Click(object sender, RoutedEventArgs e)
        {
            if (LBO_rRace.SelectedItem != null)
            {
                BTN_resourcefullQualityP.IsEnabled = true;
                int resMin = intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].ResourcefullMin;
                int resAct = Convert.ToInt32(TBO_resourcefullQuality.Text);
                int resMax = intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].ResourcefullMax;
                int pool = Convert.ToInt32(TBO_intuitionQuality.Text);

                if (pool + 1 > 0)
                {
                    BTN_intelligenceQualityP.IsEnabled = true;
                    BTN_wisdomQualityP.IsEnabled = true;
                    BTN_resourcefullQualityP.IsEnabled = true;
                }
                if (resMin + 1 >= resAct)
                {
                    BTN_resourcefullQualityM.IsEnabled = false;
                }
                if (resMin <= resAct)
                {
                    resAct--;
                    pool++;
                    TBO_intuitionQuality.Text = pool.ToString();
                    TBO_resourcefullQuality.Text = resAct.ToString();
                    PBR_resourcefullQuality.Value = resAct;

                    characterIstic[0].resourcefullA = (resAct - 10) / 2;
                    TBO_RESI.Text = characterIstic[0].resourcefullA.ToString();
                    characterIstic[0].resourcefullP = (resAct - 10) / 3;
                    TBO_RESII.Text = characterIstic[0].resourcefullP.ToString();
                    characteristicPanel();
                }
            }
        }

        private void BTN_resourcefullQualityP_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LBO_rRace.SelectedItem != null)
                {
                    BTN_resourcefullQualityM.IsEnabled = true;
                    int resMin = intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].ResourcefullMin;
                    int resAct = Convert.ToInt32(TBO_resourcefullQuality.Text);
                    int resMax = intuitions[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).IntuitionId - 1)].ResourcefullMax;
                    int pool = Convert.ToInt32(TBO_intuitionQuality.Text);

                    if (pool <= 1)
                    {
                        BTN_intelligenceQualityP.IsEnabled = false;
                        BTN_wisdomQualityP.IsEnabled = false;
                        BTN_resourcefullQualityP.IsEnabled = false;
                    }
                    if (resAct >= resMax - 1)
                    {
                        BTN_resourcefullQualityP.IsEnabled = false;
                    }
                    if (resMin <= resAct)
                    {
                        resAct++;
                        pool--;
                        TBO_intuitionQuality.Text = pool.ToString();
                        TBO_resourcefullQuality.Text = resAct.ToString();
                        PBR_resourcefullQuality.Value = resAct;

                        characterIstic[0].resourcefullA = (resAct - 10) / 2;
                        TBO_RESI.Text = characterIstic[0].resourcefullA.ToString();
                        characterIstic[0].resourcefullP = (resAct - 10) / 3;
                        TBO_RESII.Text = characterIstic[0].resourcefullP.ToString();
                        characteristicPanel();
                    }
                }
            }
            catch (Exception)
            {
            }
        }



        private void BTN_appearanceQualityM_Click(object sender, RoutedEventArgs e)
        {
            if (LBO_rRace.SelectedItem != null)
            {
                try
                {
                    BTN_appearanceQualityP.IsEnabled = true;
                    int appMin = charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].AppearanceMin;
                    int appAct = Convert.ToInt32(TBO_appearanceQuality.Text);
                    int appMax = charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].AppearanceMax;
                    int pool = Convert.ToInt32(TBO_charismaQuality.Text);

                    if (pool + 1 > 0)
                    {
                        BTN_appearanceQualityP.IsEnabled = true;
                        BTN_influenceQualityP.IsEnabled = true;
                        BTN_luckQualityP.IsEnabled = true;
                    }
                    if (appMin + 1 >= appAct)
                    {
                        BTN_appearanceQualityM.IsEnabled = false;
                    }
                    if (appMin <= appAct)
                    {
                        appAct--;
                        pool++;
                        TBO_charismaQuality.Text = pool.ToString();
                        TBO_appearanceQuality.Text = appAct.ToString();
                        PBR_appearanceQuality.Value = appAct;

                        characterIstic[0].appearanceA = (appAct - 10) / 2;
                        TBO_APPI.Text = characterIstic[0].appearanceA.ToString();
                        characterIstic[0].appearanceP = (appAct - 10) / 3;
                        TBO_APPII.Text = characterIstic[0].appearanceP.ToString();
                        characteristicPanel();
                    }
                }
                catch (Exception)
                {
                }
                
            }
        }

        private void BTN_appearanceQualityP_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LBO_rRace.SelectedItem != null)
                {
                    BTN_appearanceQualityM.IsEnabled = true;
                    int appMin = charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].AppearanceMin;
                    int appAct = Convert.ToInt32(TBO_appearanceQuality.Text);
                    int appMax = charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].AppearanceMax;
                    int pool = Convert.ToInt32(TBO_charismaQuality.Text);

                    if (pool <= 1)
                    {
                        BTN_appearanceQualityP.IsEnabled = false;
                        BTN_influenceQualityP.IsEnabled = false;
                        BTN_luckQualityP.IsEnabled = false;
                    }
                    if (appAct >= appMax - 1)
                    {
                        BTN_appearanceQualityP.IsEnabled = false;
                    }
                    if (appMin <= appAct)
                    {
                        appAct++;
                        pool--;
                        TBO_charismaQuality.Text = pool.ToString();
                        TBO_appearanceQuality.Text = appAct.ToString();
                        PBR_appearanceQuality.Value = appAct;

                        characterIstic[0].appearanceA = (appAct - 10) / 2;
                        TBO_APPI.Text = characterIstic[0].appearanceA.ToString();
                        characterIstic[0].appearanceP = (appAct - 10) / 3;
                        TBO_APPII.Text = characterIstic[0].appearanceP.ToString();
                        characteristicPanel();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void BTN_influenceQualityM_Click(object sender, RoutedEventArgs e)
        {
            if (LBO_rRace.SelectedItem != null)
            {
                BTN_influenceQualityP.IsEnabled = true;
                int infMin = charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].InfluenceMin;
                int infAct = Convert.ToInt32(TBO_influenceQuality.Text);
                int infMax = charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].InfluenceMax;
                int pool = Convert.ToInt32(TBO_charismaQuality.Text);

                if (pool + 1 > 0)
                {
                    BTN_appearanceQualityP.IsEnabled = true;
                    BTN_influenceQualityP.IsEnabled = true;
                    BTN_luckQualityP.IsEnabled = true;
                }
                if (infMin + 1 >= infAct)
                {
                    BTN_influenceQualityM.IsEnabled = false;
                }
                if (infMin <= infAct)
                {
                    infAct--;
                    pool++;
                    TBO_charismaQuality.Text = pool.ToString();
                    TBO_influenceQuality.Text = infAct.ToString();
                    PBR_influenceQuality.Value = infAct;

                    characterIstic[0].influenceA = (infAct - 10) / 2;
                    TBO_INFI.Text = characterIstic[0].influenceA.ToString();
                    characterIstic[0].influenceP = (infAct - 10) / 3;
                    TBO_INFII.Text = characterIstic[0].influenceP.ToString();
                    characteristicPanel();
                }
            }
        }

        private void BTN_influenceQualityP_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LBO_rRace.SelectedItem != null)
                {
                    BTN_influenceQualityM.IsEnabled = true;
                    int infMin = charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].InfluenceMin;
                    int infAct = Convert.ToInt32(TBO_influenceQuality.Text);
                    int infMax = charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].InfluenceMax;
                    int pool = Convert.ToInt32(TBO_charismaQuality.Text);

                    if (pool <= 1)
                    {
                        BTN_appearanceQualityP.IsEnabled = false;
                        BTN_influenceQualityP.IsEnabled = false;
                        BTN_luckQualityP.IsEnabled = false;
                    }
                    if (infAct >= infMax - 1)
                    {
                        BTN_influenceQualityP.IsEnabled = false;
                    }
                    if (infMin <= infAct)
                    {
                        infAct++;
                        pool--;
                        TBO_charismaQuality.Text = pool.ToString();
                        TBO_influenceQuality.Text = infAct.ToString();
                        PBR_influenceQuality.Value = infAct;

                        characterIstic[0].influenceA = (infAct - 10) / 2;
                        TBO_INFI.Text = characterIstic[0].influenceA.ToString();
                        characterIstic[0].influenceP = (infAct - 10) / 3;
                        TBO_INFII.Text = characterIstic[0].influenceP.ToString();
                        characteristicPanel();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void BTN_luckQualityM_Click(object sender, RoutedEventArgs e)
        {
            if (LBO_rRace.SelectedItem != null)
            {
                BTN_luckQualityP.IsEnabled = true;
                int luckMin = charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].LuckMin;
                int luckAct = Convert.ToInt32(TBO_luckQuality.Text);
                int luckMax = charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].LuckMax;
                int pool = Convert.ToInt32(TBO_charismaQuality.Text);

                if (pool + 1 > 0)
                {
                    BTN_appearanceQualityP.IsEnabled = true;
                    BTN_influenceQualityP.IsEnabled = true;
                    BTN_luckQualityP.IsEnabled = true;
                }
                if (luckMin + 1 >= luckAct)
                {
                    BTN_luckQualityM.IsEnabled = false;
                }
                if (luckMin <= luckAct)
                {
                    luckAct--;
                    pool++;
                    TBO_charismaQuality.Text = pool.ToString();
                    TBO_luckQuality.Text = luckAct.ToString();
                    PBR_luckQuality.Value = luckAct;

                    characterIstic[0].luckA = (luckAct - 10) / 2;
                    TBO_LuckI.Text = characterIstic[0].luckA.ToString();
                    characterIstic[0].luckP = (luckAct - 10) / 3;
                    TBO_LuckII.Text = characterIstic[0].luckP.ToString();
                    characteristicPanel();
                }
            }
        }

        private void BTN_luckQualityP_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LBO_rRace.SelectedItem != null)
                {
                    BTN_luckQualityM.IsEnabled = true;
                    int luckMin = charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].LuckMin;
                    int luckAct = Convert.ToInt32(TBO_luckQuality.Text);
                    int luckMax = charisms[Convert.ToInt32(((Races)LBO_rRace.SelectedItem).CharismaId - 1)].LuckMax;
                    int pool = Convert.ToInt32(TBO_charismaQuality.Text);

                    if (pool <= 1)
                    {
                        BTN_appearanceQualityP.IsEnabled = false;
                        BTN_influenceQualityP.IsEnabled = false;
                        BTN_luckQualityP.IsEnabled = false;
                    }
                    if (luckAct >= luckMax - 1)
                    {
                        BTN_luckQualityP.IsEnabled = false;
                    }
                    if (luckMin <= luckAct)
                    {
                        luckAct++;
                        pool--;
                        TBO_charismaQuality.Text = pool.ToString();
                        TBO_luckQuality.Text = luckAct.ToString();
                        PBR_luckQuality.Value = luckAct;

                        characterIstic[0].luckA = (luckAct - 10) / 2;
                        TBO_LuckI.Text = characterIstic[0].luckA.ToString();
                        characterIstic[0].luckP = (luckAct - 10) / 3;
                        TBO_LuckII.Text = characterIstic[0].luckP.ToString();
                        characteristicPanel();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        
        
        private void LBO_optionalSkill_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        
        
        
        




        private async void BTN_Exit_Click(object sender, RoutedEventArgs e)
        {
            quickStartWindow qsw = new quickStartWindow();
            await Task.Delay(125);
            this.Close();
            qsw.ShowDialog();
        }

        private void BTN_finaly_Click(object sender, RoutedEventArgs e)
        {
            //characterStatisticWindow csw = new characterStatisticWindow();
            //this.Close();
            //csw.Show();
        }
    }
}
