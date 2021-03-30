using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mD_WPF_chSheet_01.objects.characterObject
{
    public class raceAttributionBorder
    {
        public int enduranceMin { get; set; }
        public int enduranceMax { get; set; }
        public int toughnessMin { get; set; }
        public int toughnessMax { get; set; }
        public int strengthMin { get; set; }
        public int strengthMax { get; set; }

        public int perceptionMin { get; set; }
        public int perceptionMax { get; set; }
        public int quicknessMin { get; set; }
        public int quicknessMax { get; set; }
        public int agilityMin { get; set; }
        public int agilityMax { get; set; }

        public int intelligenceMin { get; set; }
        public int intelligenceMax { get; set; }
        public int wisdomMin { get; set; }
        public int wisdomMax { get; set; }
        public int resourcefullMin { get; set; }
        public int resourcefullMax { get; set; }

        public int influenceMin { get; set; }
        public int influenceMax { get; set; }
        public int appearanceMin { get; set; }
        public int appearanceMax { get; set; }
        public int luckMin { get; set; }
        public int luckMax { get; set; }

        public raceAttributionBorder(int enduranceMin, int enduranceMax, int toughnessMin, int toughnessMax, int strengthMin, int strengthMax,
                                    int perceptionMin, int perceptionMax, int quicknessMin, int quicknessMax, int agilityMin, int agilityMax,
                                    int intelligenceMin, int intelligenceMax, int wisdomMin, int wisdomMax, int resourcefullMin, int resourcefullMax,
                                    int influenceMin, int influenceMax, int appearanceMin, int appearanceMax, int luckMin, int luckMax)
        {
            this.enduranceMin = enduranceMin;
            this.enduranceMax = enduranceMax;
            this.toughnessMin = toughnessMin;
            this.toughnessMax = toughnessMax;
            this.strengthMin = strengthMin;
            this.strengthMax = strengthMax;

            this.perceptionMin = perceptionMin;
            this.perceptionMax = perceptionMax;
            this.quicknessMin = quicknessMin;
            this.quicknessMax = quicknessMax;
            this.agilityMin = agilityMin;
            this.agilityMax = agilityMax;

            this.intelligenceMin = intelligenceMin;
            this.intelligenceMax = intelligenceMax;
            this.wisdomMin = wisdomMin;
            this.wisdomMax = wisdomMax;
            this.resourcefullMin = resourcefullMin;
            this.resourcefullMax = resourcefullMax;

            this.influenceMin = influenceMin;
            this.influenceMax = influenceMax;
            this.appearanceMin = appearanceMin;
            this.appearanceMax = appearanceMax;
            this.luckMin = luckMin;
            this.luckMax = luckMax;

        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} " +
                                 "{12} {13} {14} {15} {16} {17} {18} {19} {20} {21} {22} {23}",
                                enduranceMin, enduranceMax, toughnessMin, toughnessMax, strengthMin, strengthMax,
                                perceptionMin, perceptionMax, quicknessMin, quicknessMax, agilityMin, agilityMax,
                                intelligenceMin, intelligenceMax, wisdomMin, wisdomMax, resourcefullMin, resourcefullMax,
                                influenceMin, influenceMax, appearanceMin, appearanceMax, luckMin, luckMax);
        }
    }
}
