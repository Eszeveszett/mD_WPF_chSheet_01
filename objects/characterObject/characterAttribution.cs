using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mD_WPF_chSheet_01.objects.characterObject
{
    public class characterAttribution
    {
        public int vitality { get; set; }
        public int vitalityBonus { get; set; }
        public int dexterity { get; set; }
        public int dexterityBonus { get; set; }
        public int intuition { get; set; }
        public int intuitionBonus { get; set; }
        public int charisma { get; set; }
        public int charismaBonus { get; set; }

        public int endurence { get; set; }
        public int endurenceA { get; set; }
        public int endurenceP { get; set; }
        public int toughness { get; set; }
        public int toughnessA { get; set; }
        public int toughnessP { get; set; }
        public int strength { get; set; }
        public int strengthA { get; set; }
        public int strengthP { get; set; }

        public int perception { get; set; }
        public int perceptionA { get; set; }
        public int perceptionP { get; set; }
        public int quickness { get; set; }
        public int quicknessA { get; set; }
        public int quicknessP { get; set; }
        public int agility { get; set; }
        public int agilityA { get; set; }
        public int agilityP { get; set; }

        public int intelligence { get; set; }
        public int intelligenceA { get; set; }
        public int intelligenceP { get; set; }
        public int wisdom { get; set; }
        public int wisdomA { get; set; }
        public int wisdomP { get; set; }
        public int resourcefull { get; set; }
        public int resourcefullA { get; set; }
        public int resourcefullP { get; set; }

        public int influence { get; set; }
        public int influenceA { get; set; }
        public int influenceP { get; set; }
        public int appearance { get; set; }
        public int appearanceA { get; set; }
        public int appearanceP { get; set; }
        public int luck { get; set; }
        public int luckA { get; set; }
        public int luckP { get; set; }

        public characterAttribution
            (int vitality, int vitalityBonus, int dexterity, int dexterityBonus, int intuition, int intuitionBonus, int charisma, int charismaBonus,
            int endurence, int endurenceA, int endurenceP, int toughness, int toughnessA, int toughnessP, int strength, int strengthA, int strengthP,
            int perception, int perceptionA, int perceptionP, int quickness, int quicknessA, int quicknessP, int agility, int agilityA, int agilityP,
            int intelligence, int intelligenceA, int intelligenceP, int wisdom, int wisdomA, int wisdomP, int resourcefull, int resourcefullA, int resourcefullP,
            int influence, int influenceA, int influenceP, int appearance, int appearanceA, int appearanceP, int luck, int luckA, int luckP)
        {
            this.vitality = vitality;
            this.vitalityBonus = vitalityBonus;
            this.dexterity = dexterity;
            this.dexterityBonus = dexterityBonus;
            this.intuition = intuition;
            this.intuitionBonus = intuitionBonus;
            this.charisma = charisma;
            this.charismaBonus = charismaBonus;

            this.endurence = endurence;
            this.endurenceA = endurenceA;
            this.endurenceP = endurenceP;

            this.toughness = toughness;
            this.toughnessA = toughnessA;
            this.toughnessP = toughnessP;

            this.strength = strength;
            this.strengthA = strengthA;
            this.strengthP = strengthP;

            this.perception = perception;
            this.perceptionA = perceptionA;
            this.perceptionP = perceptionP;

            this.quickness = quickness;
            this.quicknessA = quicknessA;
            this.quicknessP = quicknessP;

            this.agility = agility;
            this.agilityA = agilityA;
            this.agilityP = agilityP;

            this.intelligence = intelligence;
            this.intelligenceA = intelligenceA;
            this.intelligenceP = intelligenceP;

            this.wisdom = wisdom;
            this.wisdomA = wisdomA;
            this.wisdomP = wisdomP;

            this.resourcefull = resourcefull;
            this.resourcefullA = resourcefullA;
            this.resourcefullP = resourcefullP;

            this.influence = influence;
            this.influenceA = influenceA;
            this.influenceP = influenceP;

            this.appearance = appearance;
            this.appearanceA = appearanceA;
            this.appearanceP = appearanceP;

            this.luck = luck;
            this.luckA = luckA;
            this.luckP = luckP;
        }

        public characterAttribution()
        {

        }

        public characterAttribution
            (
            int endurence, int endurenceA, int endurenceP, int toughness, int toughnessA, int toughnessP, int strength, int strengthA, int strengthP,
            int perception, int perceptionA, int perceptionP, int quickness, int quicknessA, int quicknessP, int agility, int agilityA, int agilityP,
            int intelligence, int intelligenceA, int intelligenceP, int wisdom, int wisdomA, int wisdomP, int resourcefull, int resourcefullA, int resourcefullP,
            int influence, int influenceA, int influenceP, int appearance, int appearanceA, int appearanceP, int luck, int luckA, int luckP
            )
        {

            this.endurence = endurence;
            this.endurenceA = endurenceA;
            this.endurenceP = endurenceP;

            this.toughness = toughness;
            this.toughnessA = toughnessA;
            this.toughnessP = toughnessP;

            this.strength = strength;
            this.strengthA = strengthA;
            this.strengthP = strengthP;

            this.perception = perception;
            this.perceptionA = perceptionA;
            this.perceptionP = perceptionP;

            this.quickness = quickness;
            this.quicknessA = quicknessA;
            this.quicknessP = quicknessP;

            this.agility = agility;
            this.agilityA = agilityA;
            this.agilityP = agilityP;

            this.intelligence = intelligence;
            this.intelligenceA = intelligenceA;
            this.intelligenceP = intelligenceP;

            this.wisdom = wisdom;
            this.wisdomA = wisdomA;
            this.wisdomP = wisdomP;

            this.resourcefull = resourcefull;
            this.resourcefullA = resourcefullA;
            this.resourcefullP = resourcefullP;

            this.influence = influence;
            this.influenceA = influenceA;
            this.influenceP = influenceP;

            this.appearance = appearance;
            this.appearanceA = appearanceA;
            this.appearanceP = appearanceP;

            this.luck = luck;
            this.luckA = luckA;
            this.luckP = luckP;
        }


        //public characterAttribution(int strI, int strII, int endI, int endII, int tghI, int tghII)
        //{
        //    this.strengthA = strI; this.strengthP = strII; this.endurenceA = endI; this.endurenceP = endII; this.toughnessA = tghI; this.toughnessP = tghII;
        //}

        //public override string ToString()
        //{
        //    return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}{16}{17}{18}{19}{20}{21}" +
        //        "{22}{23}{24}{25}{26}{27}{28}{29}{30}{31}{32}{33}{34}{35}{36}{37}{38}{39}{40}{41}{42}{43}",
        //        vitality, dexterity, intuition, charisma, vitalityBonus, dexterityBonus, intuitionBonus, charismaBonus,
        //        endurence, toughness, strength, endurenceA, toughnessA, strengthA, endurenceP, toughnessP, strengthP,
        //        perception, quickness, agility, perceptionA, quicknessA, agilityA, perceptionP, quicknessP, agilityP,
        //        intelligence, wisdom, resourcefull, intelligenceA, wisdomA, resourcefullA, intelligenceP, wisdomP, resourcefullP,
        //        influence, appearance, luck, influenceA, appearanceA, luckA, influenceP, appearanceP, luckP);
        //}

        //public override string ToString()
        //{
        //    return string.Format("Vitality: {0} Base Health: {4}\t\tDexterity: {1} Base Exhaustion: {5}\tIntuition: {2} Base Mana: {6}\tCharisma: {3} Base Charm: {7}\n" +
        //    "endurence: {8}\tI: {11} II: {14}\t\tagility:    {19} I: {22} II: {25}\t\tintelligence: {26} I: {29} II: {32}\tinfluence:  {35} I: {38} II: {41}\n" +
        //    "toughness: {9}\tI: {12} II: {15}\t\tperception: {17} I: {20} II: {23}\t\twisdom:       {27} I: {30} II: {33}\tappearance: {36} I: {39} II: {42}\n" +
        //    "strength:  {10}\tI: {13} II: {16}\t\tquickness:  {18} I: {21} II: {24}\t\tresourcefull: {28} I: {31} II: {34}\tluck:       {37} I: {40} II: {43}\n",
        //            vitality, dexterity, intuition, charisma, vitalityBonus, dexterityBonus, intuitionBonus, charismaBonus,
        //            endurence, toughness, strength, endurenceA, toughnessA, strengthA, endurenceP, toughnessP, strengthP,
        //            perception, quickness, agility, perceptionA, quicknessA, agilityA, perceptionP, quicknessP, agilityP,
        //            intelligence, wisdom, resourcefull, intelligenceA, wisdomA, resourcefullA, intelligenceP, wisdomP, resourcefullP,
        //            influence, appearance, luck, influenceA, appearanceA, luckA, influenceP, appearanceP, luckP);
        //}

        //public override string ToString()
        //{
        //    return string.Format("Vitality: {0} Base Health: {4}Dexterity: {1} Base Exhaustion: {5}Intuition: {2} Base Mana: {6}Charisma: {3} Base Charm: {7}\n" +
        //    "endurence: {8}I: {11} II: {14}agility:    {19} I: {22} II: {25}intelligence: {26} I: {29} II: {32}influence:  {35} I: {38} II: {41}\n" +
        //    "toughness: {9}I: {12} II: {15}perception: {17} I: {20} II: {23}wisdom:       {27} I: {30} II: {33}appearance: {36} I: {39} II: {42}\n" +
        //    "strength:  {10}I: {13} II: {16}quickness:  {18} I: {21} II: {24}resourcefull: {28} I: {31} II: {34}luck:       {37} I: {40} II: {43}\n",
        //            vitality, dexterity, intuition, charisma, vitalityBonus, dexterityBonus, intuitionBonus, charismaBonus,
        //            endurence, toughness, strength, endurenceA, toughnessA, strengthA, endurenceP, toughnessP, strengthP,
        //            perception, quickness, agility, perceptionA, quicknessA, agilityA, perceptionP, quicknessP, agilityP,
        //            intelligence, wisdom, resourcefull, intelligenceA, wisdomA, resourcefullA, intelligenceP, wisdomP, resourcefullP,
        //            influence, appearance, luck, influenceA, appearanceA, luckA, influenceP, appearanceP, luckP);
        //}
    }
}
