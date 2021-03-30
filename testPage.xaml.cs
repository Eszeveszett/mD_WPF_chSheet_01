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

using System.Threading;

using System.IO;

using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Collections.ObjectModel;

using mD_WPF_chSheet_01.Models.dzeta;
using mD_WPF_chSheet_01.objects.characterObject;

namespace mD_WPF_chSheet_01
{
    /// <summary>
    /// Interaction logic for testPage.xaml
    /// </summary>
    public partial class testPage : Page
    {
        public testPage()
        {
                InitializeComponent();
        }

        public void mainAttributionselector(List<characterAttribution> attributionMain, List<attributionBonus> bonus)
        {
            List<raceAttributionBorder> attributumBorder = new List<raceAttributionBorder>();
            raceSelector(attributumBorder);
            List<string> attributumName = new List<string>();
            List<string> myattributumName = new List<string>(); List<int> myattributumValue = new List<int>();
            attributumName.Add("Vitality"); attributumName.Add("Dexterity"); attributumName.Add("Intuition"); attributumName.Add("Charisma");
            int distributedPoint = 50;
            List<int> minValue = new List<int>();
            minValue.Add(attributumBorder[0].enduranceMin + attributumBorder[0].toughnessMin + attributumBorder[0].strengthMin);
            minValue.Add(attributumBorder[0].agilityMin + attributumBorder[0].quicknessMin + attributumBorder[0].perceptionMin);
            minValue.Add(attributumBorder[0].intelligenceMin + attributumBorder[0].resourcefullMin + attributumBorder[0].wisdomMin);
            minValue.Add(attributumBorder[0].appearanceMin + attributumBorder[0].influenceMin + attributumBorder[0].luckMin);

            while (distributedPoint != 30)
            {
                for (int i = 0; i < attributumName.Count; i++)
                {
                    Console.WriteLine("\t{0,5} {1,5} {2,5}", i + 1, attributumName[i], minValue[i]);
                }
                for (int i = 0; i < attributumName.Count; i++)
                {
                    if (distributedPoint < minValue[i]) //  Max Value Chesk is missing
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Console.WriteLine("The character is unviable");
                        Thread.Sleep(500);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        distributedPoint = 50;
                        attributumName.Clear(); minValue.Clear();
                        attributumName.Add("Vitality"); attributumName.Add("Dexterity"); attributumName.Add("Intuition"); attributumName.Add("Charisma");
                        minValue.Add(attributumBorder[0].enduranceMin + attributumBorder[0].toughnessMin + attributumBorder[0].strengthMin);
                        minValue.Add(attributumBorder[0].agilityMin + attributumBorder[0].quicknessMin + attributumBorder[0].perceptionMin);
                        minValue.Add(attributumBorder[0].intelligenceMin + attributumBorder[0].resourcefullMin + attributumBorder[0].wisdomMin);
                        minValue.Add(attributumBorder[0].appearanceMin + attributumBorder[0].influenceMin + attributumBorder[0].luckMin);
                        for (int q = 0; q < attributumName.Count; q++)
                        {
                            Console.WriteLine("\t{0,5} {1,5}", q + 1, attributumName[q]);
                        }
                    }
                }
                if (distributedPoint.Equals(50))
                {
                    Console.WriteLine("What is youre first ability?");
                }
                else if (distributedPoint.Equals(45))
                {
                    Console.WriteLine("What is youre second ability?");
                }
                else if (distributedPoint.Equals(40))
                {
                    Console.WriteLine("What is youre third ability?");
                }
                else
                {
                    Console.WriteLine("What is youre fourth ability?");
                }
                try
                {
                    int pickingattributum = Convert.ToInt32(Console.ReadLine());
                    minValue.Remove(minValue[pickingattributum - 1]);
                    myattributumName.Add(attributumName[pickingattributum - 1]);
                    myattributumValue.Add(distributedPoint);
                    attributumName.Remove(attributumName[pickingattributum - 1]);
                    distributedPoint -= 5;
                }
                catch (Exception)
                {
                    Console.WriteLine("Relax");
                }
            }
            for (int i = 0; i < myattributumName.Count; i++)
            {
                if (myattributumName[i].Contains("Vitality"))
                {
                    attributionMain[0].vitality = myattributumValue[i];
                    attributionMain[0].vitalityBonus = attributionMain[0].vitality - 30;
                }
                if (myattributumName[i].Contains("Dexterity"))
                {
                    attributionMain[0].dexterity = myattributumValue[i];
                    attributionMain[0].dexterityBonus = attributionMain[0].dexterity - 30;
                }
                if (myattributumName[i].Contains("Intuition"))
                {
                    attributionMain[0].intuition = myattributumValue[i];
                    attributionMain[0].intuitionBonus = attributionMain[0].intuition - 30;
                }
                if (myattributumName[i].Contains("Charisma"))
                {
                    attributionMain[0].charisma = myattributumValue[i];
                    attributionMain[0].charismaBonus = attributionMain[0].charisma - 30;
                }
            }
            foreach (var item in attributionMain)
            {
                Console.WriteLine("{0,-5}", item);
            }
            vitality(attributionMain, bonus, attributumBorder);
            Console.Clear();
            dexterity(attributionMain, bonus, attributumBorder);
            Console.Clear();
            intuition(attributionMain, bonus, attributumBorder);
            Console.Clear();
            charisma(attributionMain, bonus, attributumBorder);
            Console.Clear();
            //for (int i = 0; i < myattributumName.Count; i++)
            //{
            //    Console.WriteLine("{0}",myattributumName[i]);
            //}

            //Console.WriteLine("mainAttributumselector");
        }

        public void raceSelector(List<raceAttributionBorder> attributionBorder)
        {
            List<string> pickedRace = new List<string>();
            pickedRace.Add("Mountain Dwarf"); pickedRace.Add("Shadow Elf"); pickedRace.Add("Surface Dwarf"); pickedRace.Add("Hill Dwarf");
            pickedRace.Add("Nord"); pickedRace.Add("Forest Elf"); pickedRace.Add("Liar Bastard"); pickedRace.Add("Town Elf");
            pickedRace.Add("Townsman"); pickedRace.Add("Nomad"); pickedRace.Add("Savage");
            for (int i = 0; i < pickedRace.Count; i++)
            {
                Console.WriteLine("{0} {1}", i + 1, pickedRace[i]);
            }

            bool pick = false;
            while (!pick.Equals(true))
            {
                Console.WriteLine("Picking you'r race");
                try
                {
                    int picked = Convert.ToInt32(Console.ReadLine());
                    switch (picked)
                    {
                        case (1):
                            mountainDwarf(attributionBorder); Console.WriteLine("You are one Dwarf. Mountain Dwarf. Your ability minimum and maximum is.:");
                            foreach (var item in attributionBorder)
                            {
                                Console.WriteLine(item);
                            }
                            pick = true; break;
                        case (2):
                            shadowElf(attributionBorder); Console.WriteLine("You are one Elf. Shadow Elf. Your ability minimum and maximum is.:");
                            foreach (var item in attributionBorder)
                            {
                                Console.WriteLine(item);
                            }
                            pick = true; break;
                        case (3):
                            surfaceDwarf(attributionBorder); Console.WriteLine("You are one Dwarf. Surface Dwarf. Your ability minimum and maximum is.:");
                            foreach (var item in attributionBorder)
                            {
                                Console.WriteLine(item);
                            }
                            pick = true; break;
                        case (4):
                            hillDwarf(attributionBorder); Console.WriteLine("You are one Dwarf. Hill Dwarf. Your ability minimum and maximum is.:");
                            foreach (var item in attributionBorder)
                            {
                                Console.WriteLine(item);
                            }
                            pick = true; break;
                        case (5):
                            northmen(attributionBorder); Console.WriteLine("You are one Human. Nord. Your ability minimum and maximum is.:");
                            foreach (var item in attributionBorder)
                            {
                                Console.WriteLine(item);
                            }
                            pick = true; break;
                        case (6):
                            forestElf(attributionBorder); Console.WriteLine("You are one Elf. Forest Elf. Your ability minimum and maximum is.:");
                            foreach (var item in attributionBorder)
                            {
                                Console.WriteLine(item);
                            }
                            pick = true; break;
                        case (7):
                            swampElf(attributionBorder); Console.WriteLine("You are one Elf. The real, liar, bastard Swamp Elf. Your ability minimum and maximum is.:");
                            foreach (var item in attributionBorder)
                            {
                                Console.WriteLine(item);
                            }
                            pick = true; break;
                        case (8):
                            townElf(attributionBorder); Console.WriteLine("You are one Elf. Town Elf. Your ability minimum and maximum is.:");
                            foreach (var item in attributionBorder)
                            {
                                Console.WriteLine(item);
                            }
                            pick = true; break;
                        case (9):
                            townsman(attributionBorder); Console.WriteLine("You are Human. Townsman. Your ability minimum and maximum is.:");
                            foreach (var item in attributionBorder)
                            {
                                Console.WriteLine(item);
                            }
                            pick = true; break;
                        case (10):
                            nomad(attributionBorder); Console.WriteLine("You are one Human. Nomad. Your ability minimum and maximum is.:");
                            foreach (var item in attributionBorder)
                            {
                                Console.WriteLine(item);
                            }
                            pick = true; break;
                        case (11):
                            savage(attributionBorder); Console.WriteLine("You are one Human. Savage. Your ability minimum and maximum is.:");
                            foreach (var item in attributionBorder)
                            {
                                Console.WriteLine(item);
                            }
                            pick = true; break;
                        default:
                            Console.WriteLine("Feltöltés alatt");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Relax");
                }
            }
        }

        public void allAttribution()
        {
            List<characterAttribution> attributumValue = new List<characterAttribution>();
            attributumValue.Add(new characterAttribution(0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0));                      //44
            List<attributionBonus> bonus = new List<attributionBonus>(); bonus.Add(new attributionBonus(0, 0, 0));                                             //3
            mainAttributionselector(attributumValue, bonus);

            for (int i = 0; i < attributumValue.Count; i++)
            {
                Console.WriteLine(attributumValue[i]);
            }

            //Console.WriteLine("allAttributum");
        }

        public void attributionBonus(List<attributionBonus> bonus)
        {
            StreamReader sr = new StreamReader("properties/abilityBonus.txt");
            while (!sr.EndOfStream)
            {
                string adat = sr.ReadLine();
                string[] darabol = adat.Split('\t');
                bonus.Add(new attributionBonus(Convert.ToInt32(darabol[0]), Convert.ToInt32(darabol[1]), Convert.ToInt32(darabol[2])));
            }
            sr.Close();
        }

        public void limitValuecheck(List<raceAttributionBorder> attributumBorder)
        {
            int mainAttributes = 3; int value = 50;
            while (!mainAttributes.Equals(-1))
            {
                if ((attributumBorder[0].enduranceMin + attributumBorder[0].toughnessMin + attributumBorder[0].strengthMin).Equals(value))
                {
                    if (mainAttributes.Equals(3))
                    {
                        Console.WriteLine("Vitality can picking your primary attributum");
                    }
                    else if (mainAttributes.Equals(2))
                    {
                        Console.WriteLine("Vitality can picking your secondari or higher attributum");
                    }
                    else if (mainAttributes.Equals(1))
                    {
                        Console.WriteLine("Vitality can picking your teritary or higher attributum");
                    }
                    else if (mainAttributes.Equals(0))
                    {
                        Console.WriteLine("Vitality can picking your quarterly or higher attributum");
                    }
                }
                if ((attributumBorder[0].agilityMin + attributumBorder[0].quicknessMin + attributumBorder[0].perceptionMin).Equals(value))
                {
                    if (mainAttributes.Equals(3))
                    {
                        Console.WriteLine("Dexterity can picking your primary or higher attributum");
                    }
                    else if (mainAttributes.Equals(2))
                    {
                        Console.WriteLine("Dexterity can picking your secondari or higher attributum");
                    }
                    else if (mainAttributes.Equals(1))
                    {
                        Console.WriteLine("Dexterity can picking your teritary or higher attributum");
                    }
                    else if (mainAttributes.Equals(0))
                    {
                        Console.WriteLine("Dexterity can picking your quarterly or higher attributum");
                    }
                }
                if ((attributumBorder[0].intelligenceMin + attributumBorder[0].wisdomMin + attributumBorder[0].resourcefullMin).Equals(value))
                {
                    if (mainAttributes.Equals(3))
                    {
                        Console.WriteLine("Intuition can picking your primary attributum");
                    }
                    else if (mainAttributes.Equals(2))
                    {
                        Console.WriteLine("Intuition can picking your secondari or higher attributum");
                    }
                    else if (mainAttributes.Equals(1))
                    {
                        Console.WriteLine("Intuition can picking your teritary or higher attributum");
                    }
                    else if (mainAttributes.Equals(0))
                    {
                        Console.WriteLine("Intuition can picking your quarterly or higher attributum");
                    }
                }
                if ((attributumBorder[0].luckMin + attributumBorder[0].influenceMin + attributumBorder[0].appearanceMin).Equals(value))
                {
                    if (mainAttributes.Equals(3))
                    {
                        Console.WriteLine("Charisma can picking your primary attributum");
                    }
                    else if (mainAttributes.Equals(2))
                    {
                        Console.WriteLine("Charisma can picking your secondari or higher attributum");
                    }
                    else if (mainAttributes.Equals(1))
                    {
                        Console.WriteLine("Charisma can picking your teritary or higher attributum");
                    }
                    else if (mainAttributes.Equals(0))
                    {
                        Console.WriteLine("Charisma can picking your quarterly or higher attributum");
                    }
                }
                mainAttributes--;
                value -= 5;
            }
        }

        public void vitality(List<characterAttribution> attributionMain, List<attributionBonus> bonus, List<raceAttributionBorder> attributionBorder)
        {
            List<int> lowerBorder = new List<int>(); List<int> upperBorder = new List<int>();
            lowerBorder.Add(attributionBorder[0].enduranceMin); lowerBorder.Add(attributionBorder[0].toughnessMin); lowerBorder.Add(attributionBorder[0].strengthMin);
            upperBorder.Add(attributionBorder[0].enduranceMax); upperBorder.Add(attributionBorder[0].toughnessMax); upperBorder.Add(attributionBorder[0].strengthMax);
            attributionBonus(bonus);
            List<string> attributumName = new List<string>();
            attributumName.Add("Endurance"); attributumName.Add("Toughness"); attributumName.Add("Strength");
            List<int> attributumValue = new List<int>();
            attributumValue.Add(lowerBorder[0]); attributumValue.Add(lowerBorder[1]); attributumValue.Add(lowerBorder[2]);
            List<int> activebonusValue = new List<int>(); List<int> passivebonusValue = new List<int>();
            activebonusValue.Add(-9); activebonusValue.Add(-9); activebonusValue.Add(-9);
            passivebonusValue.Add(-9); passivebonusValue.Add(-9); passivebonusValue.Add(-9);
            int remainingPoint = attributionMain[0].vitality - (attributionBorder[0].enduranceMin + attributionBorder[0].toughnessMin + attributionBorder[0].strengthMin);
            while (remainingPoint != 0)
            {
                for (int i = 0; i < attributumName.Count; i++)
                {
                    for (int b = 0; b < bonus.Count; b++)
                    {
                        if (attributumValue[i].Equals(bonus[b].attributumValue))
                        {
                            activebonusValue[i] = bonus[b].activeBonus;
                            passivebonusValue[i] = bonus[b].passiveBonus;
                        }
                    }
                    Console.WriteLine("{0} {1} {2} {3} {4}", i + 1, attributumName[i], attributumValue[i], activebonusValue[i], passivebonusValue[i]);
                    if (i % 3 == 2)
                    {
                        Console.WriteLine();
                    }
                }
                Console.WriteLine("Melyik tulajdonságra szeretne pontot helyezni? Kérem a tulajdonság sorszámát adja meg");
                Console.WriteLine("Még {0} pontot áll rendelkezésére", remainingPoint);
                try
                {
                    int pickingattributum = Convert.ToInt32(Console.ReadLine());
                    if (pickingattributum < 1 || pickingattributum > 3)
                    {
                        throw new Exception { };
                    }
                    Console.WriteLine("Hány ponttal szeretné növelni a tulajdonságot?");
                    int qualitiValue = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < attributumValue.Count; i++)
                    {
                        if (attributumValue[pickingattributum - 1] + qualitiValue < lowerBorder[pickingattributum - 1])
                        {
                            qualitiValue = 0;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Érték nem csökkenhet faji minimum alá");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        if (upperBorder[pickingattributum - 1] < attributumValue[pickingattributum - 1] + qualitiValue)
                        {
                            qualitiValue = 0;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Érték nem nőhet faji maximum fölé");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    if (remainingPoint < qualitiValue)
                    {
                        qualitiValue = 0;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Nem áll rendelkezésedre elég pont");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (remainingPoint.Equals(qualitiValue))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Minden pont ki van osztva");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (remainingPoint > qualitiValue)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Még áll rendelkezésedre kiosztható pont");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    attributumValue[pickingattributum - 1] += qualitiValue;
                    remainingPoint = remainingPoint - qualitiValue;
                }
                catch (Exception)
                {
                    Console.WriteLine("A bemeneti érték nem megfelelő");
                }
            }
            for (int i = 0; i < attributumName.Count; i++)
            {
                for (int b = 0; b < bonus.Count; b++)
                {
                    if (attributumValue[i].Equals(bonus[b].attributumValue))
                    {
                        activebonusValue[i] = bonus[b].activeBonus;
                        passivebonusValue[i] = bonus[b].passiveBonus;
                    }
                }
                Console.WriteLine("{0} {1} {2} {3} {4}", i + 1, attributumName[i], attributumValue[i], activebonusValue[i], passivebonusValue[i]);
                if (i % 3 == 2)
                {
                    Console.WriteLine();
                }
            }
            attributionMain[0].endurance = attributumValue[0]; attributionMain[0].enduranceA = activebonusValue[0]; attributionMain[0].enduranceP = passivebonusValue[0];
            attributionMain[0].toughness = attributumValue[1]; attributionMain[0].toughnessA = activebonusValue[1]; attributionMain[0].toughnessP = passivebonusValue[1];
            attributionMain[0].strength = attributumValue[2];  attributionMain[0].strengthA = activebonusValue[2];  attributionMain[0].strengthP = passivebonusValue[2];
        }

        public void dexterity(List<characterAttribution> attributionMain, List<attributionBonus> bonus, List<raceAttributionBorder> attributionBorder)
        {
            List<int> lowerBorder = new List<int>(); List<int> upperBorder = new List<int>();
            lowerBorder.Add(attributionBorder[0].agilityMin); lowerBorder.Add(attributionBorder[0].quicknessMin); lowerBorder.Add(attributionBorder[0].perceptionMin);
            upperBorder.Add(attributionBorder[0].agilityMax); upperBorder.Add(attributionBorder[0].quicknessMax); upperBorder.Add(attributionBorder[0].perceptionMax);
            attributionBonus(bonus);
            List<string> attributumName = new List<string>();
            attributumName.Add("Agility"); attributumName.Add("Quickness"); attributumName.Add("Perception");
            List<int> attributumValue = new List<int>();
            attributumValue.Add(lowerBorder[0]); attributumValue.Add(lowerBorder[1]); attributumValue.Add(lowerBorder[2]);
            List<int> activebonusValue = new List<int>(); List<int> passivebonusValue = new List<int>();
            activebonusValue.Add(-9); activebonusValue.Add(-9); activebonusValue.Add(-9);
            passivebonusValue.Add(-9); passivebonusValue.Add(-9); passivebonusValue.Add(-9);
            int remainingPoint = attributionMain[0].dexterity - (attributionBorder[0].agilityMin + attributionBorder[0].quicknessMin + attributionBorder[0].perceptionMin);
            while (remainingPoint != 0)
            {
                for (int i = 0; i < attributumName.Count; i++)
                {
                    for (int b = 0; b < bonus.Count; b++)
                    {
                        if (attributumValue[i].Equals(bonus[b].attributumValue))
                        {
                            activebonusValue[i] = bonus[b].activeBonus;
                            passivebonusValue[i] = bonus[b].passiveBonus;
                        }
                    }
                    Console.WriteLine("{0} {1} {2} {3} {4}", i + 1, attributumName[i], attributumValue[i], activebonusValue[i], passivebonusValue[i]);
                    if (i % 3 == 2)
                    {
                        Console.WriteLine();
                    }
                }
                Console.WriteLine("Melyik tulajdonságra szeretne pontot helyezni? Kérem a tulajdonság sorszámát adja meg");
                Console.WriteLine("Még {0} pontot áll rendelkezésére", remainingPoint);
                try
                {
                    int pickingattributum = Convert.ToInt32(Console.ReadLine());
                    if (pickingattributum < 1 || pickingattributum > 3)
                    {
                        throw new Exception { };
                    }
                    Console.WriteLine("Hány ponttal szeretné növelni a tulajdonságot?");
                    int qualitiValue = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < 3; i++)
                    {
                        if (attributumValue[pickingattributum - 1] + qualitiValue < lowerBorder[pickingattributum - 1])
                        {
                            qualitiValue = 0;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Érték nem csökkenhet faji minimum alá");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        if (upperBorder[pickingattributum - 1] < attributumValue[pickingattributum - 1] + qualitiValue)
                        {
                            qualitiValue = 0;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Érték nem nőhet faji maximum fölé");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    if (remainingPoint < qualitiValue)
                    {
                        qualitiValue = 0;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Nem áll rendelkezésedre elég pont");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (remainingPoint.Equals(qualitiValue))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Minden pont ki van osztva");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (remainingPoint > qualitiValue)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Még áll rendelkezésedre kiosztható pont");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    attributumValue[pickingattributum - 1] += qualitiValue;
                    remainingPoint = remainingPoint - qualitiValue;
                }
                catch (Exception)
                {
                    Console.WriteLine("A bemeneti érték nem megfelelő");
                }
            }
            for (int i = 0; i < attributumName.Count; i++)
            {
                for (int b = 0; b < bonus.Count; b++)
                {
                    if (attributumValue[i].Equals(bonus[b].attributumValue))
                    {
                        activebonusValue[i] = bonus[b].activeBonus;
                        passivebonusValue[i] = bonus[b].passiveBonus;
                    }
                }
                Console.WriteLine("{0} {1} {2} {3} {4}", i + 1, attributumName[i], attributumValue[i], activebonusValue[i], passivebonusValue[i]);
                if (i % 3 == 2)
                {
                    Console.WriteLine();
                }
            }
            attributionMain[0].agility = attributumValue[0]; attributionMain[0].agilityA = activebonusValue[0]; attributionMain[0].agilityP = passivebonusValue[0];
            attributionMain[0].quickness = attributumValue[1]; attributionMain[0].quicknessA = activebonusValue[1]; attributionMain[0].quicknessP = passivebonusValue[1];
            attributionMain[0].perception = attributumValue[2]; attributionMain[0].perceptionA = activebonusValue[2]; attributionMain[0].perceptionP = passivebonusValue[2];
        }

        public void intuition(List<characterAttribution> attributionMain, List<attributionBonus> bonus, List<raceAttributionBorder> attributionBorder)
        {
            List<int> lowerBorder = new List<int>(); List<int> upperBorder = new List<int>();
            lowerBorder.Add(attributionBorder[0].intelligenceMin); lowerBorder.Add(attributionBorder[0].wisdomMin); lowerBorder.Add(attributionBorder[0].resourcefullMin);
            upperBorder.Add(attributionBorder[0].intelligenceMax); upperBorder.Add(attributionBorder[0].wisdomMax); upperBorder.Add(attributionBorder[0].resourcefullMax);
            attributionBonus(bonus);
            List<string> attributumName = new List<string>();
            attributumName.Add("Intelligence"); attributumName.Add("Wisdom"); attributumName.Add("Resourcefull");
            List<int> attributumValue = new List<int>();
            attributumValue.Add(lowerBorder[0]); attributumValue.Add(lowerBorder[1]); attributumValue.Add(lowerBorder[2]);
            List<int> activebonusValue = new List<int>(); List<int> passivebonusValue = new List<int>();
            activebonusValue.Add(-9); activebonusValue.Add(-9); activebonusValue.Add(-9);
            passivebonusValue.Add(-9); passivebonusValue.Add(-9); passivebonusValue.Add(-9);
            int remainingPoint = attributionMain[0].intuition - (attributionBorder[0].intelligenceMin + attributionBorder[0].wisdomMin + attributionBorder[0].resourcefullMin);
            while (remainingPoint != 0)
            {
                for (int i = 0; i < attributumName.Count; i++)
                {
                    for (int b = 0; b < bonus.Count; b++)
                    {
                        if (attributumValue[i].Equals(bonus[b].attributumValue))
                        {
                            activebonusValue[i] = bonus[b].activeBonus;
                            passivebonusValue[i] = bonus[b].passiveBonus;
                        }
                    }
                    Console.WriteLine("{0} {1} {2} {3} {4}", i + 1, attributumName[i], attributumValue[i], activebonusValue[i], passivebonusValue[i]);
                    if (i % 3 == 2)
                    {
                        Console.WriteLine();
                    }
                }
                Console.WriteLine("Melyik tulajdonságra szeretne pontot helyezni? Kérem a tulajdonság sorszámát adja meg");
                Console.WriteLine("Még {0} pontot áll rendelkezésére", remainingPoint);
                try
                {
                    int pickingattributum = Convert.ToInt32(Console.ReadLine());
                    if (pickingattributum < 1 || pickingattributum > 3)
                    {
                        throw new Exception { };
                    }
                    Console.WriteLine("Hány ponttal szeretné növelni a tulajdonságot?");
                    int qualitiValue = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < 3; i++)
                    {
                        if (attributumValue[pickingattributum - 1] + qualitiValue < lowerBorder[pickingattributum - 1])
                        {
                            qualitiValue = 0;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Érték nem csökkenhet faji minimum alá");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        if (upperBorder[pickingattributum - 1] < attributumValue[pickingattributum - 1] + qualitiValue)
                        {
                            qualitiValue = 0;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Érték nem nőhet faji maximum fölé");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    if (remainingPoint < qualitiValue)
                    {
                        qualitiValue = 0;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Nem áll rendelkezésedre elég pont");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (remainingPoint.Equals(qualitiValue))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Minden pont ki van osztva");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (remainingPoint > qualitiValue)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Még áll rendelkezésedre kiosztható pont");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    attributumValue[pickingattributum - 1] += qualitiValue;
                    remainingPoint = remainingPoint - qualitiValue;
                }
                catch (Exception)
                {
                    Console.WriteLine("A bemeneti érték nem megfelelő");
                }
            }
            for (int i = 0; i < attributumName.Count; i++)
            {
                for (int b = 0; b < bonus.Count; b++)
                {
                    if (attributumValue[i].Equals(bonus[b].attributumValue))
                    {
                        activebonusValue[i] = bonus[b].activeBonus;
                        passivebonusValue[i] = bonus[b].passiveBonus;
                    }
                }
                Console.WriteLine("{0} {1} {2} {3} {4}", i + 1, attributumName[i], attributumValue[i], activebonusValue[i], passivebonusValue[i]);
                if (i % 3 == 2)
                {
                    Console.WriteLine();
                }
            }
            attributionMain[0].intelligence = attributumValue[0]; attributionMain[0].intelligenceA = activebonusValue[0]; attributionMain[0].intelligenceP = passivebonusValue[0];
            attributionMain[0].wisdom = attributumValue[1]; attributionMain[0].wisdomA = activebonusValue[1]; attributionMain[0].wisdomP = passivebonusValue[1];
            attributionMain[0].resourcefull = attributumValue[2]; attributionMain[0].resourcefullA = activebonusValue[2]; attributionMain[0].resourcefullP = passivebonusValue[2];
        }

        public void charisma(List<characterAttribution> attributionMain, List<attributionBonus> bonus, List<raceAttributionBorder> attributionBorder)
        {
            List<int> lowerBorder = new List<int>(); List<int> upperBorder = new List<int>();
            lowerBorder.Add(attributionBorder[0].influenceMin); lowerBorder.Add(attributionBorder[0].appearanceMin); lowerBorder.Add(attributionBorder[0].luckMin);
            upperBorder.Add(attributionBorder[0].influenceMax); upperBorder.Add(attributionBorder[0].appearanceMax); upperBorder.Add(attributionBorder[0].luckMax);
            attributionBonus(bonus);
            List<string> attributumName = new List<string>();
            attributumName.Add("Influence"); attributumName.Add("Appearance"); attributumName.Add("Luck");
            List<int> attributumValue = new List<int>();
            attributumValue.Add(lowerBorder[0]); attributumValue.Add(lowerBorder[1]); attributumValue.Add(lowerBorder[2]);
            List<int> activebonusValue = new List<int>(); List<int> passivebonusValue = new List<int>();
            activebonusValue.Add(-9); activebonusValue.Add(-9); activebonusValue.Add(-9);
            passivebonusValue.Add(-9); passivebonusValue.Add(-9); passivebonusValue.Add(-9);
            int remainingPoint = attributionMain[0].charisma - (attributionBorder[0].influenceMin + attributionBorder[0].appearanceMin + attributionBorder[0].luckMin);
            while (remainingPoint != 0)
            {
                for (int i = 0; i < attributumName.Count; i++)
                {
                    for (int b = 0; b < bonus.Count; b++)
                    {
                        if (attributumValue[i].Equals(bonus[b].attributumValue))
                        {
                            activebonusValue[i] = bonus[b].activeBonus;
                            passivebonusValue[i] = bonus[b].passiveBonus;
                        }
                    }
                    Console.WriteLine("{0} {1} {2} {3} {4}", i + 1, attributumName[i], attributumValue[i], activebonusValue[i], passivebonusValue[i]);
                    if (i % 3 == 2)
                    {
                        Console.WriteLine();
                    }
                }
                Console.WriteLine("Melyik tulajdonságra szeretne pontot helyezni? Kérem a tulajdonság sorszámát adja meg");
                Console.WriteLine("Még {0} pontot áll rendelkezésére", remainingPoint);
                try
                {
                    int pickingattributum = Convert.ToInt32(Console.ReadLine());
                    if (pickingattributum < 1 || pickingattributum > 3)
                    {
                        throw new Exception { };
                    }
                    Console.WriteLine("Hány ponttal szeretné növelni a tulajdonságot?");
                    int qualitiValue = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < 3; i++)
                    {
                        if (attributumValue[pickingattributum - 1] + qualitiValue < lowerBorder[pickingattributum - 1])
                        {
                            qualitiValue = 0;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Érték nem csökkenhet faji minimum alá");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        if (upperBorder[pickingattributum - 1] < attributumValue[pickingattributum - 1] + qualitiValue)
                        {
                            qualitiValue = 0;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Érték nem nőhet faji maximum fölé");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    if (remainingPoint < qualitiValue)
                    {
                        qualitiValue = 0;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Nem áll rendelkezésedre elég pont");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (remainingPoint.Equals(qualitiValue))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Minden pont ki van osztva");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (remainingPoint > qualitiValue)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Még áll rendelkezésedre kiosztható pont");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    attributumValue[pickingattributum - 1] += qualitiValue;
                    remainingPoint = remainingPoint - qualitiValue;
                }
                catch (Exception)
                {
                    Console.WriteLine("A bemeneti érték nem megfelelő");
                }
            }
            for (int i = 0; i < attributumName.Count; i++)
            {
                for (int b = 0; b < bonus.Count; b++)
                {
                    if (attributumValue[i].Equals(bonus[b].attributumValue))
                    {
                        activebonusValue[i] = bonus[b].activeBonus;
                        passivebonusValue[i] = bonus[b].passiveBonus;
                    }
                }
                Console.WriteLine("{0} {1} {2} {3} {4}", i + 1, attributumName[i], attributumValue[i], activebonusValue[i], passivebonusValue[i]);
                if (i % 3 == 2)
                {
                    Console.WriteLine();
                }
            }
            attributionMain[0].influence = attributumValue[0]; attributionMain[0].influenceA = activebonusValue[0]; attributionMain[0].influenceP = passivebonusValue[0];
            attributionMain[0].appearance = attributumValue[1]; attributionMain[0].appearanceA = activebonusValue[1]; attributionMain[0].appearanceP = passivebonusValue[1];
            attributionMain[0].luck = attributumValue[2]; attributionMain[0].luckA = activebonusValue[2]; attributionMain[0].luckP = passivebonusValue[2];
        }

        #region raceSelector
        public static void mountainDwarf(List<raceAttributionBorder> attributionBorder)
        {
            attributionBorder.Add(new raceAttributionBorder(15, 25, 15, 25, 10, 20, 5, 20, 3, 15, 3, 15, 3, 18, 3, 25, 3, 16, 3, 14, 3, 12, 3, 25));
        }

        public static void surfaceDwarf(List<raceAttributionBorder> attributionBorder)
        {
            attributionBorder.Add(new raceAttributionBorder(10, 25, 10, 25, 10, 20, 3, 15, 3, 20, 5, 20, 3, 18, 3, 16, 3, 25, 3, 12, 3, 14, 3, 25));
        }

        public static void hillDwarf(List<raceAttributionBorder> attributionBorder)
        {
            attributionBorder.Add(new raceAttributionBorder(3, 20, 3, 20, 3, 20, 3, 20, 3, 20, 3, 20, 3, 20, 3, 20, 3, 20, 3, 20, 3, 20, 3, 20));
        }

        public static void northmen(List<raceAttributionBorder> attributionBorder)
        {
            attributionBorder.Add(new raceAttributionBorder(3, 20, 3, 20, 3, 20, 3, 20, 3, 20, 3, 20, 3, 20, 3, 20, 3, 20, 3, 20, 3, 20, 3, 20));
        }

        public static void shadowElf(List<raceAttributionBorder> attributionBorder)
        {
            attributionBorder.Add(new raceAttributionBorder(5, 16, 3, 16, 5, 18, 10, 25, 10, 25, 10, 25, 5, 16, 5, 16, 5, 20, 3, 15, 5, 20, 5, 25));
        }

        public static void forestElf(List<raceAttributionBorder> attributionBorder)
        {
            attributionBorder.Add(new raceAttributionBorder(5, 16, 5, 16, 5, 18, 10, 22, 10, 18, 10, 18, 5, 16, 5, 20, 5, 16, 5, 20, 3, 15, 5, 15));
        }

        public static void swampElf(List<raceAttributionBorder> attributionBorder)
        {
            attributionBorder.Add(new raceAttributionBorder(5, 20, 5, 20, 5, 15, 10, 22, 10, 22, 10, 22, 5, 16, 5, 20, 5, 16, 5, 20, 3, 15, 5, 15));
        }

        public static void townElf(List<raceAttributionBorder> attributionBorder)
        {
            attributionBorder.Add(new raceAttributionBorder(5, 16, 5, 16, 5, 18, 10, 20, 10, 25, 10, 18, 5, 16, 5, 20, 5, 16, 5, 20, 3, 15, 5, 15));
        }

        public static void townsman(List<raceAttributionBorder> attributionBorder)
        {
            attributionBorder.Add(new raceAttributionBorder(3, 20, 3, 20, 3, 20, 3, 20, 3, 20, 3, 20, 3, 20, 3, 20, 3, 20, 3, 20, 3, 20, 3, 20));
        }

        public static void nomad(List<raceAttributionBorder> attributionBorder)
        {
            attributionBorder.Add(new raceAttributionBorder(10, 25, 10, 25, 10, 20, 3, 15, 3, 20, 5, 20, 3, 18, 3, 16, 3, 25, 3, 12, 3, 14, 3, 25));
        }

        public static void savage(List<raceAttributionBorder> attributionBorder)
        {
            attributionBorder.Add(new raceAttributionBorder(5, 16, 3, 16, 5, 18, 10, 25, 10, 25, 10, 25, 5, 16, 5, 16, 5, 20, 3, 15, 5, 20, 5, 25));
        }
        #endregion
    }
}
